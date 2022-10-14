using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFront : MonoBehaviour
{

    private int count = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            count++;
            GameManger.Instance.SetIsTriggerEnterFront(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            count--;
            if (count == 0) {
                GameManger.Instance.SetIsTriggerEnterFront(false);
            }
        }
    }
}
