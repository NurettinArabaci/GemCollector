using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{

    #region Serialized Variables
    [SerializeField] private Color tileColor = new Color(0.8f, 0.2f, 0.9f, 0.9f);
    [SerializeField] private Vector2 tileSize = new Vector2(1, 1);
    [SerializeField] private Mesh preItemMesh;

    [SerializeField] private TileFloor tileFloorPrefab;

    [Tooltip("X: column, Y: row")]
    [SerializeField] private Vector2Int tileDimensions = new Vector2Int(2, 2);
    #endregion

    #region Properties

    public int row { get { return tileDimensions.y; } }
    public int column { get { return tileDimensions.x; } }
    #endregion


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

                SpawnManager.Instance.GetRandomItem(pos, transform);

            }
    }

    private void DrawGridInEditor()
    {
        if (preItemMesh == null)
        {
            preItemMesh = Resources.Load<Mesh>("GridMesh/Gem_Mesh");
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
                Gizmos.DrawMesh(preItemMesh, pos, Quaternion.identity, new Vector3(tileSize.x, 1f, tileSize.y) * 0.95f);


            }
        GetTileFloor().transform.localScale = TileSize();

    }

    private TileFloor GetTileFloor()
    {

        tileFloorPrefab = tileFloorPrefab == null ? Resources.Load<TileFloor>("Meshes/TileFloorMesh") : tileFloorPrefab;

        if (!GetComponentInChildren<TileFloor>())
        {
            return Instantiate(tileFloorPrefab, transform.position + Vector3.up * 0.1f, Quaternion.identity, transform);
        }
        return GetComponentInChildren<TileFloor>();

    }

    Vector3 TileSize()
    {
        return new Vector3(column, 1, row) / 10;
    }
}
