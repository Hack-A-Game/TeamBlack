using UnityEngine;
using System.Collections;
using System;

public class Map : MonoBehaviour {
    private const float TILEWIDTH= 0.64f;
    private const float TILEHEIGHT = 0.64f;
    public const uint GRIDSIZEX = 20;
    public const uint GRIDSIZEY = 10;

    public Vector2 startPos;

    private TileAtt[,] _grid= new TileAtt[GRIDSIZEX,GRIDSIZEY];
    public void Start()
    {
        Vector3 minPoint = GetComponent<SpriteRenderer>().bounds.min;
        startPos = new Vector2(minPoint.x,minPoint.y);
        for(uint x = 0; x < GRIDSIZEX; x++)
        {
            for(uint y = 0; y < GRIDSIZEY; y++)
            {
                _grid[x, y] |= TileAtt.Passable;
            }
        }
    }

    public gridPos ToGridPos(Vector2 pos)
    {
        float x = (pos.x - startPos.x) / TILEWIDTH;
        float y = (pos.y - startPos.y) / TILEHEIGHT;

        if (x < 0 || y < 0)
        {
            return new gridPos(-1, -1);
        }

        return new gridPos((int)(x), (int)(y));
    }

    public bool UnitCanMove(gridPos p, Direction d)
    {
        return canMove(p, d,TileAtt.Passable);
    }
    public Vector3 GridToWorld(int x, int y)
    {
        return new Vector3(startPos.x + x * TILEWIDTH, startPos.y + y * TILEHEIGHT, 0);
    }
    public bool hasFlag(gridPos p, TileAtt t)
    {
        return (_grid[p.x, p.y] & t) == t;
    }
    private bool canMove(gridPos p,Direction d,TileAtt flag)
    {
        switch (d)
        {
            case Direction.up:
                p.y += 1;
                break;

            case Direction.down:
                p.y -= 1;
                break;

            case Direction.left:
                p.x -= 1;
                break;

            case Direction.right:
                p.x += 1;
                break;
        }
        if (p.outOfBounds()) return false;
        return hasFlag(p, flag);
    }
}
public struct gridPos
{
    public gridPos(int x,int y)
    {
        this.x = x;
        this.y = y;
    }
    public bool outOfBounds()
    {
        return (x >= Map.GRIDSIZEX || x < 0 || y >= Map.GRIDSIZEY || y < 0);
    }
    public int x;
    public int y;
}
public enum Direction
{
    up,
    down,
    left,
    right
}
[Flags]
public enum TileAtt
{
    Passable = 0x1,
    canBuild = 0x2,
    canHurt = 0x3
}
    