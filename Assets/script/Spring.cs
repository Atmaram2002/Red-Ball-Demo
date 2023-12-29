using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float springForce = 9f;
    public float activationForce =0f;
    public float cooldown = 0.3f;
    public LayerMask affectedLayers = ~0;

    float currentCooldown = 0;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     if (currentCooldown > 0)
       {
        currentCooldown -= Time.deltaTime;
       } 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(currentCooldown > 0)return;

        if((affectedLayers & (1 << other.gameObject.layer)) == 0) return;

        Rigidbody2D target = other.GetComponent<Rigidbody2D>();
        if(!target.isKinematic && target)
        {
            float reboundStrength = Vector2.Dot(target.velocity,transform.up);
            if (-reboundStrength < activationForce)return;
            
            anim.SetTrigger("Hit");
            target.AddForce(transform.up * (springForce - reboundStrength),ForceMode2D.Impulse);
            currentCooldown = cooldown;
        }
    }
}
