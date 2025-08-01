using EasyButtons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{

    public ShapeBlock shapeBlockPre;

    void Start()
    {
        GenShape();
    }

    [Button("Generate Shape")]
    public void GenShape()
    {
        var patternList = BlockLibary.blockPatterns;
        int[,] randomPattern = patternList[Random.Range(0, patternList.Count)];
        ShapeBlock newBlock = Instantiate(shapeBlockPre, transform.position, Quaternion.identity);
        newBlock.GenarateFromPattern(randomPattern);
        newBlock.SetPattern(randomPattern);

    }
}
