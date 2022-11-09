using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private TextMeshProUGUI coinsCollectedText;
    [SerializeField] private Image healthBar;
    private Vector2 healthBarOriginalSize;
    [SerializeField] private Image inventoryItemImage;
    [SerializeField] private Sprite inventoryItemDefault;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        healthBarOriginalSize = healthBar.rectTransform.sizeDelta;
        UpdateCoins();
        UpdateHealthBar();
        SetDefaultInventoryItemSprite();
    }

    private float GetHealthBarSize()
    {
        // Get current health percentage
        float healthBarPercentage = Player.instance.GetCurrentHealth() / Player.instance.maxHealth;
        return healthBarOriginalSize.x * healthBarPercentage;
    }

    public void UpdateCoins()
    {
        coinsCollectedText.text = Player.instance.GetCoinCount().ToString();
    }

    public void UpdateHealthBar()
    {
        healthBar.rectTransform.sizeDelta = new Vector2(GetHealthBarSize(), healthBar.rectTransform.sizeDelta.y);
    }

    public void SetDefaultInventoryItemSprite()
    {
        inventoryItemImage.sprite = inventoryItemDefault;
    }

    public void UpdateInventoryItemSprite(Sprite activeSprite)
    {
        inventoryItemImage.sprite = activeSprite;
    }

}
