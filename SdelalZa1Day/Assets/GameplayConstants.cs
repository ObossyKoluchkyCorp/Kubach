using UnityEngine;
using UnityEditor;

public class GameplayConstants : MonoBehaviour
{
    //ширина ряда кубов задаётся тут!
    public const int rowWidth = 5;
    
    //видимое количество рядов
    public const int rowCount = 10;
    
    //ограничение по высоте, от
    public const int groundFrom = 0;
    
    //ограничение по высоте, до
    public const int groundTo = 3;
}