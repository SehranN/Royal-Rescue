using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead : MonoBehaviour
{
    public Transform respawn;
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if (other.tag == "Player")
        {
            if (this.tag == "limit")
            {
                player.transform.position = respawn.position;
                player.GetComponent<EthanTheHero.PlayerAttackMethod>().Health = 100f;
            }
            else
            {
                if (player.GetComponent<EthanTheHero.PlayerAttackMethod>().Health > 0f)
                {
                    player.GetComponent<Animator>().Play("Hurt");
                    player.GetComponent<EthanTheHero.PlayerAttackMethod>().Health -= 25f;
                }
                else
                {
                    player.transform.position = respawn.position;
                    player.GetComponent<EthanTheHero.PlayerAttackMethod>().Health = 100f;
                }
            }
            
            
        }
    }
}
