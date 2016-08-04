using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    private float lastShotTime;
    public float fireRate = 1f;
    private float shootCooldown = 0f;
    bool canShoot = false;

    public GameObject bullet;
    private GameObject shot = null;

	// Use this for initialization
	void Start () {
        lastShotTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
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

        if (canShoot && Input.GetButton("Fire1"))
        {
            if (bullet != null)
            {
                GameObject sp = GameObject.Find("ShootPoint");

                if (sp != null) {
                    GameObject s = Instantiate(bullet, sp.transform.position, sp.transform.rotation) as GameObject;
                } else
                {
                    Debug.Log("Could not find transform point to shoot from!");
                }


                shootCooldown = fireRate;
            }
        }
	}
}
