using UnityEngine;
//PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어함
public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; //사망 시 재생할 오디오 클립 //private
    //빌드하면 사용된 데이터만 빌드가된다. , 사운드파일 사용했는지 어케알지?
    //프로젝트뷰에서 가져올때는, 폴더명을 인지해서 빌드시 무조건 포함시키게 한다. 

    public float jumpForce = 500f; //점프 힘

    private int jumpCount = 0; //누적 점프 횟수
    private bool isGrounded = false; //바닥에 닿았는지
    private bool isDead = false; //사망상태

    private Rigidbody2D playerRigidbody; //사용할 리지드바디 컴포넌트
    private Animator animator; //사용할 애니메이터 컴포넌트
    private AudioSource playerAudio; //사용할 오디오 소스 컴포넌트


    private void Start()
    {
        //게임 오브젝트로부터 사용할 컴포넌트들을 가져와 변수에 할당
        playerRigidbody = GetComponent<Rigidbody2D>(); //겟읽기 셋쓰기//<>타입의 컴포넌트를 읽는다. 
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update() //사용자 입력을 감지하고 점프하는 처리
    {
        //사망 시 처리를 더 이상 진행하지 않고 종료
        if (isDead) return; //점프문 = switch문의 break; continue; goto;
        
        //좌클 다운, 한손가락 폰터치 && 최대점프횟수(2)에 도달하지 않았다면 //&&: and연산자
        if(Input.GetMouseButtonDown(0) && jumpCount < 2) //(1)은 우클 다운, 두손가락 폰터치
        {
            //점프 횟수 증가
            jumpCount++;
            //점프 직전에 속도를 순간적으로 제로(0,0)로 변경, 바로 멈춘다
            playerRigidbody.velocity = Vector2.zero; //벡터의 속기
            //리지드바디에 위쪽으로 힘 주기 //힘 두 종류 : 순간적인힘 ForceMode2D.Impulse, 지속적인힘 force //AddForce(힘, 모드)
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            //오디오 소스 재생
            playerAudio.Play();
            
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            //마우스 왼쪽 버튼에서 손을 떼는 순간 && 속도의 y값이 양수라면(위로 상승 중)
            //현재 속도를 절반으로 깍는다
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        //애니메이터의 Grounded파라미터를 isGrounded값으로 갱신
        animator.SetBool("Grounded", isGrounded);
        
    }
    private void Die() //사망 처리
    {
        //애니메이터의 Die트리거 파라미터를 셋
        animator.SetTrigger("Die");
        //오디오 소스에 할당된 오디오 클립을 deathClip으로 변경
        playerAudio.clip = deathClip;
        //사망 효과음 재생
        playerAudio.Play();

        //속도를 제로(0,0)로 변경
        playerRigidbody.velocity = Vector2.zero;
        //사망 상태를 ture로 변경
        isDead = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //트리거 콜라이더를 가진 장애물과의 충돌을 감지
        if(other.tag == "Dead" && !isDead) //충돌한 상대방의 태그가 "Dead" And 아직 사망하지 않았다면
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //바닥에 닿았음을 감지
        //어떤 콜라이더와 닿았으며, 충돌 표면이 위쪽을 보고있으면
        if(collision.contacts[0].normal.y > 0.7f)
        {
            //isGrounded를 true로 변경하고, 누적 점프 횟수를 0으로 리셋
            isGrounded = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //바닥에서 벗어났음을 감지
        //어떤 콜라이더에서 떼어진 경우 isGrounded를 false로 변경
        isGrounded = false;

    }
    
}
