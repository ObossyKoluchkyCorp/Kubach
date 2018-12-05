using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateBoxes : MonoBehaviour {

    public GameObject Cube;
    public Text score;
    public GameMaker gameMaker;
    public List<GameObject> world;

    // Use this for initialization
    void Start () {
        Debug.Log("init of GenerateBoxes.cs");

        gameMaker = new GameMaker(  GameplayConstants.rowCount,
                                    GameplayConstants.rowWidth,
                                    GameplayConstants.groundFrom,
                                    GameplayConstants.groundTo,
                                    new SimpleLevelGenerator(),
                                    new SimpleGameRules(),
                                    new StupidDisplay()            );
        
        gameMaker.LoadTheLevel();
        
        gameMaker.Display();

        world = gameMaker.GetCreatedWorldObjects();
        
    }

    // Update is called once per frame
    void Update () {
        score.text = string.Format(" benis");

        //по идее тут должны крутиться только кубы, но почему-то крутится игрок тоже, разберусь позже
        foreach (var o in world)
        {
            o.transform.Rotate(Vector3.right);
        }
    }
}