using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurretLV1Script : MonoBehaviour
{
    public bool playerIsClose;
    public GameObject Weapon;
    public GameObject Bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public float Range;
    public float Force;
    public Transform ShootPoint;
    public Transform ShootPoint2;
    public Transform? Target;

    Vector2 Direction;


    // Start is called before the first frame update
    void Start()
    {
        Bullet.transform.up = Direction;
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

                else
                {
                    if (playerIsClose == true)
                    {
                        playerIsClose = false;
                    }
                }
            }
        }
        if(playerIsClose)
        {
            Weapon.transform.up = Direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }

    void shoot()
    {
        GameObject ShootIns = Instantiate(Bullet,ShootPoint.position, Quaternion.identity);
        ShootIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);

        GameObject ShootIns2 = Instantiate(Bullet, ShootPoint2.position, Quaternion.identity);
        ShootIns2.GetComponent<Rigidbody2D>().AddForce(Direction * Force);

        if (Target != null)
        {
            playerIsClose = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}