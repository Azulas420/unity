using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurretLV1Script : MonoBehaviour
{
    public bool playerIsClose;
    public GameObject Weapon;
    public float Range;
    public Transform? Target;
    Vector2 Direction;
    

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {

        if (Target != null)
        {


            Vector2 targetPos = Target.position;

            Direction = targetPos - (Vector2)transform.position;

            RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);



            if (rayInfo)
            {
                if (rayInfo.collider.gameObject.tag == "Player")
                {
                    if (playerIsClose == false)
                    {
                        playerIsClose = true;
                    }
                }
            }

            else
            {
                if (playerIsClose == true)
                {
                    playerIsClose = false;
                }
            }
        }
        
        void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, Range);
        }
    }
}
