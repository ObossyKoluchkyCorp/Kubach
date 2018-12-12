using System.Collections.Generic;
using UnityEngine;

public class SimpleGameRules : IGameRules
{
    private GameObject _theObject;
    
    public bool CheckGameOver(GameObject player, List<GameObject> createdWorld)
    {
        if (!DoesPlayerCollidesWithTheLevel(player, createdWorld)) return false;
        
        _theObject.transform.position += Vector3.up;

        //the way to delete objects from the scene
//        GameObject.Destroy(_theObject, 0.1f);
        
        return true;

    }

    private bool DoesPlayerCollidesWithTheLevel(GameObject player, List<GameObject> createdWorld)
    {
        var observError = 0.5f;

        foreach (var o in createdWorld)
        {
            if (o.transform.position.z < player.transform.position.z + observError
                && o.transform.position.z > player.transform.position.z - observError
                && (int) o.transform.position.x == (int) player.transform.position.x)
            {
                _theObject = o;
                return true;
            }
        }

        return false;
    }
}