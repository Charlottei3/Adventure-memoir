using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShuffleUtility
{
    // Hàm dùng để trộn danh sách theo thuật toán Fisher-Yates
    public static void FisherYatesShuffle<T>(List<T> list)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1); // Random.Range trong Unity: [min, max)
            (list[i], list[j]) = (list[j], list[i]); // Hoán đổi
        }
    }
}
