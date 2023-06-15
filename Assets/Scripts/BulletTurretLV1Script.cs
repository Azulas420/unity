using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurretLV1Script : MonoBehaviour
{
    public float Range;
    public Transform Target;
    public bool playerIsClose = false;
    Vector2 Direction;
    public GameObject Gun;

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
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                if(playerIsClose == false)
                {
                    playerIsClose = true;
                }          
            }
            else 
            {
                if(playerIsClose == true)
                {
                    playerIsClose = false;
                    Debug.Log("coda");
                }          
            }
        }
        if(playerIsClose)
        {
            Gun.transform.up = Direction;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,Range);
    }
}
