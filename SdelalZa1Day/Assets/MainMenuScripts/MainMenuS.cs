using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuS : MonoBehaviour {

    [Header("Настройки (Главного меню):")]
    [SerializeField] public GameObject PlayB;
    [SerializeField] public GameObject OptionsB;
    [SerializeField] public GameObject DevelopersB;
    [SerializeField] public GameObject ExitB;

    [Header("Настройки (Внутри настройк):")]
    [SerializeField] public GameObject PanelS;
    [SerializeField] public Dropdown DropDown;
    [SerializeField] public Dropdown DropGrafics;
    [SerializeField] bool isFullScreen;  

    public void Play()//Запуск главной сцены (1).
    {
        Debug.Log("Проверка запуска мейн сцены");
        SceneManager.LoadScene(1);
    }

    public void Settings()//При нажатии на кнопку Settings включается панель с настройками
    {
        PlayB.SetActive(false);
        OptionsB.SetActive(false);
        DevelopersB.SetActive(false);
        ExitB.SetActive(false);
        PanelS.SetActive(true);
    }

    public void DropD()//Настройки разрешения экрана
    {
        if (DropDown.value == 0)
        {
            Screen.SetResolution(1920, 1080, true);
        }

        if (DropDown.value == 1)
        {
            Screen.SetResolution(1680, 1050, true);
        }

        if (DropDown.value == 2)
        {
            Screen.SetResolution(1600, 1200, true);
        }

        if (DropDown.value == 3)
        {
            Screen.SetResolution(1600, 1024, true);
        }

        if (DropDown.value == 4)
        {
            Screen.SetResolution(1600, 900, true);
        }
    }

    public void FullScreenToggle()//Фулл скрин вкл выкл
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void DropDownS()
    {
        if (DropDown.value == 0)//При нажатии на кнопку Hight Quality будет пременина максимальная графика, а также при запуске игры я собераюсь убрать настройки
        {
            QualitySettings.SetQualityLevel(5, true);
        }

        if (DropDown.value == 1)
        {
            QualitySettings.SetQualityLevel(4, true);
        }

        if (DropDown.value == 1)
        {
            QualitySettings.SetQualityLevel(3, true);
        }

        if (DropDown.value == 2)
        {
            QualitySettings.SetQualityLevel(2, true);
        }
    }

    public void Apply()//При нажатии на кнопку Apply выключается панель с настройками и включается главное меню
    {
        PlayB.SetActive(true);
        OptionsB.SetActive(true);
        DevelopersB.SetActive(true);
        ExitB.SetActive(true);
        PanelS.SetActive(false);
    }

    public void Developers()//При нажатии на кнопку Developers
    {

    }

    public void Exit() //Выход из игры.
    {
        Application.Quit();
    }
}
