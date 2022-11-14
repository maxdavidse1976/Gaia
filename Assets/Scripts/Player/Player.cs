using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int coinsCollected;
    public static Player instance;
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float jumpStrength = 10;
    public float maxHealth = 100;
    [SerializeField] private float currentHealth = 0;

    private bool canDoubleJump = false;

    [SerializeField] private Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();
    [SerializeField] private Sprite keySprite;

    private bool isGrounded = false;
    [SerializeField] private GroundCheck groundCheck = null;

    private float inputX;

    public bool grounded
    {
        get
        {
            if (groundCheck != null) 
            {
                Debug.Log("We have a ground Check");
                return groundCheck.CheckGrounded();
            }
            return false;
        }
    }

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
        rigidBody.velocity = new Vector2(inputX * moveSpeed, rigidBody.velocity.y);

        //if (Input.GetButtonDown("Jump") && grounded)
        //{
        //    canDoubleJump = true;
        //    velocity.y = jumpStrength;
        //}
        //else if (Input.GetButtonDown("Jump") && canDoubleJump)
        //{
        //    canDoubleJump=false;
        //    velocity.y = jumpStrength;
        //}

    }

    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Is my player Grounded" + grounded);
        if (context.performed && grounded)
        {
            canDoubleJump = true;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpStrength);
        }
        else if (context.performed && canDoubleJump) 
        { 
            canDoubleJump = false;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpStrength);
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
