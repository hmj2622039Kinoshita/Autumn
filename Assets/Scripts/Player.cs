using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1.5f; // プレイヤーの速度
    [SerializeField] Rigidbody2D rb; //rigidbody入れ 
    [SerializeField] Animator animator; // animator入れ
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = 0;
        float y = 0;
        if(Input.GetKey(KeyCode.W))
        {
            y = 1;
        }
        if(Input.GetKey(KeyCode.A))
        {
            x = -1;
        }
        if(Input.GetKey(KeyCode.S))
        {
            y = -1;
        }
        if(Input.GetKey(KeyCode.D))
        {
            x = 1;
        }
        if(x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if(x < 0)
        {
            spriteRenderer.flipX = true;
        }
        rb.linearVelocity=new Vector2(x,y)*speed;
        animator.SetBool("run", x != 0 || y != 0);
    }
    

}
