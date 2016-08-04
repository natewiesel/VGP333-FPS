using UnityEngine;
using System.Collections;
using System;

public class Weapon : MonoBehaviour {

    //private float lastShotTime;
    public float fireRate = 1f;
    private float shootCooldown = 0f;
    bool canShoot = false;

    public GameObject bullet;
    private GameObject shot = null;
    private Rigidbody cachedRB;

    public bool ShowDebugGizmos;
    public float gunLength;

    //aiming vars
    private bool isAiming;
    public Vector3 heldPosition;
    public Vector3 aimPosition;
    public float aimLerpSpeed;

    // Use this for initialization
    void Start () {
        //lastShotTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        //Shooting cooldown
        if (shootCooldown == 0f)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;

            shootCooldown -= Time.deltaTime;
        }
        if (shootCooldown < 0f)
        {
            shootCooldown = 0f;
        }

        //Firing
        if (canShoot && Input.GetButton("Fire1"))
        {
            Fire();
        }

        if (Input.GetButton("Fire2"))
        {
            isAiming = true;
        } else
        {
            isAiming = false;
        }

        //Aiming
        AimAnimationUpdate();
	}

    private void AimAnimationUpdate()
    {
        Transform cachedTrans = GetComponent<Transform>();

        GetComponentInParent<Transform>();

        if (isAiming)
        {
            transform.localPosition = Vector3.Lerp(aimPosition, heldPosition, aimLerpSpeed * Time.deltaTime);
            Debug.Log(cachedTrans.localPosition.ToString());
        } else
        {
            transform.localPosition = Vector3.Lerp(heldPosition, aimPosition, aimLerpSpeed*Time.deltaTime);
            Debug.Log(cachedTrans.localPosition.ToString());
        }
    }

    void Fire()
    {
        if (bullet != null)
        {
            Vector3 sp;
            Quaternion spr;
            sp = this.transform.position;
            sp += transform.forward * gunLength;
            spr = this.transform.rotation;

            if (sp != null)
            {
                GameObject s = Instantiate(bullet, sp, spr) as GameObject;
            }
            else
            {
                Debug.Log("Could not find transform point to shoot from!");
            }


            shootCooldown = fireRate;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (gunLength != 0 && ShowDebugGizmos)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward*gunLength);
            Gizmos.DrawSphere(transform.position + transform.forward * gunLength, 0.05f);
        }
    }
}

