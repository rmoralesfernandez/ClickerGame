using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monsters : MonoBehaviour
{
    public static int life = 20;
    private GameObject enemy;
    [SerializeField]
    private GameObject particleMove = null;
    public static int rewards = 2;
    private GameObject playerAnim;
    private Animator anim;

    private void Start()
    {
        playerAnim = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
    private void Update()
    {
        if(life <= 0)
        {
            Destroy(enemy);
            Instantiate(particleMove, transform.position, Quaternion.identity);
            Items.coins = Items.coins + rewards;
            anim = playerAnim.GetComponent<Animator>();
            anim.SetBool("MonsterGrounded", false);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            anim = playerAnim.GetComponent<Animator>();
            anim.SetBool("MonsterGrounded", true);
        }
    }
}
