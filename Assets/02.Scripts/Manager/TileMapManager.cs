using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapManager
{
    private Tilemap _floorMap;
    private Tilemap _collisionMap;

    public static TileMapManager Instance; //싱글톤으로 사용할 예정

    public TileMapManager(Transform tileMapParent)
    {
        _floorMap = tileMapParent.Find("Floor").GetComponent<Tilemap>();
        _collisionMap = tileMapParent.Find("Collisions").GetComponent<Tilemap>();

        _floorMap.CompressBounds();
    }

    public bool CanMove(Vector3Int pos)
    {
        BoundsInt mapBound = _floorMap.cellBounds;
        //맵 바깥을 나가는 좌표를 요청한거다.
        if (pos.x < mapBound.xMin || pos.x > mapBound.xMax
            || pos.y < mapBound.yMin || pos.y > mapBound.yMax)
        {
            return false;
        }

        return _collisionMap.GetTile(pos) == null;
    }

    public Vector3Int GetTilePos(Vector3 worldPos)
    {
        return _floorMap.WorldToCell(worldPos); //이건월드좌표 넣으면 타일맵 셀좌표
    }

    public Vector3 GetWorldPos(Vector3Int cellPos)
    {
        return _floorMap.GetCellCenterWorld(cellPos);
        //셀에 중심점을 리턴한다.
    }
}