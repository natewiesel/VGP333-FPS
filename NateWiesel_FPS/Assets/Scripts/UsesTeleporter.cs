using UnityEngine;
using System.Collections;

public class UsesTeleporter : MonoBehaviour {
    public GameObject teleportEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        Teleport tel = coll.gameObject.GetComponent<Teleport>();
        if (tel != null)
        {
            transform.position = tel.Destination.gameObject.transform.position;

            Instantiate(teleportEffect, transform.position, transform.rotation);
        }
    }
}
