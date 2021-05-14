using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject score;
    public void Inventory()
    {
        SceneManager.LoadScene(2);
    }

    public void BackInventory()
    {
        SceneManager.LoadScene(1);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Score()
    {
        score.SetActive(true);
    }

    public void BackScore()
    {
        score.SetActive(false);
    }
}
