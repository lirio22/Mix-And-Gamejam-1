using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            spriteRenderer.flipX = true;
            rb2d.MovePosition(new Vector2(rb2d.transform.position.x + Input.GetAxisRaw("Horizontal") * speed, rb2d.position.y));
        }

        if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = false;
            rb2d.MovePosition(new Vector2(rb2d.transform.position.x + Input.GetAxisRaw("Horizontal") * speed, rb2d.position.y));
        }
    }
}