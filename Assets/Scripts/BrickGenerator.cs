using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrickGenerator : MonoBehaviour {
    public static BrickGenerator Instance;
    public List<Brick> brickPrebabs = new List<Brick>();
    public List<Brick> bricks = new List<Brick>();

    private int _brickPicker = 0;
	
	// Update is called once per frame
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        buildLevel();
    }

    public void AddBrick(float xPos, float yPos)
    {
        Brick brick = (Brick)Instantiate(brickPrebabs[_brickPicker]);
        Vector2 spawnPosition = new Vector2(xPos, yPos);
        brick.transform.position = spawnPosition;
        bricks.Add(brick);
        _brickPicker = (_brickPicker + 1) % 3;
    }

    public void DeleteBrick(Collision2D brick)
    {
        bricks.Remove(bricks[0]);
        Destroy(brick.gameObject);
        if (bricks.Count == 0)
            GameManager.Instance.YouWon();
    }

    public void buildLevel()
    {
        int horizontalBricks = 25;
        int veritcalBricks = 8;
        //y = 2 : 14    x = -40 : 40
        for(int y = 0; y <= veritcalBricks; y += 2)
        {
            if (y < 5)
                horizontalBricks += 5;
            else
                horizontalBricks -= 5;
            for (int x = -horizontalBricks; x <= horizontalBricks; x += 5)
            {
                AddBrick(x, y);
            }
        }

        horizontalBricks = 25;
        veritcalBricks = 24;
        for (int y = 16; y <= veritcalBricks; y += 2)
        {
            if (y < 5)
                horizontalBricks += 5;
            else
                horizontalBricks -= 5;
            for (int x = -horizontalBricks; x <= horizontalBricks; x += 5)
            {
                AddBrick(x, y);
            }
        }
    }

    //have ball go through bricks while still destroying them
    //for bigger ball or fireball power
    public void BreakthroughBricks()
    {
        Debug.Log("Breakthrough");
        for(int i = 0; i < bricks.Count; i++)
        {
            bricks[i].GetComponent<Collider2D>().isTrigger = true; 
        }
    }
}
