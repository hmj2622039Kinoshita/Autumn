using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 3f; // プレイヤーの速度
    [SerializeField] Rigidbody2D rb; //rigidbody 
    [SerializeField] GameObject human; // 人間形態
    [SerializeField] GameObject[] enemy;　// 化け形態
    [SerializeField] Animator humanAnimator; // animator
    [SerializeField] Animator[] enemyAnimator;
    [SerializeField] SpriteRenderer humanSpriteRenderer; // spriterenderer
    [SerializeField] SpriteRenderer[] enemySpriteRenderer;
    [SerializeField] GameObject[] selectFrame; // 赤枠
    [SerializeField] TextMeshProUGUI candyText; // キャンディーの個数

    public static bool isEnemy = false; // 化け状態かどうか
    public static int enemyNum = 0; // 化けの種類番号
    public static int candyCount = 0; // playerのキャンディー保有数

    private void Start()
    { // 初期値
        isEnemy = false;
        enemyNum = 0;
        candyCount = 0;
        human.SetActive(true);
        for (int i = 0; i < enemy.Length; i++) // 化けの状態解除
        {
            enemy[i].SetActive(false);
        }
        for (int j = 0; j < selectFrame.Length; j++) // 赤枠（選択状態）、現在選択されていたら赤枠表示
        {
            selectFrame[j].SetActive(j == enemyNum);
        }
    }

    private void Update()
    {
        float x = 0;
        float y = 0;
        if(Keyboard.current.wKey.isPressed) // wキー
        {
            y = 1;
        }
        if(Keyboard.current.aKey.isPressed) // aキー
        {
            x = -1;
        }
        if(Keyboard.current.sKey.isPressed) // sキー
        {
            y = -1;
        }
        if(Keyboard.current.dKey.isPressed) // dキー
        {
            x = 1;
        }
        rb.linearVelocity = new Vector2(x, y) * speed; // プレイヤーの移動
        
        if(x > 0) // プレイヤーの人間状態と化け状態の向き反転
        {
            humanSpriteRenderer.flipX = false;
            if(isEnemy)
            {
                enemySpriteRenderer[enemyNum].flipX = false;
            }
        }
        if(x < 0)
        {
            humanSpriteRenderer.flipX = true;
            if(isEnemy)
            {
                enemySpriteRenderer[enemyNum].flipX = true;
            }
        }

        humanAnimator.SetBool("run", x != 0 || y != 0); // プレイヤーの走るアニメーション
        for (int i = 0; i < enemyAnimator.Length; i++) // 化け状態のアニメーション
        {
            enemyAnimator[i].SetBool("run", false);
        }
        if(isEnemy)
        {
            enemyAnimator[enemyNum].SetBool("run", x != 0 || y != 0);
        }

        if(Keyboard.current.leftArrowKey.wasPressedThisFrame) // 左キーで選択
        {
            ChangeEnemy(-1);
        }
        if(Keyboard.current.rightArrowKey.wasPressedThisFrame) // 右キーで選択
        {
            ChangeEnemy(1);
        }

        if(Keyboard.current.eKey.wasPressedThisFrame) // eキーで形態切り替え
        {
            ChangeForm();
        }

        candyText.text = candyCount.ToString(); // キャンディーの個数表示更新
    }

    void ChangeEnemy(int direction) // 化け状態の選択処理
    {
        enemyNum += direction;
        if (enemyNum >= enemy.Length)
        {
            enemyNum = 0;
        }
        if (enemyNum < 0)
        {
            enemyNum = enemy.Length - 1;
        }

        for (int i = 0; i < selectFrame.Length; i++) // 赤枠の表示
        {
            selectFrame[i].SetActive(i == enemyNum);
        }
    }

    void ChangeForm() // 化け状態の表示
    {
        isEnemy = !isEnemy;
        human.SetActive(!isEnemy); // 人間状態の非表示
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].SetActive(false);
        }
        if(isEnemy)
        {
            enemy[enemyNum].SetActive(true);
        }
    }
}