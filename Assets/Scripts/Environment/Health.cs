using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IPickUp
{
    [SerializeField] private int pickUpSize = 25;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject)
        {
            if (Player.instance.GetCurrentHealth() < Player.instance.maxHealth)
            {
                Collect();
                Destroy(gameObject);
            }
        }
    }

    public void Collect()
    {
        Player.instance.Heal(pickUpSize);
        UIManager.instance.UpdateHealthBar();
    }
}
