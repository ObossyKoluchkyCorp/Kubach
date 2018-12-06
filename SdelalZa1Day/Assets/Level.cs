using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

//уровень создавать будет отдельный тип классов ILevelGenerator, а сам Level это удобное хранилище, схема уровня
//сам уровень на сцене в юнити будем рисовать опять же в классе GameMaker, беря информацию отсюда
public class Level
{
    private List<LevelObject> _objectsCollection;
        
    public List<LevelObject> GetRow(int rowNumber)
    {
        var result = new List<LevelObject>();
        
        if (_objectsCollection == null)
            throw new ArgumentNullException("Collection cant be null!");

        foreach (var o in _objectsCollection)
        {
            if (o.z == rowNumber)
            {
                result.Add(o);
            }
        }

        return result;
    }
    
    //не работает
    public List<LevelObject> GetRowStackLike()
    {
        var result = new List<LevelObject>();
        
        if (_objectsCollection == null)
            throw new ArgumentNullException("Collection cant be null!");

        var lastRow = _objectsCollection.Min(o => o.z);
        
        foreach (var o in _objectsCollection)
        {
            if (o.z == lastRow)
            {
                result.Add(o);
            }
        }

        foreach (var o in result)
        {
            _objectsCollection.Remove(o);
        }

        return result;
    }
    
    public void SetLevel(List<LevelObject> levelObjectCollection)
    {
        if (_objectsCollection != null)
            throw new Exception("Can't set the level what was already set!");

        _objectsCollection = levelObjectCollection;
    }

    //ydolit
//    public static LevelObject GetObject(int x, int y, int z, List<LevelObject> someWorld)
//    {
//        foreach (var o in someWorld)
//        {
//            if (o.y == y && o.x == x && o.z == z)
//                return o;
//        }
//
//        return null;
//    }
}