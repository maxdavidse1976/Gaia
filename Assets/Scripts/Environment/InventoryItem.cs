using UnityEngine;

public partial class InventoryItem : MonoBehaviour, IPickUp
{
    [SerializeField] private InventoryType type;
    [SerializeField] private Sprite inventorySprite;
    [SerializeField] private string inventoryName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject)
        {
            Collect();
            Destroy(gameObject);
        }
    }

    public void Collect()
    {
        Player.instance.PickupInventoryItem(inventoryName, inventorySprite);
    }

    public InventoryType GetInventoryType()
    {
        return type;
    }
}
