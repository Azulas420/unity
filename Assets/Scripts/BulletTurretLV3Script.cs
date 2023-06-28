using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurretLV3Script : MonoBehaviour
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
    public Transform ShootPoint3;
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

                else
                {
                    if (playerIsClose == true)
                    {
                        playerIsClose = false;
                    }
                }
            }
        }
        if (playerIsClose && Target != null)
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
        Vector2 direction = (Vector2)Target.position - (Vector2)ShootPoint.position;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        GameObject shootInstance = Instantiate(Bullet, ShootPoint.position, rotation);
        shootInstance.GetComponent<Rigidbody2D>().AddForce(direction.normalized * Force);

        GameObject shootInstance2 = Instantiate(Bullet, ShootPoint2.position, rotation);
        shootInstance2.GetComponent<Rigidbody2D>().AddForce(direction.normalized * Force);

        GameObject shootInstance3 = Instantiate(Bullet, ShootPoint3.position, rotation);
        shootInstance3.GetComponent<Rigidbody2D>().AddForce(direction.normalized * Force);

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
