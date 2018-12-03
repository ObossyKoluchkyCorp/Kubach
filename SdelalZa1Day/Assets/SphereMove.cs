using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMove : MonoBehaviour
{

    [Header("MoveForTransform:")]
    [SerializeField] public float speed = 5f;
    [SerializeField] Rigidbody Spher;

    //граница по ширине
    private int _xborder = GameplayConstants.rowWidth; 

    void Start ()
    {

	}
	

	void Update ()
    {
        Spher = GetComponent<Rigidbody>();
        Spher.constraints = RigidbodyConstraints.FreezePositionZ; //Фризим позицию на z 


        if (Input.GetKeyDown(KeyCode.D)) 
        {
            //transform.position += Vector3.right * speed * Time.deltaTime;
            if (IsItNotBorder(transform.position + Vector3.right))
            {
                transform.position += Vector3.right;
            }
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (IsItNotBorder(transform.position + Vector3.left))
            {
                transform.position += Vector3.left;
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (IsItNotBorder(transform.position + Vector3.up))
            {
                transform.position += Vector3.up;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
           if (IsItNotBorder(transform.position + Vector3.down))
           {
                transform.position += Vector3.down;
           }
        }
    }

    //передаём на этот метод новое положение игрока, и если это положение за границей, возвращает true
    private bool IsItNotBorder(Vector3 inputPosition)
    {
        
        if ( (inputPosition.x > 0 ? inputPosition.x : 0 - inputPosition.x) >  (float) _xborder / 2)
        {
            Debug.Log("border position!");

            return false;
        }

        return true;
    }
}
