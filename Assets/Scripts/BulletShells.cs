using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletShells : MonoBehaviour
{
    public  Rigidbody2D rigidbody2D;
    private Vector3 lastDir;
    private bool isRebound=false;
    void Start()
    {

        float x = Random.Range(-50, -70);
        float y = Random.Range(80, 120);
        if (GameManger.Instance.GetCurPoint() == Vector2.left)
        {
            x = -x;
        }

        rigidbody2D.AddForce(new Vector2(x,y));
    }

    private void LateUpdate()
    {
        lastDir = rigidbody2D.velocity;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isRebound == false) {
            isRebound = true;
            if (collision.gameObject.tag == "Wall")
            {
                Vector3 reflexAngle = Vector3.Reflect(lastDir, collision.contacts[0].normal);
                rigidbody2D.velocity = reflexAngle.normalized * lastDir.magnitude;
            }
        }
    }


}
