using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public int index;
    public string levelName;

    void OnTriggerEnter2D(Collider2D other)
    {
            SceneManager.LoadScene(index);
            SceneManager.LoadScene(levelName);
    }
}