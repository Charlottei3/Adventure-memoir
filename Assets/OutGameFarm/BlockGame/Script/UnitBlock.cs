using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBlock : MonoBehaviour
{
    private SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        if (spr == null)
        {
            Debug.LogError("SpriteRenderer component not found on UnitBlock.");
        }
    }

    public void SetColor(Color color)
    {
        if (spr != null)
        {
            spr.color = color;
        }
        else
        {
            Debug.LogError("SpriteRenderer is not initialized.");
        }
    }
}
