using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 3f; // プレイヤーの速度
    [SerializeField] Rigidbody2D rb; //rigidbody入れ 
    [SerializeField] GameObject human;
    [SerializeField] GameObject[] enemy;
    [SerializeField] Animator humanAnimator; // animator入れ
    [SerializeField] Animator[] enemyAnimator; // animator入れ
    [SerializeField] SpriteRenderer humanSpriteRenderer;
    [SerializeField] SpriteRenderer[] enemySpriteRenderer;
    [SerializeField] TextMeshProUGUI candyText;

    public static bool isEnemy = false;
    public static int enemyIndex = 0;
    public static int candyCount = 0;

    private void Start()
    {
        isEnemy = false;
        enemyIndex = 0;
        candyCount = 0;
        human.SetActive(true);
        for(int i=0;i<enemy.Length;i++)
        {
            enemy[i].SetActive(false);
        }
    }

    private void Update()
    {
        float x = 0;
        float y = 0;
        if(Keyboard.current.wKey.isPressed)
        {
            y = 1;
        }
        if(Keyboard.current.aKey.isPressed)
        {
            x = -1;
        }
        if(Keyboard.current.sKey.isPressed)
        {
            y = -1;
        }
        if(Keyboard.current.dKey.isPressed)
        {
            x = 1;
        }
        rb.linearVelocity=new Vector2(x,y)*speed;
        if(x > 0)
        {
            humanSpriteRenderer.flipX = false;
            if(isEnemy)
            {
                enemySpriteRenderer[enemyIndex].flipX = false;
            }
        }
        if(x < 0)
        {
            humanSpriteRenderer.flipX = true;
            if(isEnemy)
            {
                enemySpriteRenderer[enemyIndex].flipX = true;
            }
        }

        humanAnimator.SetBool("run", x != 0 || y != 0);
        for(int i=0;i<enemyAnimator.Length;i++)
        {
            enemyAnimator[i].SetBool("run", false);
        }
        if(isEnemy)
        {
            enemyAnimator[enemyIndex].SetBool("run", x != 0 || y != 0);
        }
        if(Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            ChangeEnemy(-1);
        }
        if(Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            ChangeEnemy(1);
        }

        if(Keyboard.current.eKey.wasPressedThisFrame)
        {
            ChangeForm();
        }

        candyText.text = candyCount.ToString("F0");

    }
    void ChangeEnemy(int direction)
    {
        enemyIndex += direction;
        if(enemyIndex>=enemy.Length)
        {
            enemyIndex =0;
        }
        if(enemyIndex<0)
        {
            enemyIndex =enemy.Length-1;
        }
    }

    void ChangeForm()
    {
        isEnemy = !isEnemy;
        human.SetActive(!isEnemy);
        for(int i=0;i<enemy.Length;i++)
        {
            enemy[i].SetActive(true);
        }
        if(isEnemy)
        {
            enemy[enemyIndex].SetActive(true);
        }
    }
    

}