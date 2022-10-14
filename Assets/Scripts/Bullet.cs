using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 tagPoint;
    private float speed = 8f;
    private bool isInit = false;
    private int aggressivity = 25;
    public GameObject effect;
    private new Vector3 tag;
    private Vector2 playPoint;
    void Start()
    {
        float z = UnityEngine.Random.Range(-100, 100)/10;
        z = transform.rotation.z + z;
        transform.rotation = Quaternion.Euler(0, 0, z);

        tag = transform.right;
        playPoint = GameManger.Instance.GetCurPoint();
        if (playPoint == Vector2.left)
        {
            tag = -tag;
        }
        SetTagPoint(tag);
    }

    void Update()
    {
        if (isInit == false)
            return;
        transform.position += tagPoint * speed * Time.deltaTime;
    }

    public void SetTagPoint(Vector3 tagPo) {
        tagPoint = tagPo;
        isInit = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().Hurt(aggressivity, playPoint);
            Destroy(gameObject);
        }
        else if (collision.tag == "Wall") {
            GameObject obj= Instantiate<GameObject>(effect, transform);
            obj.transform.SetParent(transform.parent.parent);
            float z = 0;
            if (playPoint== Vector2.left) {
                z = 180;
            }
            obj.transform.rotation=Quaternion.Euler(0, 0, z);
            obj.SetActive(true);
            Destroy(gameObject);
        }
    }

}
