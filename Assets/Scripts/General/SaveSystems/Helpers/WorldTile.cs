using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class WorldTile {
    public Vector3Int localPlace;

    public Vector3 gridLocation;

    public TileBase tileBase;

    public bool isExplored;

    public bool isVisible;
}
