using UnityEngine;
//PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어함
public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; //사망 시 재생할 오디오 클립
    public float jumpForce = 700f; //점프 힘

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

    private void Update()
    {
        //사용자 입력을 감지하고 점프하는 처리
        if (isDead)
        {
            //사망 시 처리를 더 이상 진행하지 않고 종료
            return;
        }
        //마우스 왼쪽 버튼을 눌렀으며 && 최대점프횟수(2)에 도달하지 않았다면

        
    }
    private void Die()
    {
        //사망 처리
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //트리거 콜라이더를 가진 장애물과의 충돌을 감지
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //바닥에 닿았음을 감지하는 처리
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //바닥에서 벗어났음을 감지하는 처리
    }
    
}
