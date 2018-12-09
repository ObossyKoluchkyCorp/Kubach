using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Schema;
using UnityEngine;

public class SimpleLevelGenerator : ILevelGenerator
{
    private int _levelSize = GameplayConstants.levelSize;

    private bool isNextXLine;
    private bool isObstacle;
    private int xShift;
    private int xLineWidth;
    private int xLineLeftestPoint;
    private int maxZLineLength;
    private int zLineLength;
    private int zLineXCoordinate;
    private int xMax, yMax, zMax;
    
    public Level Generate(int rowWidth, int groundFrom, int groundTo)
    {
        xShift = 0 - rowWidth / 2;
        xLineWidth = rowWidth;
        
        var level = new Level();
        var objectsCollection = new List<LevelObject>();

        Debug.Log("SimpleLevelGenerator. Start to generate a simple level.");

        var path = MakeUpThePath(rowWidth, groundTo - groundFrom, _levelSize);
        
        for (var z = 0; z < _levelSize; z++)
        {
            for (var x = 0; x < rowWidth; x++)
            {
                for (var y = groundFrom; y < groundTo; y++)
                {                    
                    var levelObject = new LevelObject(x + xShift, y, z, path[x,y,z]);
                    
                    objectsCollection.Add(levelObject);                    
                }
            }
        }
        
        level.SetLevel(objectsCollection);
        
        Debug.Log("Level generation has completed!");
        
        return level;
    }

    private void AddSomeNoise(List<LevelObject> createdWorld, float coefficient)
    {
        //идём от первого ряда к последнему
        for (var z = 0; z < _levelSize; z++)
        {
            //так, пока что избыточный цикл, потом придумать как заоптимайзить
            foreach (var o in createdWorld)
            {
                if (o.z == z)
                {
                       if (o.obstacle)
                           o.SetObstacle(Random.Range(0,10) > 10*coefficient);
                }
            }
        }
    }

    public bool[,,] MakeUpThePath(int xMaxInput, int yMaxInput, int zMaxInput)
    {
        xMax = xMaxInput;
        yMax = yMaxInput;
        zMax = zMaxInput;
        
        var result = new bool[xMax, yMax, zMax];

        isNextXLine = false;
        xLineLeftestPoint = 0;
        maxZLineLength = 10;
        xLineWidth = xMax;
        zLineLength = -1;
        isObstacle = true;

        for (var z = 0; z < zMax; z++)
        {
            if (zLineLength < 0)
            {
                XCoordinateForZLine();

                zLineLength = Random.Range(2, maxZLineLength);
            }

            if (zLineLength == 0)
            {
                GenerateXLine();
            }
            
            for (var x = 0; x < xMax; x++)
            {
                for (var y = 0; y < yMax; y++)
                {
                    if (zLineLength == 0)
                    {
                        isObstacle = (x < xLineLeftestPoint || x > xLineLeftestPoint + xLineWidth);
                    }
                    else
                    {
                        isObstacle = (x != zLineXCoordinate);
                    }

                    result[x, y, z] = isObstacle;
                }
            }
            
            zLineLength -= 1;
        }
        
        return result;
    }

    private void XCoordinateForZLine()
    {
//        zLineXCoordinate = (zLineXCoordinate < xLineLeftestPoint) ? xLineLeftestPoint : xLineLeftestPoint + xLineWidth;

        var previousZLineXCoordinate = zLineXCoordinate;

        do
        {
            zLineXCoordinate = Random.Range(0, xMax);    
        } while (previousZLineXCoordinate == zLineXCoordinate);
    }

    private void GenerateXLine()
    {
//        xLineLeftestPoint = (zLineXCoordinate == xMax) ? Random.Range(0, xMax - 1) : Random.Range(0, xMax);
//                
//        xLineWidth = (zLineXCoordinate == xMax) ? xMax - xLineLeftestPoint :
//            (zLineXCoordinate < xLineLeftestPoint) ? xLineLeftestPoint - zLineLength : zLineLength - xLineLeftestPoint;
        
        xLineLeftestPoint = 0;

        xLineWidth = xMax;
    }
}