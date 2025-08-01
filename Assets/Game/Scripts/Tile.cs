using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int tileId;
    public int idSprite;
    public int row;
    public int column;
    public SpriteRenderer icon;
    private GameManager _manager;
    private Color defaultColor;
    public void Init(int tileId, int idSprite, int r, int c, Sprite spr, GameManager manager)
    {
        this.tileId = tileId;
        this.idSprite = idSprite;
        row = r;
        column = c;
        icon.sprite = spr;
        _manager = manager;
        defaultColor = Color.white;

    }

    public void Select(bool isSelected)
    {
        icon.color = isSelected ? Color.yellow : defaultColor;
    }

    public void Remove()
    {
        Destroy(gameObject);
        Debug.Log("Destroy tile");
    }
}
