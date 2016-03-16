using UnityEngine;
using System.Collections;
using System;

public class Map : MonoBehaviour {
    private const float TILEWIDTH= 0.64f;
    private const float TILEHEIGHT = 0.64f;
    public const uint GRIDSIZEX = 35;
    public const uint GRIDSIZEY = 17;

    public Vector2 startPos;

    public void Update()
    {
        for (uint x_ = 0; x_ < GRIDSIZEX; x_++)
        {
            for (uint y_ = 0; y_ < GRIDSIZEY; y_++)
            {
                float x = startPos.x + x_ * TILEWIDTH;
                float y = startPos.y + y_ * TILEWIDTH;

                Color color = (_grid[x_, y_] & TileAtt.Passable) == TileAtt.Passable ? Color.green : Color.red;

                Debug.DrawLine(new Vector3(x, y, 0), new Vector3(x + TILEWIDTH, y, 0), color);
                Debug.DrawLine(new Vector3(x, y, 0), new Vector3(x, y + TILEHEIGHT, 0), color);
                Debug.DrawLine(new Vector3(x + TILEWIDTH, y, 0), new Vector3(x + TILEWIDTH, y + TILEHEIGHT, 0), color);
                Debug.DrawLine(new Vector3(x, y + TILEHEIGHT, 0), new Vector3(x + TILEWIDTH, y + TILEHEIGHT, 0), color);
            }
        }
    }

    private TileAtt[,] _grid= new TileAtt[GRIDSIZEX,GRIDSIZEY];
    public void Start()
    {
        Vector3 minPoint = GetComponent<SpriteRenderer>().bounds.min;
        startPos = new Vector2(minPoint.x,minPoint.y);
        for(uint x = 0; x < GRIDSIZEX; x++)
        {
            for(uint y = 0; y < GRIDSIZEY; y++)
            {
                if (y == 3 || y == 4 || y == 7 || y == 8 || y == 11 || y == 12 || y == 13)
                {
                    _grid[x, y] |= TileAtt.Passable;
                }
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
    