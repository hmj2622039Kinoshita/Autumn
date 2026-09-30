using UnityEngine;
using UnityEngine.InputSystem;

public class Bot : MonoBehaviour
{
    [SerializeField] GameObject talkText; // 会話テキスト入れ
    
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                talkText.SetActive(true);
                Invoke("HideText",2f);
            }
        }
    }

    void HideText()
    {
        talkText.SetActive(false);
    }
}
