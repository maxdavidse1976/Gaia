using UnityEngine;

public class InventoryItem : MonoBehaviour, IPickUp
{
    public enum InventoryType
    {
        key,
        gemKey,
        hat,
        pants,
        armor,
        weapon,
        potion,
        boots,
        bracers
    }
    [SerializeField] private InventoryType type;
    [SerializeField] private Sprite inventorySprite;
    [SerializeField] private string inventoryName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
