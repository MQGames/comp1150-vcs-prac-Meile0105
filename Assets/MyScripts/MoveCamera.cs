using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform MoveRoad;
    private Transform[] lujing;
    private int curSign;
    // Start is called before the first frame update
    void Start()
    {
        curSign = 0;
        lujing = new Transform[MoveRoad.childCount];
        for (int i = 0; i < MoveRoad.childCount; i++)
        {
            lujing[i] = MoveRoad.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(lujing[curSign].position*Time.deltaTime*0.05f);
        transform.LookAt(lujing[curSign].position);
        if (Vector3.Distance(transform.position,lujing[curSign].position)<0.1)
        {
            curSign++;
            if (curSign== MoveRoad.childCount)
            {
                curSign = 0;
            }
        }
    }
}
