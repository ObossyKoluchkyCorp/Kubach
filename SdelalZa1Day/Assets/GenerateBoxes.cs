using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateBoxes : MonoBehaviour {

    public GameObject Cube;
    public GameObject Player;
    
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
                                    Player,
                                    new SimpleLevelGenerator(),
                                    new SimpleGameRules(),
                                    new StupidDisplay()            );
        
        gameMaker.LoadTheLevel();
        
        gameMaker.InitializeTheWorld();

        world = gameMaker.GetCreatedWorldObjects();
        
    }

    // Update is called once per frame
    void Update () {
        score.text = string.Format(" benis");

//        gameMaker.UpdateTheWorld();
        
        world = gameMaker.GetCreatedWorldObjects();
        
        foreach (var o in world)
        {
            o.transform.position += Vector3.back * GameplayConstants.GameSpeedMultiplier;
        }

        gameMaker.CheckGameOver();
    }
}