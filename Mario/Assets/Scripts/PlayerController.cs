using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private RectTransform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.position += new Vector3(0, 3, 0);
        }
        else
        {
            if(player.position.y > 0)
            {
                this.transform.position += new Vector3(-2, -2, 0);
                if(player.position.y <= 0)
                {
                    player.transform.position = new Vector3(0, 0);
                }
            }
        }

        Debug.Log(player.position.x);
    }
}
