using System.Collections.Generic;
using UnityEngine;

public class SimpleDisplay : IWorldCreator
{
    
    public List<GameObject> CreateWorld(Level level)
    {
        //в юнити отображать уровень будем кусками, этот метод собственно и создаёт объекты на уровне
        
        //if it is the first exec
        Debug.Log("Create new game objects (cubes).");
        
        
        //else
        Debug.Log("Rewrite old objects with new ones (or delete it?)");

        return new List<GameObject>();
    }

    public List<GameObject> UpdateTheWorld(Level level, List<GameObject> createdWorld)
    {
        return new List<GameObject>();   
    }
}