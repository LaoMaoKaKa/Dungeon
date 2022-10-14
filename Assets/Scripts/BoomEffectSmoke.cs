using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoomEffectSmoke : MonoBehaviour
{
    private int index=0;

    private Vector3 startPoint;
    private float startMoveSpeed;
    private Vector3 endPoint;
    private float endScaleSpeed; //���������ٶ�
    private float waitTime = 0;     //�ڶ��׶εȴ�ʱ��
    private float rotaZ=0;             //Zֵ�ۼ�
    private float rotaSpeed=0;      //��ת�ٶ�
    void Start()
    {
        startPoint = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 1);
        endPoint = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 1);
        endScaleSpeed = Random.Range(0.01f, 0.05f);
        rotaSpeed = Random.Range(20, 50);
        startMoveSpeed= Random.Range(0.01f, 0.04f);
    }

    void Update()
    {
        //transform.rotation = Quaternion.Euler(0, 0, z);
        rotaZ += rotaSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler( 0, 0, rotaZ);
        if (index == 0)
        {
            transform.localScale += Vector3.one * 0.165f * Time.deltaTime;
            transform.position += startPoint * startMoveSpeed * Time.deltaTime;
            if (transform.localScale.x >= 0.75f)
            {
                index++;
            }
        }
        else if (index == 1) {
            waitTime+=Time.deltaTime;
            if (waitTime > 1.5f) {
                index++;
            }
        }
        else if (index == 2)
        {
            transform.localScale -= Vector3.one * 0.25f * Time.deltaTime;
            transform.position += endPoint * endScaleSpeed * Time.deltaTime;
            if (transform.localScale.x <= 0)
            {
                index++;
            }
        }

    }
}
