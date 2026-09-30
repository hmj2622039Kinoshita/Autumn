using UnityEngine;
using TMPro; // TextMeshPro用

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject timerText; // タイマーのText入れ
    float timer = 60;

    private void Update()
    {
        this.timer -= Time.deltaTime; // タイマーの時間を減らす
        this.timerText.GetComponent<TextMeshProUGUI>().text = this.timer.ToString("F0");
    }
}
