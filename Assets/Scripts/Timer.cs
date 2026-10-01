using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // TextMeshPro用

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject timerText; // タイマーのText入れ
    [SerializeField] float timer = 60;

    private void Update()
    {
        this.timer -= Time.deltaTime; // タイマーの時間を減らす
        this.timerText.GetComponent<TextMeshProUGUI>().text = this.timer.ToString("F0");
        if (timer <= 0)
        {
            SceneManager.LoadScene("Result"); // 結果画面へ
        }
    }
}
