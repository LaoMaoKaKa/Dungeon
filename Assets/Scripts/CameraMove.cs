using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;                        //player
    private float lookValue = 0.5f;                //往前看的值
    private float lookAtSwitchSpeed = 3;     //切换视角的移动速度
    private float xLookAt =0;                       //正在看的值
    private bool isLookAtLeft=false;            //是否往左看
    private Vector3 CameraMovePoint;        //相机移动的位置

    private float shakeValue = 0.15f;
    private float shakeTime = 0.03f;
    private float shakeDoTime = 5;
    private bool isShake=false;
    private float xs = 0;
    private float ys = 0;
    private int shakeIndex= 0;

    private float tagXs =0;
    private float tagYs = 0;

    private float desTime = 0.7f;

    void Start()
    {
    }

    void Update()
    {
        if (GameManger.Instance.GetDeathState() == true) {
            desTime-= Time.deltaTime;
            if (desTime <= 0) { 
            transform.GetComponent<CameraMove>().enabled = false;
            }
        }

        ChangeLook();

        float x = player.position.x;
        float y = player.position.y;
        float z = transform.position.z;
        x += xLookAt;

        Shake(ref x,ref y);
        CameraMovePoint.Set(x, y,z);
        transform.position = CameraMovePoint;

    }

    private void Shake(ref float x, ref float y) {
        if (isShake)
        {
            shakeDoTime += Time.deltaTime;
            if (shakeDoTime > shakeTime) {
                GetRanShakePoint(shakeIndex);
                shakeIndex++;
                shakeDoTime = 0;
                if (shakeIndex == 2) {
                    isShake=false ;
                    shakeIndex = 0;
                }
            }
            xs += tagXs * Time.deltaTime;
            ys += tagYs * Time.deltaTime;
            x += xs;
            y += ys;
        }
    }

    public void GetRanShakePoint(int index) {
        tagXs = 0;
        tagYs = 0;
        if (index%2!=0) {
            tagXs = Random.Range(-shakeValue, shakeValue);
            tagYs = Random.Range(-shakeValue, shakeValue);
        }
    }


    public void ShakeDo() {
        if (isShake == true) {
            return;
        }
        isShake = true;
        shakeIndex = 0;
    }

    void ChangeLook() {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isLookAtLeft = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isLookAtLeft = false;
        }
        if (isLookAtLeft == true && xLookAt >= -lookValue)
        {
            xLookAt -= lookAtSwitchSpeed * Time.deltaTime;
        }
        else if (isLookAtLeft == false && xLookAt <= lookValue)
        {
            xLookAt += lookAtSwitchSpeed * Time.deltaTime;
        }
    }

}
