using System.Collections.Generic;
using UnityEngine;

public class InfiniteWorldCreator : IWorldCreator
{
    private int startZcoordinate;
    private float _theBiggestZCoordinate;
    private float _coordinate = 10.0f;
    private Vector3 _scale = new Vector3(0.9f, 0.9f, 0.9f);
    
    //rewrite this please, Sasha!
    public List<GameObject> CreateWorld(Level level)
    {
        startZcoordinate = GameplayConstants.FirstRowZCoordinate;
        
        var createdObjects = CreateGameObjects(level);
        
        return createdObjects;
    }

    public List<GameObject> UpdateTheWorld(Level level, List<GameObject> createdWorld)
    {
        Debug.Log("Check if level ends.");
        
        if (DoesTheWorldEnds(createdWorld))
        {
            Debug.Log("Rows count is low! Generate new level and add to exist one.");

            startZcoordinate = (int) (_coordinate + 2.0f);

            var newObjects = CreateGameObjects(level);

            createdWorld.AddRange(newObjects);
            
            Debug.Log("Execute old objects collector.");
        
            Debug.Log("Delete objects that are out of player's sight.");
        }
        else
            Debug.Log("There is enough rows, continue...");
        
        return createdWorld;
    }

    private List<GameObject> CreateGameObjects(Level level)
    {
        Debug.Log("Create GameObjects...");

        var createdObjects = new List<GameObject>();
        
        for (var i = startZcoordinate; i < startZcoordinate + GameplayConstants.levelSize; i++)
        {
            foreach (var o in level.GetRow(i))
            {
                var position = new Vector3(o.x, o.y, i);

                if (!o.obstacle) continue;
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                cube.transform.localScale = _scale;
                cube.transform.position = position;

                createdObjects.Add(cube);
            }    
        }

        return createdObjects;
    }
    
    private bool DoesTheWorldEnds(List<GameObject> createdWorld)
    {
        float theBiggestZCoordinate = 0;
        
        //add it to level moving logic to optimise
        foreach (var o in createdWorld)
        {
            if (o.transform.position.z > theBiggestZCoordinate) theBiggestZCoordinate = o.transform.position.z;
        }

        
        return (theBiggestZCoordinate <= _coordinate);
    }
}