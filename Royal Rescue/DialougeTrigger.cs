using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{

    public Dialouge[] dialouge;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (FindObjectOfType<DialougeManager>().GetComponent<DialougeManager>().ending == 0 ||
                FindObjectOfType<DialougeManager>().GetComponent<DialougeManager>().ending == 2){

                FindObjectOfType<DialougeManager>().GetComponent<DialougeManager>().ending += 1;
                dialougeTrigger();

            }
            
        }
    }

        public void dialougeTrigger()
    {
        FindObjectOfType<DialougeManager>().startDialouge(dialouge);
    }

}
