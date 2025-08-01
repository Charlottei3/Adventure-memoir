using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShapeBlock : MonoBehaviour
{
    public GameObject unitPrefab;
    public Vector2 sizeBlock = Vector2.one;

    int[,] shapePattern;

    public void SetPattern(int[,] pattern)
    {
        shapePattern = pattern;
    }

    public void GenarateFromPattern(int[,] pattern)
    {
        for (int x = 0; x < pattern.GetLength(0); x++)
        {
            for (int y = 0; y < pattern.GetLength(1); y++)
            {
                if (pattern[x, y] == 1)
                {
                    GameObject unit = Instantiate(unitPrefab, transform);
                    unit.GetComponent<UnitBlock>().SetColor(Random.ColorHSV());
                    unit.transform.position = new Vector2(x * sizeBlock.x, -y * sizeBlock.y);
                }
            }
        }
    }

}
