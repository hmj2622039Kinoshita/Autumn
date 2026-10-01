using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI candyResult;
    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame) // escapeキー
        {
            SceneManager.LoadScene("Title"); // タイトルへ戻る
        }

        candyResult.text = Player.candyCount.ToString(); // 結果表示
    }
}
