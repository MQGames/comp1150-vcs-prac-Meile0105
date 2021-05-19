using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Transform pos;
    private Transform door;

    private bool isClickDoor = false;
    private int curAn = 0;
    private DoorState curDS;
    private int doorisOpen = 0;
    // Start is called before the first frame update
    void Start()
    {
        isClickDoor = false;  //未点击
        curDS = DoorState.Close;
        pos = this.transform.Find("pos");
        door = this.transform.Find("door_open");

    }
    enum DoorState  //门的状态有开和关两种
    {
        Close,
        Open
    }
    // Update is called once per frame
    void Update()
    {
        if (isClickDoor)
        {
            if (curDS == DoorState.Close)
            {
                door.RotateAround(pos.position, Vector3.up, 1); //围绕pos坐标Z轴正半轴旋转90度
                curAn++;
                if (curAn == 90)
                {
                    isClickDoor = false;
                    curAn = 0;
                    curDS = DoorState.Open;
                    doorisOpen = 1; //用1标记门的状态为开
                }
            }
            else if (curDS == DoorState.Open)
            {
                door.RotateAround(pos.position, Vector3.up, -1); //围绕pos坐标Z轴负半轴轴旋转-90度
                curAn++;
                if (curAn == 90)
                {
                    isClickDoor = false;
                    curAn = 0;
                    curDS = DoorState.Close;
                    doorisOpen = 0; //用0标记门的状态为关
                }
            }
        }

    }
    public void OpenDoor()
    {
        isClickDoor = true;
    }
}
