using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScriptFuckGoBack : MonoBehaviour {

    void Start()
    {
        UnityEngine.Cursor.visible = false;
    }

    void Update () // Данный микро скрипт нужен для возращения в глав меню 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            UnityEngine.Cursor.visible = true;
        }
    }
}
