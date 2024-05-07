using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{

    public GameObject nameText;
    public GameObject dialougeText;
    public Animator animator;
    private Queue<string> names;
    private Queue<string> sentences;
    public int ending = 0;
    // Start is called before the first frame update
    void Start()
    {
        names = new Queue<string>();
        sentences = new Queue<string>();
    }

    public void startDialouge(Dialouge[] dialouges)
    {
        names.Clear();
        sentences.Clear();

        animator.SetBool("isOpen", true);
        

        foreach(Dialouge dialouge in dialouges)
        {
            names.Enqueue(dialouge.name);
            sentences.Enqueue(dialouge.sentence);
        }

        displayNextSentence();
    }

    public void displayNextSentence()
    {
        if(sentences.Count == 0)
        {
            endDialouge();
        }
        string name = names.Dequeue();
        string sentence = sentences.Dequeue();
        nameText.GetComponent<TextMeshProUGUI>().text = name;
        dialougeText.GetComponent<TextMeshProUGUI>().text = sentence;
    }

    public void endDialouge()
    {
        animator.SetBool("isOpen", false);
        ending += 1;
        Debug.Log("End of conversation");
    }


}
