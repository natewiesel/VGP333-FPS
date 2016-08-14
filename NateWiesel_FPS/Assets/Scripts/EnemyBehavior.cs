using UnityEngine;
using System.Collections;

//requires an object that can take damage
[RequireComponent(typeof(TakesDamage))]

public class EnemyBehavior : MonoBehaviour {

    TakesDamage td;
    Rigidbody cachedRB;
    public GameObject chaseTarget;
    public float speed;

    // Use this for initialization
    void Start () {
        cachedRB = GetComponent<Rigidbody>();
        Debug.Assert(cachedRB != null, "Rigidbody component error");

        td = GetComponent<TakesDamage>();
        Debug.Assert(td != null, "Damage taking component error");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (chaseTarget != null)
        {
            cachedRB.transform.LookAt(chaseTarget.transform);
            cachedRB.AddForce(transform.forward * speed, ForceMode.Force);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        TakesDamage colltd = coll.gameObject.GetComponent<TakesDamage>();
        if (colltd != null && td.isAlive)
        {
            if (colltd.friendly == true)
            {
                colltd.Damage(td.Health);
                Destroy(this.gameObject);
            }
        }
    }
}
