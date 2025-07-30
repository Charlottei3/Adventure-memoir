using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FogTitleManager : MonoBehaviour
{
    public Tilemap fogTileMap;
    public Tile FogTile;
    public Transform player;

    public int revealRadius = 5;
    public float fadeSpeed = 3f;

    // Start is called before the first frame update
    private Dictionary<Vector3Int, float> tileAlphaMap = new Dictionary<Vector3Int, float>(); // Tracks alpha values of tiles
    private HashSet<Vector3Int> allFogTiles = new HashSet<Vector3Int>(); // All fog tiles

    void Start()
    {
        InitializeFog();
    }

    void Update()
    {
        UpdateFogOfWar();
    }

    private void InitializeFog()
    {
        // Initialize fog tiles across the entire tilemap bounds
        BoundsInt bounds = fogTileMap.cellBounds;
        for (int x = -15; x <= 15; x++)
        {
            for (int y = bounds.yMin; y <= bounds.yMax; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                if (fogTileMap.HasTile(pos)) // Only add fog to existing tiles
                {
                    fogTileMap.SetTile(pos, FogTile);
                    fogTileMap.SetColor(pos, new Color(0, 0, 0, 1f)); // Fully opaque
                    tileAlphaMap[pos] = 1f; // Start with full alpha
                    allFogTiles.Add(pos);
                }
            }
        }
    }

    private void UpdateFogOfWar()
    {
        Vector3Int playerTilePos = fogTileMap.WorldToCell(player.position); // Get player's tile position
        HashSet<Vector3Int> visibleTiles = new HashSet<Vector3Int>();

        // Calculate visible tiles within the reveal radius
        for (int x = -revealRadius; x <= revealRadius; x++)
        {
            for (int y = -revealRadius; y <= revealRadius; y++)
            {
                Vector3Int pos = new Vector3Int(playerTilePos.x + x, playerTilePos.y + y, 0);
                if (Vector3.Distance(fogTileMap.CellToWorld(pos), player.position) <= revealRadius)
                {
                    visibleTiles.Add(pos);
                }
            }
        }

        // Update fog alpha for all tiles
        foreach (var pos in allFogTiles)
        {
            float targetAlpha = visibleTiles.Contains(pos) ? 0f : 1f; // Visible tiles have alpha 0, others have alpha 1
            float currentAlpha = tileAlphaMap[pos];
            float newAlpha = Mathf.MoveTowards(currentAlpha, targetAlpha, Time.deltaTime * fadeSpeed); // Smooth transition
            tileAlphaMap[pos] = newAlpha;

            fogTileMap.SetColor(pos, new Color(0, 0, 0, newAlpha)); // Update tile color
        }
    }
}
