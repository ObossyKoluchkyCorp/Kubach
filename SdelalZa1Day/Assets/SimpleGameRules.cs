using System.Collections.Generic;
using UnityEngine;

public class SimpleGameRules : IGameRules
{
    public bool CheckGameOver(GameObject player, List<GameObject> createdWorld)
    {
        var playerZcoordinate = player.transform.position.z;
        
        foreach (var o in createdWorld)
        {
            if (o.transform.position.z < playerZcoordinate + 0.5f
                && o.transform.position.z > playerZcoordinate - 0.5f)
                o.transform.position += Vector3.up;
        }
        
        return false;
    }
}