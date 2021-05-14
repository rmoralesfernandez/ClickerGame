using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Items : MonoBehaviour
{
    Scene scene;
    public static int coins = 120;
    [SerializeField]
    private Text numberOfCoins;
    [SerializeField]
    private Text numberOfSwords;
    [SerializeField]
    private Text numberOfDamage;
    [SerializeField]
    private Text numberOfMonsters;
    public static int swords = 1;
    public static bool useSwords = false;

    // Update is called once per frame
    void Update()
    {
        numberOfCoins.text = coins.ToString();
        string levelName = Application.loadedLevelName;

        if (levelName == "Inventory")
        {
            numberOfSwords.text = swords.ToString();
        }

        if(levelName == "Menu")
        {
            numberOfDamage.text = PlayerController.damage.ToString();
            numberOfSwords.text = swords.ToString();
            numberOfMonsters.text = MonsterGen.monstersDefeat.ToString();
        }
    }

    public void SelectSword()
    {
        swords--;
        numberOfSwords.text = swords.ToString();
        useSwords = true;
    }
}
