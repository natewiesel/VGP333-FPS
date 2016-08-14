using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

    //private Rigidbody cachedRB;
    private Collider coll;
    public float damage = 1;

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
        TakesDamage td = collision.gameObject.GetComponent<TakesDamage>();
        if (td == null) {
            if (collision.gameObject.layer == 8)
            {
                Destroy(this.gameObject);
            }
        } else if (td.friendly == false){
            td.Damage(damage);
            Destroy(this.gameObject);
        }

    }
}
