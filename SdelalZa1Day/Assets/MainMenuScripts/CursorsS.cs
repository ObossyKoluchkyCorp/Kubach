using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorsS : MonoBehaviour // Скрипт для изменения цвета курсора в таргет зоне 
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public AudioClip ButtonAud;

    public AudioSource Audios;


    void Start()
    {

        Audios.clip = ButtonAud;
    }
    void OnMouseEnter()
    {
        Audios.Play();
    }

    void OnMouseOver()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);

    }


    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);

    }
}