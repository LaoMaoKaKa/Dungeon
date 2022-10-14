using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//没有框架的话 数据就保存到单例类吧 方便读取
public class GameManger : UnitySlingleton<GameManger>
{
    private Vector2 curPoint = Vector2.right; //player 朝向
    private bool isJump=false;    //跳跃状态
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
