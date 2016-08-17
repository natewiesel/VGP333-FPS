using UnityEngine;
using System.Collections;
using System;

public class Weapon : MonoBehaviour, iShootable {

    //ammo vars
    public int startingAmmo = 50;
    public int maxAmmo = 150;
    public int AmmoPickupMultiplier = 10;
    public int Ammo;

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
        transform.localPosition = heldPosition + Vector3.down;
        Ammo = startingAmmo;
    }
	void OnEnable()
    {
        transform.localPosition = heldPosition + Vector3.down;
    }
    // Update is called once per frame
    void Update () {
        //Shooting cooldown
        if (shootCooldown == 0f && Ammo > 0)
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
        Shoot();

        if (Input.GetButton("Fire2"))
        {
            isAiming = true;
        } else
        {
            isAiming = false;
        }

        //Aiming
        AimAnimationUpdate();

        if (Ammo > maxAmmo)
        {
            Ammo = maxAmmo;
        }
	}

    private void AimAnimationUpdate()
    {
        Transform cachedTrans = GetComponent<Transform>();

        GetComponentInParent<Transform>();

        if (isAiming)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimPosition, aimLerpSpeed);
            //Debug.Log(cachedTrans.localPosition.ToString());
        } else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, heldPosition, aimLerpSpeed);
            //Debug.Log(cachedTrans.localPosition.ToString());
        }
    }

    public void Shoot()
    {
        if (canShoot && Input.GetButton("Fire1"))
        {
            if (bullet != null)
            {
                Vector3 sp;
                Quaternion spRot;
                sp = this.transform.position;
                sp += transform.forward * gunLength;
                spRot = this.transform.rotation;

                if (sp != null)
                {
                    GameObject s = Instantiate(bullet, sp, spRot) as GameObject;
                }
                else
                {
                    Debug.Log("Could not find transform point to shoot from!");
                }

                Ammo--;
                shootCooldown = fireRate;

            }
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

