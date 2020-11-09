using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;

public class GameTiles : MonoBehaviour {

	public string folderName;

	public Tilemap floorMap;
    public Tilemap obstacleMap;

	public Dictionary<Vector3, WorldTile> tiles;

	public List<WorldTile> saveTiles;

	public bool save;

	WorldTile tile;

	public void GetWorldTiles (Tilemap tileMap, bool save) 
	{
        saveTiles = new List<WorldTile>();

        foreach (Vector3Int pos in tileMap.cellBounds.allPositionsWithin)
		{
			var lPos = new Vector3Int(pos.x, pos.y, pos.z);

            if (!tileMap.HasTile(lPos)) continue;

			WorldTile _tile = new WorldTile()
            {
				localPlace = lPos,
                gridLocation = tileMap.CellToWorld(lPos),
				tileBase = tileMap.GetTile(lPos),
				isVisible = false,
				isExplored = false,
			};
				
			if(save)
			{
				saveTiles.Add(_tile);
			}
			else
			{
				tiles.Add(_tile.gridLocation, _tile);
			}   
		}
		
		if(save)
		{
			TileMapDataSystem.Save(tileMap.name, "Map", saveTiles);
		}
	}

	public void LoadWorldTiles (){
		floorMap.ClearAllTiles();
		saveTiles = TileMapDataSystem.Load(floorMap.name, "Map");
		SetWorldTiles(floorMap, "Floor");
		obstacleMap.ClearAllTiles();
		saveTiles = TileMapDataSystem.Load(obstacleMap.name, "Map");
		SetWorldTiles(obstacleMap, "Obstacle");
	}

	public void SetWorldTiles (Tilemap tileMap, string folderName){
		
		tiles = new Dictionary<Vector3, WorldTile>();

		string path = Path.Combine("Tilemap", folderName);

		Tile[] tileAsset = Resources.LoadAll<Tile>(path);

		Color grey = new Color(1.0f, 1.0f, 1.0f, 0.5f);

		Color black = new Color(1.0f, 1.0f, 1.0f, 1.0f);

		foreach(WorldTile tile in saveTiles)
		{

			for(int i = 0; i <= tileAsset.Length; i++)
			{
				if(tileAsset[i] == tile.tileBase)
				{
					tileMap.SetTile(tile.localPlace, tileAsset[i]);
					i = tileAsset.Length;
				}
			}

			WorldTile _tile = new WorldTile()
			{
				localPlace = tile.localPlace,
				gridLocation = tile.gridLocation,
				tileBase = tile.tileBase,
				isVisible = tile.isVisible,
				isExplored = tile.isExplored,
			};
			tiles.Add(_tile.gridLocation, _tile);
		}
		Resources.UnloadUnusedAssets();
	}
}
