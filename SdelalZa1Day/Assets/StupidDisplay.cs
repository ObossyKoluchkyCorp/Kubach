using System.Collections.Generic;
using UnityEngine;

class StupidDisplay : IWorldCreator
{
    public int startZcoordinate;
    
    public List<GameObject> CreateWorld(Level level)
    {
        startZcoordinate = 10;
        
        Debug.Log("StupidDisplay is operational!");

        var createdObjects = new List<GameObject>();
        var scale = new Vector3(0.9f, 0.9f, 0.9f);

        Debug.Log("Create GameObjects...");

        for (var i = startZcoordinate; i < startZcoordinate + GameplayConstants.levelSize; i++)
        {
            foreach (var o in level.GetRow(i))
            {
                var position = new Vector3(o.x, o.y, i);

                if (!o.obstacle) continue;
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                cube.transform.localScale = scale;
                cube.transform.position = position;

                createdObjects.Add(cube);
            }    
        }
        
        Debug.Log("StupidDisplay is done!");

        return createdObjects;
    }
    
    public List<GameObject> UpdateTheWorld(Level level, List<GameObject> createdWorld)
    {
        var updatedWorld =  new List<GameObject>();
        var firstRow = GetFirstOrLastRow(createdWorld, true);
        var lastRow = GetFirstOrLastRow(createdWorld, false);
            
        if (firstRow < 0)
            RemoveRow(createdWorld, firstRow);
        
        if (lastRow < 10)
            AddRow(level, lastRow, createdWorld);
                
        return updatedWorld;
    }

    private float GetFirstOrLastRow(List<GameObject> createdWorld, bool returnFirst)
    {
        float minZ = 0, maxZ = 0;
        
        foreach (var o in createdWorld)
        {
            if (o.transform.position.z < minZ)
                minZ = o.transform.position.z;
            
            if (o.transform.position.z > maxZ)
                maxZ = o.transform.position.z;
        }

        return returnFirst ? minZ : maxZ;
    }
    
    private void AddRow(Level level, float rowCount, List<GameObject> createdWorld)
    {
        var scale = new Vector3(0.9f, 0.9f, 0.9f);
        foreach (var o in level.GetRow((int) rowCount))
        {
            var position = new Vector3(o.x, o.y, rowCount + 1);

            if (o.obstacle)
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                cube.transform.localScale = scale;

                cube.transform.position = position;

                createdWorld.Add(cube);
            }
        }   
    }

    private void RemoveRow(List<GameObject> createdWorld, float rowNumber)
    {
        foreach (var o in createdWorld)
        {
            if (o.transform.position.z == rowNumber)
                GameObject.Destroy(o);
        }
    }
}