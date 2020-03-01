using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private RectTransform player;
    private int playerX, playerY; // プレイヤーのX座標,Y座標 左下が(0,0)
    private int playerDy; // プレイヤーのY座標加速度
    private int playerWidth, playerHeight;
    private int groundY; // プレイヤーの高さを考慮した地面の座標設定
    private int jumpFlag = 0;
    public AudioSource marioJumpSound;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<RectTransform>();
        playerX = 300;
        playerY = 300;
        playerDy = 0;

        playerHeight = Mathf.FloorToInt(GetComponent<RectTransform>().sizeDelta.y);
        playerWidth = Mathf.FloorToInt(GetComponent<RectTransform>().sizeDelta.x);
        groundY = playerHeight / 2;
    }

    // Update is called once per frame
    void Update()
    {
        jumpFlag = PlayerJump(jumpFlag);
        //PlayerJump(jumpFlag);
        PlayerMove();

        this.transform.position = new Vector3(playerX, playerY, 0);

        Debug.Log(playerDy);
    }

    // プレイヤーのジャンプを操る関数
    public int PlayerJump(int jumpFlag)
    {
        if (Input.GetKey(KeyCode.Space) && jumpFlag == 0)
        {
            playerDy = 30;
            playerY += playerDy;
            jumpFlag = 1;
            marioJumpSound.Play();
        }
        else
        {
            if (player.position.y > groundY)
            {
                playerDy += -1;
                playerY += playerDy;
                if (playerY <= groundY)
                {
                    playerY = groundY;
                    playerDy = 0;
                    jumpFlag = 0;
                }
            }
        }
        return jumpFlag;
    }

    public void PlayerMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerX += -15;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerX += 15;
        }
        else
        {
            playerX += 0;
        }

        Crouching();
        

    }

    // しゃがみ機能関数
    public void Crouching()
    {
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(playerWidth, playerHeight / 2);
            groundY = Mathf.FloorToInt(GetComponent<RectTransform>().sizeDelta.y) / 2;
        }
        else
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(playerWidth, playerHeight);
            groundY = Mathf.FloorToInt(GetComponent<RectTransform>().sizeDelta.y) / 2;
            if (playerY < groundY)
            {
                playerY = groundY;
            }
        }
    }

}
