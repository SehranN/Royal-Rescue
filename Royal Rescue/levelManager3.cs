using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager3 : MonoBehaviour
{
    public Animator kingAnim;
    public GameObject dial3;
    public Animator flower;
    public DialougeManager dm;
    public GameObject dial1;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        kingAnim.Play("Death");
    }

    // Update is called once per frame
    void Update()
    {
        if(dm.ending == 4)
        {
            flower.Play("flower");
            dm.ending = 5;
        }

        if(dm.ending == 5)
        {
            kingAnim.speed = -1f;
            kingAnim.Play("Death");
            dial3.GetComponent<DialougeTrigger>().dialougeTrigger();

        }
        
    }
}
