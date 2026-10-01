using UnityEngine;
using UnityEngine.InputSystem;

public class Bot : MonoBehaviour
{
    [SerializeField] GameObject talkText; // 会話テキスト入れ
    [SerializeField] GameObject faintText; // 気絶テキスト入れ
    [SerializeField] Transform player; // プレイヤーの座標入れ
    [SerializeField] float talkDistance = 1f; // 会話判定距離
    [SerializeField] int candyAmount = 5; // 初期キャンディー保持数
    [SerializeField] int weakEnemyNum = 0; // 苦手な化けの種類番号
    [SerializeField] float humanCoolTime = 4f; // 人間形態時の会話クールタイム
    [SerializeField] float enemyCoolTime = 8f; // 化け形態時の会話クールタイム
    private float humanTimer = 0f; // 人間形態で会話したとき用タイマー
    private float enemyTimer = 0f; // 化け形態で脅かしたとき用タイマー
    private float candyTimer = 0f; // キャンディー増加用タイマー

    private void Update()
    {
        candyTimer++;
        if(candyTimer > 180) // 3秒に１個所持キャンディが増える
        {
            candyAmount++;
            candyTimer = 0; // タイマーリセット
        }
        if(humanTimer > 0) // 人間形態会話クールタイム
        {
            humanTimer -= Time.deltaTime;
        }
        if(enemyTimer > 0) // 化け形態驚かすクールタイム
        {
            enemyTimer -= Time.deltaTime;
            if (enemyTimer <= 0) // クールタイム終了
            {
                faintText.SetActive(false);
            }
        }

        float distance = Vector2.Distance(transform.position, player.position); // プレイヤーとbotとの距離
        if (distance <= talkDistance)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame) // spaceキー
            {
                if (!Player.isEnemy) // 人間形態
                {
                    if (humanTimer > 0)
                    {
                        return;
                    }
                    humanTimer = humanCoolTime;
                    talkText.SetActive(true); // 会話文表示
                    Invoke("HideText", 3f);
                }
                else　// 化け状態
                {
                    if (enemyTimer > 0)
                    {
                        return;
                    }
                    enemyTimer = enemyCoolTime;
                    faintText.SetActive(true); // 気絶文表示
                    TakeCandy(); // キャンディーをプレイヤーに渡す
                }
            }
        }
    }
    void TakeCandy() // キャンディーをプレイヤーに渡す関数
    {
        if(candyAmount > 0)
        {
            int takeAmount = UnityEngine.Random.Range(1, 16);
            if(Player.enemyNum == weakEnemyNum) // 苦手な化けの種類だったら加点
            {
                takeAmount += 10;
            }
            if(takeAmount > candyAmount) // キャンディーが足りなくなったらある分だけ渡す
            {
                takeAmount = candyAmount;
            }
            candyAmount -= takeAmount; // botのキャンディー減る
            Player.candyCount += takeAmount; // playerのキャンディー増える
        }
    }

    void HideText()
    {
        talkText.SetActive(false);
    }
}
