using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : PhysicsObject
{
    private int coinsCollected;
    public static Player instance;
    private Rigidbody2D rigidBody;

    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float jumpStrength = 10;
    public float maxHealth = 100;
    [SerializeField] private float currentHealth = 0;

    private bool canDoubleJump = false;

    [SerializeField] private Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();
    [SerializeField] private Sprite keySprite;

    private void Awake()
    {
        instance = this;
        currentHealth = maxHealth;
    }

    void Start()
    {
    }

    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, 0);
        if (Input.GetButtonDown("Jump") && grounded)
        {
            canDoubleJump = true;
            velocity.y = jumpStrength;
        }
        else if (Input.GetButtonDown("Jump") && canDoubleJump)
        {
            canDoubleJump=false;
            velocity.y = jumpStrength;
        }

    }

    public int GetCoinCount()
    {
        return coinsCollected;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float PickupCoins(int pickupSize)
    {
        coinsCollected += pickupSize;
        return coinsCollected;
    }

    public float Heal(int amountToHeal)
    {
        if (currentHealth < maxHealth)
        {
            if (currentHealth + amountToHeal > maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth += amountToHeal;
            }
        }
        return currentHealth;
    }

    public void PickupInventoryItem(string inventoryName, Sprite inventorySprite)
    {
        InventoryManager.instance.AddInventoryItem(inventoryName, inventorySprite);
    }
}
