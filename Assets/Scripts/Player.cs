using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1.5f; // プレイヤーの速度
    //[SerializeField] Animator animator; // animator入れ

    private void Awake()
    {
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up*speed*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left*speed*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down*speed*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right*speed*Time.deltaTime;
        }
    }

}
