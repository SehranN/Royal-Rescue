using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject dial1;
    public GameObject dial2;
    public GameObject dial3;
    public DialougeManager dm;
    public Animator bossAnim;
    public Animator kingAnim;

    // Start is called before the first frame update


    void Start()
    {
        StartCoroutine(king());
        bossAnim.SetFloat("Health", 1f);
    }

    IEnumerator king()
    {
        yield return new WaitForSecondsRealtime(2f);
        dial1.GetComponent<DialougeTrigger>().dialougeTrigger();
    }

    private void Update()
    {
        if (dm.ending == 1){

            bossAnim.SetLayerWeight(0, 0f);
            bossAnim.SetLayerWeight(1, 1f);
            bossAnim.SetFloat("Speed", 1f);

            bossAnim.Play("movement1", 1);
            

            dial2.GetComponent<DialougeTrigger>().dialougeTrigger();
            dm.ending = 2;
        }

        if (dm.ending == 3)
        {
            bossAnim.Play("attack");
            kingAnim.Play("Death", 0);
            dm.ending = 4;
        }

        if (dm.ending == 4)
        {
            dial3.GetComponent<DialougeTrigger>().dialougeTrigger();
            dm.ending = 5;
        }

        if (dm.ending == 6)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }
}
