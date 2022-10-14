using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//û�п�ܵĻ� ���ݾͱ��浽������� �����ȡ
public class GameManger : UnitySlingleton<GameManger>
{
    private Vector2 curPoint = Vector2.right; //player ����
    private bool isJump=false;    //��Ծ״̬
    private bool isDeath = false; 
    private bool isTriggerEnterFront = false;

    public CameraMove cameraMove;
    public void SetCurPoint(Vector2 point) {
        curPoint = point;
    }

    public void ShakeDo() {
        cameraMove.ShakeDo();
    }


    //player about

    public void SetDeathState(bool state) { 
        isDeath= state;  
    }
    public bool GetDeathState( )
    {
        return isDeath ;
    }

    public Vector2 GetCurPoint()
    {
        return curPoint;
    }

    public void SetJumpState(bool state) {
        isJump=state; 
    }

    public bool GetJumpState() {
        return isJump;
    }

    public bool GetIsTriggerEnterFront()
    {
        return isTriggerEnterFront;
    }

    public void SetIsTriggerEnterFront(bool isR)
    {
        isTriggerEnterFront = isR;
    }


}
