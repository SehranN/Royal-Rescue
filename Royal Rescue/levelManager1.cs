using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager1 : MonoBehaviour
{
    public GameObject beardedMan;
    public float speed = 4f;
    public Transform targetPosition;

    public DialougeManager dm;
    public GameObject dial1;
    public GameObject player;


    private void Start()
    {
        beardedMan.GetComponent<Animator>().Play("bearded-walk");
        beardedMan.GetComponent<Rigidbody2D>().freezeRotation = true;
        player.GetComponent<EthanTheHero.PlayerMovement>().enabled = false;
        //player.GetComponent<EthanTheHero.PlayerAttackMethod>().enabled = false;
        //player.GetComponent<EthanTheHero.PlayerAnimation>().enabled = false;
    }
    private void Update()
    {
        float distanceToTarget = Vector2.Distance(beardedMan.transform.position, targetPosition.position);

        // Check if the NPC is close enough to the target position
        if (Mathf.RoundToInt(distanceToTarget) > 0.9f)
        {
            beardedMan.transform.position = Vector2.MoveTowards(beardedMan.transform.position, targetPosition.position, speed * Time.deltaTime);
        }
        else
        {
            beardedMan.GetComponent<Animator>().Play("bearded-idle");
            if (dm.ending == 0)
            {
                dial1.GetComponent<DialougeTrigger>().dialougeTrigger();
                beardedMan.GetComponent<Collider2D>().enabled = false;
                beardedMan.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                dm.ending = 1;
            }
        }

        if (dm.ending == 2)
        {
            player.GetComponent<EthanTheHero.PlayerMovement>().enabled = true;

            dm.ending = 3;
        }

    }

}
