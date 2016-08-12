using UnityEngine;
using System.Collections;

public class DealDamage : MonoBehaviour {
    public float SplashRadius;
    public float damageToDeal;

	// Use this for initialization
	void Start () {
	    if (SplashRadius < 0.01f)
        {
            SplashRadius = 0.01f;
        }

        this.transform.localScale.Set(SplashRadius,SplashRadius,SplashRadius);
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.SetActive(false);
	}
    void OnDisable()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision coll)
    {
        TakesDamage td = coll.gameObject.GetComponent<TakesDamage>();
        if (td != null)
        {
            td.Damage(damageToDeal);
        }
    }
}
