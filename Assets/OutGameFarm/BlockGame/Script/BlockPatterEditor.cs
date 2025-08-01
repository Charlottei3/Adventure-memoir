using System.IO;
using UnityEditor;
using UnityEngine;

public class BlockPatterEditor : EditorWindow
{
    private const int gridSize = 5;
    private const float cellSize = 30f;
    private bool[,] pattern = new bool[gridSize, gridSize];
    private GameObject unitBlockPrefab;
    private string blockName = "NewBlock";

    [MenuItem("Tools/Block Pattern Editor")]
    public static void ShowWindow()
    {
        GetWindow<BlockPatterEditor>("Block Pattern Editor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Block Generator Tool", EditorStyles.boldLabel);

        unitBlockPrefab = (GameObject)EditorGUILayout.ObjectField("Unit Block Prefab", unitBlockPrefab, typeof(GameObject), false);
        blockName = EditorGUILayout.TextField("Block Name", blockName);

        GUILayout.Space(10);
        DrawGrid();

        GUILayout.Space(10);
        if (GUILayout.Button("Generate Block Prefab"))
        {
            GenerateBlockPrefab();
        }

        if (GUILayout.Button("Clear"))
        {
            pattern = new bool[gridSize, gridSize];
        }
    }

    private void DrawGrid()
    {
        for (int y = 0; y < gridSize; y++)
        {
            GUILayout.BeginHorizontal();
            for (int x = 0; x < gridSize; x++)
            {
                Color oldColor = GUI.backgroundColor;
                GUI.backgroundColor = pattern[y, x] ? Color.green : Color.gray;

                if (GUILayout.Button("", GUILayout.Width(cellSize), GUILayout.Height(cellSize)))
                {
                    pattern[y, x] = !pattern[y, x];
                }

                GUI.backgroundColor = oldColor;
            }
            GUILayout.EndHorizontal();
        }
    }

    private void GenerateBlockPrefab()
    {
        if (unitBlockPrefab == null)
        {
            Debug.LogError("Please assign a Unit Block Prefab.");
            return;
        }

        GameObject blockRoot = new GameObject(blockName);

        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                if (pattern[y, x])
                {
                    Vector2 position = new Vector2(x, -y);
                    GameObject block = (GameObject)PrefabUtility.InstantiatePrefab(unitBlockPrefab);
                    block.transform.SetParent(blockRoot.transform);
                    block.transform.localPosition = position;
                }
            }
        }

        // Save prefab
        string path = $"Assets/Prefabs/Blocks/{blockName}.prefab";
        if (!Directory.Exists("Assets/Prefabs/Blocks"))
            Directory.CreateDirectory("Assets/Prefabs/Blocks");

        PrefabUtility.SaveAsPrefabAsset(blockRoot, path);
        DestroyImmediate(blockRoot);

        Debug.Log($"✅ Block prefab saved to {path}");
    }
}
