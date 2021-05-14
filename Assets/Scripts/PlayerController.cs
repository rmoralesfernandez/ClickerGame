using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
    public Transform Spawn;
    [SerializeField]
    private GameObject particleMove = null;
    public static int damage = 1;
    [SerializeField]
    private Text monsterLifeText;
    [SerializeField]
    private Text damageText;
    public float counter = 20;
    public static int originalDamage;
    public GameObject counterObject;
    public Text counterText;
    public int swordMoves = 10;
    public GameObject counterSwordObject;
    public Text counterSwordText;
    public AudioSource punch;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        monsterLifeText.text = Monsters.life.ToString();
        originalDamage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerAnim.GetBool("MonsterGrounded") == true)
        {
            playerAnim.SetBool("touching", false);
            Instantiate(particleMove, Spawn.position , Quaternion.identity);
            Monsters.life = Monsters.life - damage;
            punch.Play();
            if(Items.useSwords == true)
            {
                swordMoves--;
            }
            if(Monsters.life < 0)
            {
                Monsters.life = 0;
            }
           // monsterLifeText.text = Monsters.life.ToString();
        } else
        {
            playerAnim.SetBool("touching", true);
        }


        if (Shop.poison == true)
        {
            damage = Shop.poisonDamage;
            counterObject.SetActive(true);
            counter -= Time.deltaTime;
            counterText.text = counter.ToString("f1");

            if(counter <= 0)
            {
                counterObject.SetActive(false);
                damage = originalDamage;
                Shop.poison = false;
            }
        }

        if(Items.useSwords == true)
        {
            if (swordMoves > 0)
            {
                damage = Monsters.life;
                counterSwordObject.SetActive(true);
                counterSwordText.text = swordMoves.ToString();
            }
            else
            {
                swordMoves = 10;
                counterSwordObject.SetActive(false);
                damage = originalDamage;
                Items.useSwords = false;
            }
        }

        monsterLifeText.text = Monsters.life.ToString();
        damageText.text = damage.ToString();
    }
}
