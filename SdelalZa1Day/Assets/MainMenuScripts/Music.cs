using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Music : MonoBehaviour //Тоже самое что и в скрипте Volume тоже - фпс
{

    [Header("Слайдер:")]
    [SerializeField] public Slider slider;
    [Header("Музыка на камере:")]
    [SerializeField] public AudioSource MainCamera;

    void Update()
    {
        MainCamera.volume = slider.value / 1;
    }
}
