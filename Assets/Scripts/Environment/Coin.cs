using System.Runtime.CompilerServices;
using UnityEngine;

public class Coin : MonoBehaviour, IPickUp
{
    public float coinsCollected;

    public static Coin instance;
    [SerializeField] private int pickUpAmount = 1;

    private void Awake()
    {
        instance = this;
    }

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
        Player.instance.PickupCoins(pickUpAmount);
        UIManager.instance.UpdateCoins();
    }
}
