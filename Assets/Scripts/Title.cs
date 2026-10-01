using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame) // spaceキー
        {
            SceneManager.LoadScene("PlayScene"); // playシーン遷移
        }
    }
}
