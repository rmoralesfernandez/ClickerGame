using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MonsterGen : MonoBehaviour
{
    public GameObject[] monsters;
    private int death = 0;
    public int number;
    public Transform Spawn;
    [SerializeField]
    private Text numberOfMonster;
    private int monsterCount = 1;
    public static int monstersDefeat = 1;
    public static int monsterLife = 20;
    public Text rewardText;
    public AudioSource enemyDeath;

    private void Start()
    {
        numberOfMonster.text = monsterCount.ToString();
        number = Random.Range(0, 5);
        Instantiate(monsters[number], Spawn);
        rewardText.text = Monsters.rewards.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Monsters.life == death && monsterCount <= 10)
        {
            StartCoroutine(MonsterGeneration());
        }
        if (monsterCount > 10)
        {
            monsterLife *= 2;
            Monsters.life = monsterLife;
            Monsters.rewards *= 2;
            monsterCount = 1;
            numberOfMonster.text = monsterCount.ToString();
            rewardText.text = Monsters.rewards.ToString();
        }
    }

    IEnumerator MonsterGeneration()
    {
        Monsters.life = monsterLife;
        enemyDeath.Play();
        yield return new WaitForSeconds(1);
        monsterCount++;
        numberOfMonster.text = monsterCount.ToString();
        number = Random.Range(0, 5);
        Instantiate(monsters[number], Spawn);
        monstersDefeat++;
        
    }
}
