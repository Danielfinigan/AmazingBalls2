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

    public void buildLevel()
    {
        for(int y = -1; y < 26; y += 2)
        {
            for (int x = -40; x < 41; x += 5)
            {
                AddBrick(x, y);
            }
        }
    }
}
