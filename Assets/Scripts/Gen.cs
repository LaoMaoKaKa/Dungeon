using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen : MonoBehaviour
{
    public GameObject bullets;
    private float attackCD = 0.1f;
    private float waitTime = 5;
    public GameObject bulletsParent;
    public GameObject bulletShellsParent;
    public Transform pool;
    public GameObject bulletShells;
    public GameObject GenObj;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            if (waitTime >= attackCD)
            {
                GameObject obj = Instantiate<GameObject>(bullets, bulletsParent.transform);
                obj.transform.SetParent(pool);

                obj = Instantiate<GameObject>(bulletShells, bulletShellsParent.transform);
                obj.transform.SetParent(pool);

                GameManger.Instance.ShakeDo();
                waitTime = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            GenObj.transform.localPosition = new Vector3(-0.03f, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.X)) {
            GenObj.transform.localPosition = new Vector3(-0.03f, 0, 0);
        }

        if (waitTime < attackCD) {
            waitTime += Time.deltaTime;
        }
    }

}
