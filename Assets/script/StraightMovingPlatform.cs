using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovingPlatform : KinematicPlatform
{
    public Vector2 endPoint;
    Vector2 origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    protected override void Update()
    {
       base.Update();

       transform.position = Vector2.Lerp(origin,endPoint,currentCycleTime / cycleRunTime); 
    }
    protected override void Reset()
    {
        base.Reset();
        //straight line
        endPoint = transform.position + transform.right *8;
        cycleType = CycleType.pingPong;

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(transform.position,endPoint);
    }
}
