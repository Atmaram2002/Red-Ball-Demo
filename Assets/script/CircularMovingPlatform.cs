using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform :KinematicPlatform
{
    public Vector2 center;
    Vector2 origin;
    Vector2 difference;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
       origin = transform.position;
       difference = origin - center;
       angle = Mathf.Atan2(difference.y,difference.x)*Mathf.Rad2Deg; 
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }
}
