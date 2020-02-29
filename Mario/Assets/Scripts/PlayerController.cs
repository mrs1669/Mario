using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private RectTransform player;
    private int playerX, playerY; // プレイヤのX座標,Y座標 左下が(0,0)
    private int groundY;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<RectTransform>();
        playerX = 300;
        playerY = 300;
        groundY = Mathf.FloorToInt(GetComponent<RectTransform>().sizeDelta.y)/2;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            playerX += 3;
        }
        else
        {
            if(player.position.y > groundY)
            {
                playerX += 2;
                playerY += -2;
                if (playerY <= groundY)
                {
                    playerY = groundY;
                }
            }
        }

        this.transform.position = new Vector3(playerX, playerY, 0);

        Debug.Log(player.position.y);
    }
}
