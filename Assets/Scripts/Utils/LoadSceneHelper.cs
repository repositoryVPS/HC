using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHelper : MonoBehaviour
{
    public void Load(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void Load(String i)
    {
        SceneManager.LoadScene(i);
    }
}
