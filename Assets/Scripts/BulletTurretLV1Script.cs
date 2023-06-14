using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurretLV1Script : MonoBehaviour
{
    public float Range;
    public Transform Target;
    bool Detected = false;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;

        Direction = targetPos - (Vector2)transform.position;
        
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,Direction,Range);

        if(rayInfo)
        {
            if(rauInfo.collider.gameObject.tag == "PLayer")
            {
                if(Detected == false)
                {
                    Detected = true;
                }

                
            }
        }
    }
}
