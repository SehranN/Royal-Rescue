using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
