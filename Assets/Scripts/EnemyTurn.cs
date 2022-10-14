using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    public Enemy enemy;
    private float waitTime = 0;
    private float y = 0;
    void Update()
    {
        if (waitTime > 0) {
            waitTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { if (collision.tag == "Wall"&& waitTime<=0)
        {
            waitTime = 0.5f;
            enemy.Turn();

             y += 180;
            transform.parent.rotation = Quaternion.Euler(0, y, 0);
        }
    }

}
