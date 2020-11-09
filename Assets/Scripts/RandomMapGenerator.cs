using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomMapGenerator : MonoBehaviour
{

    int mapSizeX = 30;
    int mapSizeY = 25;
    int curPosX;
	int curPosY;
    int obstacleChance = 5;

    public Grid grid;
    public Tilemap floorMap;
    public Tilemap obstacleMap;  

    public TileBase[] floor;
    public TileBase[] obstacle;

    void Awake()
    {
        curPosX = Mathf.RoundToInt(transform.position.x);
		curPosY = Mathf.RoundToInt(transform.position.y);
    }

    public void GenerateNewMap()
    {
        floorMap.ClearAllTiles();
        obstacleMap.ClearAllTiles();

        for(int x = -mapSizeX; x <= mapSizeX; x++)
        {
            for(int y = -mapSizeY; y <= mapSizeY; y++)
            {
                Vector3Int pos = new Vector3Int(curPosX + x, curPosY + y, 0);

				floorMap.SetTile(pos, floor[Random.Range(0, floor.Length)]);

                int z = Random.Range(0,55);
                //Trees, rocks, etc
                if(z <= obstacleChance)
                {
                    obstacleMap.SetTile(pos, obstacle[Random.Range(0, obstacle.Length)]);
                }
            }
        }
    } 
}
