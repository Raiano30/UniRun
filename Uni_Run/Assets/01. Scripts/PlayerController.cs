using UnityEngine;
//PlayerController�� �÷��̾� ĳ���ͷμ� Player ���� ������Ʈ�� ������
public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; //��� �� ����� ����� Ŭ�� //private
    //�����ϸ� ���� �����͸� ���尡�ȴ�. , �������� ����ߴ��� ���ɾ���?
    //������Ʈ�信�� �����ö���, �������� �����ؼ� ����� ������ ���Խ�Ű�� �Ѵ�. 

    public float jumpForce = 500f; //���� ��

    private int jumpCount = 0; //���� ���� Ƚ��
    private bool isGrounded = false; //�ٴڿ� ��Ҵ���
    private bool isDead = false; //�������

    private Rigidbody2D playerRigidbody; //����� ������ٵ� ������Ʈ
    private Animator animator; //����� �ִϸ����� ������Ʈ
    private AudioSource playerAudio; //����� ����� �ҽ� ������Ʈ


    private void Start()
    {
        //���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>(); //���б� �¾���//<>Ÿ���� ������Ʈ�� �д´�. 
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update() //����� �Է��� �����ϰ� �����ϴ� ó��
    {
        //��� �� ó���� �� �̻� �������� �ʰ� ����
        if (isDead) return; //������ = switch���� break; continue; goto;
        
        //��Ŭ �ٿ�, �Ѽհ��� ����ġ && �ִ�����Ƚ��(2)�� �������� �ʾҴٸ� //&&: and������
        if(Input.GetMouseButtonDown(0) && jumpCount < 2) //(1)�� ��Ŭ �ٿ�, �μհ��� ����ġ
        {
            //���� Ƚ�� ����
            jumpCount++;
            //���� ������ �ӵ��� ���������� ����(0,0)�� ����, �ٷ� �����
            playerRigidbody.velocity = Vector2.zero; //������ �ӱ�
            //������ٵ� �������� �� �ֱ� //�� �� ���� : ���������� ForceMode2D.Impulse, ���������� force //AddForce(��, ���)
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            //����� �ҽ� ���
            playerAudio.Play();
            
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            //���콺 ���� ��ư���� ���� ���� ���� && �ӵ��� y���� ������(���� ��� ��)
            //���� �ӵ��� �������� ��´�
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        //�ִϸ������� Grounded�Ķ���͸� isGrounded������ ����
        animator.SetBool("Grounded", isGrounded);
        
    }
    private void Die() //��� ó��
    {
        //�ִϸ������� DieƮ���� �Ķ���͸� ��
        animator.SetTrigger("Die");
        //����� �ҽ��� �Ҵ�� ����� Ŭ���� deathClip���� ����
        playerAudio.clip = deathClip;
        //��� ȿ���� ���
        playerAudio.Play();

        //�ӵ��� ����(0,0)�� ����
        playerRigidbody.velocity = Vector2.zero;
        //��� ���¸� ture�� ����
        isDead = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹�� ����
        if(other.tag == "Dead" && !isDead) //�浹�� ������ �±װ� "Dead" And ���� ������� �ʾҴٸ�
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�ٴڿ� ������� ����
        //� �ݶ��̴��� �������, �浹 ǥ���� ������ ����������
        if(collision.contacts[0].normal.y > 0.7f)
        {
            //isGrounded�� true�� �����ϰ�, ���� ���� Ƚ���� 0���� ����
            isGrounded = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //�ٴڿ��� ������� ����
        //� �ݶ��̴����� ������ ��� isGrounded�� false�� ����
        isGrounded = false;

    }
    
}
