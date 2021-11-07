using UnityEngine;
using UnityEngine.Tilemaps;

namespace UTMS.Map.Generator
{
    /// <summary> Generates a random map. </summary>
    public class RandomMapGenerator : MonoBehaviour
    {
        [SerializeField]private int mapSizeX = 30; // Map size in X axis
        [SerializeField]private int mapSizeY = 25; // Map size in Y axis
        [SerializeField]private int curPosX; // Current position in X axis
        [SerializeField]private int curPosY; // Current position in Y axis
        [SerializeField]private int obstacleChance = 5; // Chance of an obstacle

        [SerializeField]private TileBase[] floor; // Floor tiles
        [SerializeField]private TileBase[] obstacle; // Obstacle tiles

        /// <summary> Round current position. </summary>
        private void Awake()
        {
            curPosX = Mathf.RoundToInt(transform.position.x); // Round current position in X axis
            curPosY = Mathf.RoundToInt(transform.position.y); // Round current position in Y axis
        }
        /// <summary> Initialize map. </summary>
        private void Start()
        {
            GenerateNewMap(); 
        }

        /// <summary> Generate a new map. </summary>
        public void GenerateNewMap()
        {
            MapManager.instance.floorMap.ClearAllTiles(); // Clear floor map
            MapManager.instance.obstacleMap.ClearAllTiles(); // Clear obstacle map

            for(int x = -mapSizeX; x <= mapSizeX; x++)
            {
                for(int y = -mapSizeY; y <= mapSizeY; y++)
                {
                    Vector3Int pos = new Vector3Int(curPosX + x, curPosY + y, 0); // Current position

                    MapManager.instance.floorMap.SetTile(pos, floor[Random.Range(0, floor.Length)]); // Set floor tile

                    int z = Random.Range(0,55); // Random number

                    // If random number is less than obstacle chance then set obstacle tile
                    if(z <= obstacleChance)
                    {
                        MapManager.instance.obstacleMap.SetTile(pos, obstacle[Random.Range(0, obstacle.Length)]); // Set obstacle tile
                    }
                }
            }
        } 
    }
}

