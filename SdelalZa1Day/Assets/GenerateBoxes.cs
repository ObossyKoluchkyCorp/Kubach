using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateBoxes : MonoBehaviour {

    public GameObject Cube;
    public Text score;

    // Use this for initialization
    void Start () {
        Debug.Log("init of GenerateBoxes.cs");


        for (int y = 0; y < 3; y++)
        {
            for (int x = -2; x < 3; x++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                cube.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);

                //cube.AddComponent<Rigidbody>();

                cube.transform.position = new Vector3(x, y, 3);
            }
        }
    }

    // Update is called once per frame
    void Update () {
        score.text = string.Format(" benis");
    }
}
