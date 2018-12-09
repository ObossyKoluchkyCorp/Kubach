using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameMaker
{
    private int _rowCount;
    private int _rowWidth;
    private int _groundFrom;
    private int _groundTo;
    private ILevelGenerator _levelGenerator;
    private IGameRules _gameRules;
    private IWorldCreator _worldCreator;
    private Level _level;
    private List<GameObject> _createdWorld;
    private GameObject _player;

    public GameMaker(int rowCount, int rowWidth, int groundFrom, int groundTo, GameObject player,
                     ILevelGenerator levelGenerator, IGameRules gameRules, IWorldCreator worldCreator)
    {
        _rowCount = rowCount;
        _rowWidth = rowWidth;
        _groundFrom = groundFrom;
        _groundTo = groundTo;
        _worldCreator = worldCreator;
        _player = player;

        _levelGenerator = levelGenerator;
        _gameRules = gameRules;

        Debug.Log("New game, GameMaker constructor.");
    }

    public void LoadTheLevel()
    {
        Debug.Log("GameMaker, LoadTheLevel()");
        
        _level = _levelGenerator.Generate(_rowWidth, _groundFrom, _groundTo);
    }

    public void InitializeTheWorld()
    {
       _createdWorld = _worldCreator.CreateWorld(_level);
    }

    public void UpdateTheWorld()
    {
        _createdWorld = _worldCreator.UpdateTheWorld(_level, _createdWorld);
    }
        
    public List<GameObject> GetCreatedWorldObjects()
    {
        if (_createdWorld == null)
            throw new NullReferenceException("There is no created objects! Display() first!");
        
        return _createdWorld;
    }

    public bool CheckGameOver()
    {
        return _gameRules.CheckGameOver(_player, _createdWorld);
    }

    public bool ShouldTheWorldBeUpdated()
    {
        
        return false;
    }
}

public interface IWorldCreator
{
    List<GameObject> CreateWorld(Level level);
    List<GameObject> UpdateTheWorld(Level level, List<GameObject> createdWorld);
}

public interface ILevelGenerator
{
    Level Generate(int rowWidth, int groundFrom, int groundTo);
}

public interface IGameRules
{
    bool CheckGameOver(GameObject player, List<GameObject> createdWorld);
}