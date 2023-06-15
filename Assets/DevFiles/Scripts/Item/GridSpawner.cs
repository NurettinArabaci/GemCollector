using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    
    [Tooltip("X: column, Y: row")]
    [SerializeField] private Vector2Int tileDimensions = new Vector2Int(2, 2);

    [SerializeField] Color tileColor = new Color(0.8f, 0.2f, 0.9f, 0.9f);

    public int row { get { return tileDimensions.y; } }
    public int column { get { return tileDimensions.x; } }

    [SerializeField] private Vector2 tileSize = new Vector2(1, 1);

    [SerializeField] Mesh tileMesh;

    private void Start()
    {
        InstantiateItem();
    }

    private void OnDrawGizmos()
    {
        
        DrawGridInEditor();
    }

    private void InstantiateItem()
    {
        for (int y = 0; y < row; y++)
            for (int x = 0; x < column; x++)
            {
                Vector3 pos = transform.position + new Vector3(
                    (x - ((float)column / 2) + 0.5f) * tileSize.x,
                    0.5f,
                    (y - ((float)row / 2) + 0.5f) * tileSize.y
                    );

                ItemSpawnManager.Instance.GetRandomItem(pos, transform);

            }
    }

    private void DrawGridInEditor()
    {
        if (tileMesh is null)
        {
            tileMesh = Resources.Load<Mesh>("GridMesh/Gem_Mesh");
        }

        for (int y = 0; y < row; y++)
            for (int x = 0; x < column; x++)
            {
                Vector3 pos = transform.position + new Vector3(
                    (x - ((float)column / 2) + 0.5f) * tileSize.x,
                    0.5f,
                    (y - ((float)row / 2) + 0.5f) * tileSize.y
                    );


                Gizmos.color = tileColor;
                Gizmos.DrawMesh(tileMesh, pos, Quaternion.identity, new Vector3(tileSize.x, 1f, tileSize.y) * 0.95f);
            }
    }
}
