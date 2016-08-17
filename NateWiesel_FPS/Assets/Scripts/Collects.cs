using UnityEngine;
using System.Collections;

public class Collects : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        Collectible collect = coll.gameObject.GetComponent<Collectible>();
        if (collect != null)
        {
            Debug.Log("Pickup!");
            coll.gameObject.SetActive(false);
            //Destroy(coll.gameObject);
        }
    }
}
