using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Volume : MonoBehaviour // В итоге должен получиться мейн контролер звука во всей игре
{
    [Header("Слайдер:")]
    [SerializeField] public Slider slider;
    [Header("Кнопки в Меню:")]
    [SerializeField] public AudioSource ButPlay;
    [SerializeField] public AudioSource ButTutorial;
    [SerializeField] public AudioSource ButOptions;
    [SerializeField] public AudioSource ButDevelopers;
    [SerializeField] public AudioSource ButExit;
    [Header("Кнопки в Настройках:")]
    [SerializeField] public AudioSource ButApply;
    [SerializeField] public AudioSource DropdownResolution;
    [SerializeField] public AudioSource DropdownVeryHighGrafics;
    [SerializeField] public AudioSource ButFullScrean;
    [SerializeField] public AudioSource TargetObjSound;
    [SerializeField] public AudioSource TargetObjMusic;

    void Update()
    {
        // Кнопки в меню --->
        ButPlay.volume = slider.value / 1;
        ButTutorial.volume = slider.value / 1;
        ButOptions.volume = slider.value / 1;
        ButDevelopers.volume = slider.value / 1;
        ButExit.volume = slider.value / 1;
        // Кнопки в Настройках --->
        ButApply.volume = slider.value / 1;
        DropdownResolution.volume = slider.value / 1;
        DropdownVeryHighGrafics.volume = slider.value / 1;
        ButFullScrean.volume = slider.value / 1;
        TargetObjSound.volume = slider.value / 1;
        TargetObjMusic.volume = slider.value / 1;
    }
}