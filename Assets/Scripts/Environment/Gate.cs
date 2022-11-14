using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private string requiredKey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (InventoryManager.instance.HasInventoryItem(requiredKey))
            {
                Destroy(gameObject);
                InventoryManager.instance.RemoveInventoryItem(requiredKey);
            }
            else
            {
                Debug.Log("You don't have the key needed to open this gate");
            }
        }
    }
}
