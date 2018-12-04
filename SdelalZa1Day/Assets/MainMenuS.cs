using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuS : MonoBehaviour {

    [Header("Настройки новой игры:")]
    [SerializeField] public GameObject PalyB;
    [SerializeField] public GameObject ExitB;

	
	void Update ()
    {
		
	}


    public void Play()
    {
        Debug.Log("Проверка запуска мейн сцены");
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
