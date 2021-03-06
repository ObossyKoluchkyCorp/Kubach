﻿using UnityEngine;
using UnityEditor;

public class GameplayConstants : MonoBehaviour
{
    //ширина ряда кубов задаётся тут!
    public const int rowWidth = 5;
    
    //видимое количество рядов, пока что отказался от этой хуйни
    public const int rowCount = 10;
    
    //ограничение по высоте, от
    public const int groundFrom = 0;
    
    //ограничение по высоте, до
    public const int groundTo = 1;
    
    //размер уровня
    public const int levelSize = 100;
    
    //множитель скорости движения
    public const float GameSpeedMultiplier = 0.05f;

    //координата первого ряда
    public const int FirstRowZCoordinate = 10;
    
    public static bool isGameOver { get; private set; }

    public static void SetGameOver(bool inputBool)
    {
        isGameOver = inputBool;
    }
}