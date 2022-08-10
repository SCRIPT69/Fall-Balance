using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    public void StartGame()
    {
        //logic of choosing a random level here, but now just loading the existing scene
        SceneManager.LoadScene(1);
    }
}
