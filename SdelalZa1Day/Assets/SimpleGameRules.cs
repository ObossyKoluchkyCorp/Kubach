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
                && o.transform.position.z > playerZcoordinate - 0.5f
                && (int) o.transform.position.x == (int) player.transform.position.x)
            {
                o.transform.position += Vector3.up;
                return true;
            }
        }
        
        return false;
    }
}