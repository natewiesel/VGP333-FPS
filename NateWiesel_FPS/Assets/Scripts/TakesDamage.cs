using UnityEngine;
using System.Collections;

public class TakesDamage : MonoBehaviour, iKillable {

    public int Health;

    private Rigidbody cachedRB;
    private float deathLength = 1.0f;
    private bool alive = true;
    public GameObject bloodParticle;
    public bool friendly = false;

    // Use this for initialization
    void Start () {
        cachedRB = GetComponent<Rigidbody>();
        //Debug.Assert(cachedRB != null, "Rigidbody component error");
	}
	
    public bool isAlive
    {
        get
        {
            return alive;
        }
    }

    //Take damage
    public void Damage(float damage)
    {
        if (alive)
        {
            if (bloodParticle != null)
            {
                GameObject go = GameObject.Instantiate(bloodParticle);
                go.transform.position = transform.position;
            }

            Health -= Mathf.CeilToInt(damage);
            if (Health < 0) Health = 0;
        }
    }

    // Update is called once per frame
    void Update() {
        if (alive)
        {
            if (Health <= 0)
            {
                Die();
            }
        }
	}


    public void Die()
    {
        alive = false;
        StartCoroutine(DeathRoutine());
    }
    private IEnumerator DeathRoutine()
    {
        if (cachedRB != null) {
            cachedRB.AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);
            cachedRB.constraints = RigidbodyConstraints.None;
            //this.transform.Rotate(-20, 0, 0);
        }

        yield return new WaitForSeconds(deathLength);
        Destroy(this.gameObject);
    }
}
