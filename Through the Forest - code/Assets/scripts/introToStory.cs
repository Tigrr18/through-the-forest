using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introToStory : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
}
