using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class VelocityOnSpawn : MonoBehaviour {
    public float Velocity;
    Rigidbody cachedRB;
	// Use this for initialization
	void Start () {
        cachedRB = GetComponent<Rigidbody>();
        Debug.Assert(cachedRB != null, "Rigidbody component error!");

        Vector3 forward = transform.forward;

        //if (cachedRB != null)
        //{
            cachedRB.AddForce(forward * Velocity);
        //}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
