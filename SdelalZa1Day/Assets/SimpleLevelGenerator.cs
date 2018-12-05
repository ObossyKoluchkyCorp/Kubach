using System.Collections.Generic;
using UnityEngine;

public class SimpleLevelGenerator : ILevelGenerator
{
    public Level Generate(int rowWidth, int groundFrom, int groundTo)
    {
        var level = new Level();
        const int levelSize = 100;
        var objectsCollection = new List<LevelObject>();
        var xShift = 0 - rowWidth / 2;

        Debug.Log("SimpleLevelGenerator. Start to generate the simple level.");
        
        
        for (var z = 0; z < levelSize; z++)
        {
            for (var x = 0; x < rowWidth; x++)
            {
                for (var y = groundFrom; y < groundTo; y++)
                {
                    var levelObject = new LevelObject(x + xShift, y, z, true);
                    
                    objectsCollection.Add(levelObject);                    
                }
            }
        }
        
        level.SetLevel(objectsCollection);
        
        Debug.Log("Level generation has completed!");
        
        return level;
    }
}