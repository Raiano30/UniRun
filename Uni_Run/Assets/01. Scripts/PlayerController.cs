using UnityEngine;
//PlayerController�� �÷��̾� ĳ���ͷμ� Player ���� ������Ʈ�� ������
public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; //��� �� ����� ����� Ŭ��
    public float jumpForce = 700f; //���� ��

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

    private void Update()
    {
        //����� �Է��� �����ϰ� �����ϴ� ó��
        if (isDead)
        {
            //��� �� ó���� �� �̻� �������� �ʰ� ����
            return;
        }
        //���콺 ���� ��ư�� �������� && �ִ�����Ƚ��(2)�� �������� �ʾҴٸ�

        
    }
    private void Die()
    {
        //��� ó��
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹�� ����
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�ٴڿ� ������� �����ϴ� ó��
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //�ٴڿ��� ������� �����ϴ� ó��
    }
    
}
