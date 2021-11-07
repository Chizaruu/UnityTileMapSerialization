using UnityEngine;

namespace UTMS.Map
{
    /// <summary> A tile in the world. </summary>
    public class WorldTile
    {
        public string tileBase; // The base tile name.
        public Vector3Int localPlace; // The local place of the tile.
        public Vector3 gridLocation; // The grid location of the tile.
    }
}

