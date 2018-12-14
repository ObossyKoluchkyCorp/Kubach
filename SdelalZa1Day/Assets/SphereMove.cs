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

    private int _yborderfrom = GameplayConstants.groundFrom;
    private int _yborderto = GameplayConstants.groundTo;

    void Start ()
    {

	}
	

	void Update ()
    {
        Spher = GetComponent<Rigidbody>();
        Spher.constraints = RigidbodyConstraints.FreezePositionZ; //Фризим позицию на z 

        //check is the game over, and if it is, don't go any further
        if (GameplayConstants.isGameOver) return;
        
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
        return AbsoluteNumber(inputPosition.x) < (float) _xborder / 2
               && inputPosition.y >= _yborderfrom
               && inputPosition.y <= _yborderto;
    }

    private static float AbsoluteNumber(float inputNumber)
    {
        return inputNumber > 0 ? inputNumber : 0 - inputNumber;
    }
}
