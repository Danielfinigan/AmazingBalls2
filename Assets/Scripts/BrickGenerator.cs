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
        Debug.Log("Bricks Left: " + bricks.Count);
        if (bricks.Count == 0)
            GameManager.Instance.YouWon();
    }

    public void buildLevel()
    {
        //y = 2 : 14    x = -40 : 40
        for(int y = 2; y < 3; y += 2)
        {
            for (int x = -5; x < 6; x += 5)
            {
                AddBrick(x, y);
            }
        }
    }
}
