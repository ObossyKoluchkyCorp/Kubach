using System.Collections.Generic;
using UnityEngine;

class StupidDisplay : IDisplay
{
    public List<GameObject> CreateWorld(Level level)
    {
        Debug.Log("StupidDisplay is operational!");

        var createdObjects = new List<GameObject>(); 
        
        //создаём объекты, идём по рядам
        for (var i = 0; i < 10; i++)
        {
            //дёргаем каждый ряд из ранее сгенерированного уровня 
            foreach (var o in level.GetRow(i))
            {
                var scale = new Vector3(0.9f, 0.9f, 0.9f);
                var position = new Vector3(o.x, o.y, o.z);
                
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                cube.transform.localScale = scale;

                cube.transform.position = position;
                
                createdObjects.Add(cube);
            }    
        }
        
        Debug.Log("StupidDisplay is done!");

        return createdObjects;
    }
}