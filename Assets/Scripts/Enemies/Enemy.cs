using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float moveSpeed = 8.0f;
    [SerializeField] private LayerMask raycastLayerMask;
    [SerializeField] private Vector2 raycastOffset = new Vector2(1, 0);
    [SerializeField] private float raycastLength = 2;
    [SerializeField] private int attackPower = 10;
    [SerializeField] private int maxHealth = 100;

    [SerializeField] private int direction = 1;
    private RaycastHit2D leftLedgeRaycastHit;
    private RaycastHit2D rightLedgeRaycastHit;
    private RaycastHit2D leftWallRaycastHit;
    private RaycastHit2D rightWallRaycastHit;

    void Update()
    {
        rigidBody.velocity = new Vector2(moveSpeed * direction, 0);
        // Left ledge check
        leftLedgeRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x - raycastOffset.x, transform.position.y + raycastOffset.y), Vector2.down, raycastLength);
        if (leftLedgeRaycastHit.collider == null) direction = 1;
        
        // Right ledge check
        rightLedgeRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x + raycastOffset.x, transform.position.y + raycastOffset.y), Vector2.down, raycastLength);
        if (rightLedgeRaycastHit.collider == null) direction = -1; 

        // Left wall check
        leftWallRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, raycastLength, raycastLayerMask);
        if (leftWallRaycastHit.collider != null) direction = 1;

        // Right wall check
        rightWallRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.right, raycastLength, raycastLayerMask);
        if (rightWallRaycastHit.collider != null) direction = -1;
    }

    private void DetermineDirection()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject)
        {
            Player.instance.TakeDamage(attackPower);
            UIManager.instance.UpdateHealthBar();
        }
    }
}
