using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{

    public int count = 50;
    public GameObject enemy;
    public Transform Point;
    public float cd = 1;
    // Update is called once per frame
    void Update()
    {
        cd -= Time.deltaTime;
        if (cd <= 0) {
            cd = 1;
            CreateEnemy();
        }
    }

    void CreateEnemy() {
        GameObject obj= Instantiate(enemy, transform);
        obj.transform.SetParent(Point);
        count--;
        if (count == 0) {
            Destroy(gameObject);
        }
    }
}
