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
    private IDisplay _display;
    private Level _level;
    private List<GameObject> _createdWorld;

    public GameMaker(int rowCount, int rowWidth, int groundFrom, int groundTo,
                     ILevelGenerator levelGenerator, IGameRules gameRules, IDisplay display)
    {
        _rowCount = rowCount;
        _rowWidth = rowWidth;
        _groundFrom = groundFrom;
        _groundTo = groundTo;
        _display = display;

        _levelGenerator = levelGenerator;
        _gameRules = gameRules;

        Debug.Log("New game, GameMaker was initialised.");
    }

    public void LoadTheLevel()
    {
        Debug.Log("Creating a pretty order of wonderful cubes");
        
        _level = _levelGenerator.Generate(_rowWidth, _groundFrom, _groundTo);
    }

    public void Display()
    {
       _createdWorld = _display.CreateWorld(_level);
    }

    public List<GameObject> GetCreatedWorldObjects()
    {
        if (_createdWorld == null)
            throw new NullReferenceException("There is no created objects! Display() first!");
        
        return _createdWorld;
    }
}

public interface IDisplay
{
    List<GameObject> CreateWorld(Level level);
}

public interface ILevelGenerator
{
    Level Generate(int rowWidth, int groundFrom, int groundTo);
}

public interface IGameRules
{
}

public class SimpleGameRules : IGameRules
{
    
}