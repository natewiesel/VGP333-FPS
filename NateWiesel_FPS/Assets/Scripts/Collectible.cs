using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

    public int AmmoValue = 1;
    Rigidbody cachedRB;

	// Use this for initialization
	void Start () {
        cachedRB = GetComponent<Rigidbody>();
        Debug.Assert(cachedRB != null, "Rigidbody component error");
	}
	
	// Update is called once per frame
	void Update () {
        cachedRB.transform.Rotate(0, 60*Time.deltaTime, 0);
	}

    void OnDisable()
    {
        GameObject[] weps = Overlord.Instance.gunObjects;

        foreach(GameObject go in weps)
        {
            Weapon wep = go.GetComponent<Weapon>();
            if (wep != null)
            {
                wep.Ammo += AmmoValue * wep.AmmoPickupMultiplier;
            }
        }
    }
}
