using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 2f; // プレイヤーの速度
    [SerializeField] Rigidbody2D rb; // rigidbody入れ
    [SerializeField] Animator animator; // animator入れ

    private void Start()
    {
        animator = GetComponent<Animator>(); // animatorに入れる
    }
}
