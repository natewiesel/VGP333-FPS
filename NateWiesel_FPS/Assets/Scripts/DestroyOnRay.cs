using UnityEngine;
using System.Collections;

public class DestroyOnRay : MonoBehaviour {
    public float range;
    private float damage = 1;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit = new RaycastHit();
        GameObject hitObject;
        if (Physics.Raycast(ray, out hit, range))
        {
            hitObject = hit.transform.gameObject;
            TakesDamage td = hitObject.GetComponent<TakesDamage>();
            if (td != null)
            {
                td.Damage(damage);
            }

            Debug.DrawRay(ray.origin, hit.point, Color.red, 2f);
            transform.position = hit.point;
            Destroy(this.gameObject);
        } else
        {
            Debug.DrawRay(ray.origin, ray.direction*range, Color.green,0.1f);
        }
    }
}
