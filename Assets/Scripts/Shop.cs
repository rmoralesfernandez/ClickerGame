using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private Text moreDamage;
    public int newDamage;
    public int price = 20;
    [SerializeField]
    private Text priceText;
    [SerializeField]
    private Text pricePoisonText;
    [SerializeField]
    private Text poisonDamageText;
    [SerializeField]
    private Text priceSwordText;
    [SerializeField]
    private Text swordnDamageText;
    public int pricePoison = 50;
    public static int poisonDamage;
    public static bool poison = false;
    public int SwordPrice = 100;
    public int swordDamage = Monsters.life;
    public AudioSource buySound;

    private void Start()
    {
        priceText.text = price.ToString();
        pricePoisonText.text = pricePoison.ToString();
        priceSwordText.text = SwordPrice.ToString();
        swordnDamageText.text = swordDamage.ToString();
        poisonDamage = Monsters.life / 2;
        poisonDamageText.text = poisonDamage.ToString();

    }

    private void Update()
    {
        if(PlayerController.originalDamage >= poisonDamage / 2)
        {
            pricePoison = pricePoison * (pricePoison / 3);
            poisonDamage *= 2;
            pricePoisonText.text = pricePoison.ToString();
            poisonDamageText.text = poisonDamage.ToString();
        }
    }

    public void BuyDamage()
    {
        if(Items.coins >= price)
        {
            Items.coins = Items.coins - price;
            newDamage = PlayerController.damage;
            if (poison == true)
            {
                PlayerController.originalDamage *= 2;
            }
            else
            {
                PlayerController.damage *= 2;
                PlayerController.damage = PlayerController.originalDamage;
            }
            price *= 2;
            priceText.text = price.ToString();
            moreDamage.text = newDamage.ToString();

            buySound.Play();
        }
    }

    public void BuyPoison()
    {
        if(Items.coins >= pricePoison)
        {
            Items.coins = Items.coins - pricePoison;
            poison = true;
            buySound.Play();
        }
    }

    public void BuySword()
    {
        if(Items.coins >= SwordPrice)
        {
            Items.coins = Items.coins - SwordPrice;
            Items.swords++;
            buySound.Play();
        }
    }
}
