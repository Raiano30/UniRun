using UnityEngine;

//���� ������Ʈ�� ��� �������� �����̴� ��ũ��Ʈ
public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f; //�̵� �ӵ� 

    void Update()
    {
        //�ʴ� speed�� �ӵ��� �������� Translate �����̵�
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}