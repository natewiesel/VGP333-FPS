using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

    //private Rigidbody cachedRB;
    private Collider coll;

	// Use this for initialization
	void Start () {
        //cachedRB = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        Debug.Assert(coll != null, "Collider component error!");
        if (coll == null)
        {
            enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }
    }
}
