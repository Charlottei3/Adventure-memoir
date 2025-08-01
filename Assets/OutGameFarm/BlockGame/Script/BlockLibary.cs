using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BlockLibary
{
    public static List<int[,]> blockPatterns = new List<int[,]>
    {
        new int[,]
        {
            { 1, 1, 1, 1 },
            { 0, 0, 0, 0 },
        },

        new int[,]
        {
            { 1, 1 },
            { 1, 1 }
        },

        new int[,]
        {
            { 1, 1, 1 },
            { 0, 1, 0 }
        },

        new int[,]
        {
            { 1, 1, 1 },
            { 1, 0, 0 }
        },

        new int[,] {
            {1},
            {1},
            {1},
            {1}
        },

        new int[,] {
            {1, 0},
            {1, 0},
            {1, 1}
        },

        new int[,] {
            {1, 1, 0},
            {0, 1, 1}
        }
    };
}
