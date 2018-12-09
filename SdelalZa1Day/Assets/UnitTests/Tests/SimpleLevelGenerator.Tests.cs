using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

    [TestFixture]
    public class SimpleLevelGenerator_Tests
    {
        [Test]
        public void MakeUpThePath_GenerateLevelWithSimplePath_PlayerActuallyCouldPassThePath()
        {
            var level = new SimpleLevelGenerator();
            var path = level.MakeUpThePath(5, 1, 30);

            //general test that we have at least one way in the row
            for (var z = 0; z < 30; z++)
            {
                var isThereTheWay = false;
                for (var x = 0; x < 5; x++)
                {
                    if (!(path[x, 0, z]))
                        isThereTheWay = true;
                }
                
                Assert.That(isThereTheWay, Is.True);
            }
        }
        
//        public bool 
    }
