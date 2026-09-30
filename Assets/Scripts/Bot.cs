using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bot : MonoBehaviour
{
    [SerializeField] GameObject talkText; // 会話テキスト入れ
    [SerializeField] Transform player;
    [SerializeField] float talkDistance = 1f;
    [SerializeField] int candyAmount = 5;
    [SerializeField] int weakEnemyIndex = 0;

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= talkDistance)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                if (Player.isEnemy)
                {
                    TakeCandy();
                }
                else
                {
                    talkText.SetActive(true);
                    Invoke("HideText", 2f);
                }
            }
        }
    }
    void TakeCandy()
    {
        if(candyAmount>0)
        {
            int takeAmount = UnityEngine.Random.Range(1, 16);
            if(Player.enemyIndex==weakEnemyIndex)
            {
                takeAmount += 10;
            }
            if(takeAmount>candyAmount)
            {
                takeAmount = candyAmount;
            }
            candyAmount -= takeAmount;
        }
    }


   
    void HideText()
    {
        talkText.SetActive(false);
    }
}
