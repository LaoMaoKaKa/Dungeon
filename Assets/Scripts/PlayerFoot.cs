using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    private Player player;
    private float waitTime = 0.3f;
    private int aggressivity = 10;
    private void Start()
    {
        player=transform.parent.GetComponent<Player>();
    }

    private void Update()
    {
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && waitTime<=0)
        {
            waitTime = 0.3f;
            player.Jump(true);
            collision.GetComponent<Enemy>().Hurt(aggressivity);
        }
        else if(collision.tag=="Wall"){
            GameManger.Instance.SetJumpState(false);
        }
    }
}
