using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class GameManager : MonoSingleton<GameManager>
{
    public int rows;
    public int cols;
    public int TypeCount = 12;//tryhard level
    public Tile tilePrefab;
    public Vector2 tileSize = Vector2.one;
    public Transform parentGrid;

    private Tile[,] grid;
    private List<Sprite> tileSprites;
    private Tile tileSelect1;
    private Tile tileSelect2;


    void LoadSprites()
    {
        //tileSprites = Resources.Load<Tile>("aa");
    }

    void GenarateMap()
    {
        grid = new Tile[rows, cols];
        int totalTiles = rows * cols;
        if (totalTiles % 2 != 0) totalTiles--;

        List<int> idSprites = new List<int>();
        for (int i = 0; i < totalTiles / 2; i++)
        {
            int id = Random.Range(0, TypeCount);
            idSprites.Add(id);
            idSprites.Add(id);
        }

        ShuffleUtility.FisherYatesShuffle(idSprites);

        Vector2 gridOffset = new Vector2(-(rows * tileSize.x) / 2, (cols * tileSize.y) / 2);
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                int idT = r * cols + c;
                if (idT > idSprites.Count) continue;

                Vector2 pos = new Vector2(c * tileSize.x, -r * tileSize.y) + gridOffset;
                Tile tile = Instantiate(tilePrefab, pos, Quaternion.identity);
                tile.transform.SetParent(parentGrid);
                tile.Init(idT, idSprites[idT], r, c, tileSprites[idSprites[idT]], this);
                grid[r, c] = tile;
            }
        }
    }

    public void OnCLickTile(Tile tile)
    {
        if (tileSelect1 != null && tile == tileSelect2) return;

        if (tileSelect1 == null)
        {
            tileSelect1 = tile;
            tile.Select(true);
        }
        else
        {
            if (tile.idSprite == tileSelect1.idSprite)
            {
                tile.Select(true);
                tileSelect2 = tile;

                CheckMatch();
            }
            else
            {
                tileSelect1.Select(false);
                tileSelect1 = tile;
                tile.Select(true);
            }
        }
    }

    #region logic

    public void CheckMatch()
    {
        if (tileSelect1 != null && tileSelect2 != null && tileSelect1.idSprite == tileSelect2.idSprite)
        {
            // TODO: check if connectable logic (pathfinding)
            if (CanConnect(tileSelect1, tileSelect2))
            {
                grid[tileSelect1.row, tileSelect1.column] = null;
                grid[tileSelect2.row, tileSelect2.column] = null;
                tileSelect1.Remove();
                tileSelect2.Remove();

                if (IsWin())
                {
                    Debug.Log("🎉 You Win!");
                }
            }
            else
            {
                tileSelect1.Select(false);
                tileSelect2.Select(false);
            }
        }
        else
        {
            if (tileSelect1 != null) tileSelect1.Select(false);
            if (tileSelect2 != null) tileSelect2.Select(false);
        }
        tileSelect1 = null;
        tileSelect2 = null;
    }

    bool CanConnect(Tile a, Tile b)
    {
        return CanConnectStraight(a, b) || CanConnectOneTurn(a, b) || CanConnectTwoTurns(a, b);
    }

    private bool CanConnectStraight(Tile a, Tile b)
    {
        if (a.row == b.row)
        {
            int min = Mathf.Min(a.column, b.column);
            int max = Mathf.Max(a.column, b.column);

            for (int i = min + 1; i < max; i++)
            {
                if (grid[a.row, i] != null)
                    return false;

                return true;
            }
        }

        if (a.column == b.column)
        {
            int min = Mathf.Min(a.row, b.row);
            int max = Mathf.Max(a.row, b.row);

            for (int i = min + 1; i < max; i++)
            {
                if (grid[a.column, i] != null)
                    return false;

                return true;
            }
        }
        return false;
    }

    private bool CanConnectOneTurn(Tile a, Tile b)
    {
        if (grid[a.row, b.column] == null && CanConnectStraight(a, grid[a.row, b.column] = new Tile { row = a.row, column = b.column }) && CanConnectStraight(b, grid[a.row, b.column]))
        {
            grid[a.row, b.column] = null;
            return true;
        }

        if (grid[b.row, a.column] == null && CanConnectStraight(a, grid[b.row, a.column] = new Tile { row = b.row, column = a.column }) && CanConnectStraight(b, grid[b.row, a.column]))
        {
            grid[b.row, a.column] = null;
            return true;
        }

        return false;
    }

    private bool CanConnectTwoTurns(Tile a, Tile b)
    {
        for (int r = 0; r < rows; r++)
        {
            if (r == a.row) continue;
            Tile mid1 = new Tile { row = r, column = a.column };
            Tile mid2 = new Tile { row = r, column = b.column };

            if (grid[r, a.column] == null && grid[r, b.column] == null)
            {
                if (CanConnectStraight(a, mid1) && CanConnectStraight(mid1, mid2) && CanConnectStraight(mid2, b))
                    return true;
            }
        }

        for (int c = 0; c < cols; c++)
        {
            if (c == a.column) continue;
            Tile mid1 = new Tile { row = a.row, column = c };
            Tile mid2 = new Tile { row = b.row, column = c };
            if (grid[a.row, c] == null && grid[b.row, c] == null)
                if (CanConnectStraight(a, mid1) && CanConnectStraight(mid1, mid2) && CanConnectStraight(mid2, b))
                    return true;
        }

        return false;
    }

    #endregion

    bool IsWin()
    {
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                if (grid[r, c] != null) return false;
        return true;
    }

}
