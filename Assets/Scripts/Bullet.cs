using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    void Start()
    {
        rb.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D( Collider2D col )
    {
        Destroy(gameObject);
    }
}
