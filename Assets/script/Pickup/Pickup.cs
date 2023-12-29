using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    // Variables for animation
    public bool alwaysAnimate = false;
    public Vector3 rotationRate = new Vector3(0,90,0);

    Renderer r;

    // Start is called before the first frame update
    public virtual void Start()
    {
       r = GetComponent<Renderer>(); 
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Debug.Log(r.isVisible);
        //don't animate if  not on screen
        if(!alwaysAnimate && r && !r.isVisible)
        {
            return;
        }
        if(rotationRate.sqrMagnitude > 0)
        {
           transform.Rotate(rotationRate * Time.deltaTime);
        }
    }
    //total no of pickups in scene
    public static int CountNumberInScene()
    {
       return FindObjectsOfType<Pickup>().Length;
    }
}
