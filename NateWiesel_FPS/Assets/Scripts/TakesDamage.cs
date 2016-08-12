using UnityEngine;
using System.Collections;

public class TakesDamage : MonoBehaviour, iKillable {

    public int Health;

    private Rigidbody cachedRB;
    private float deathLength = 1.0f;
    private bool alive = true;
    private GameObject player;
    private CapsuleCollider collider;

    // Use this for initialization
    void Start () {
        cachedRB = GetComponent<Rigidbody>();
        Debug.Assert(cachedRB != null, "Rigidbody component error");

        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Assert(player != null, "Player not found!");

        collider = GetComponent<CapsuleCollider>();
        Debug.Assert(collider != null, "collider error");
	}
	
    //Take damage
    public void Damage(float damage)
    {
        if (alive)
        {
            Health -= Mathf.CeilToInt(damage);
            if (Health < 0) Health = 0;
        }
    }

    // Update is called once per frame
    void Update() {
        if (alive)
        {
            cachedRB.transform.LookAt(player.transform);
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
        cachedRB.AddForce(new Vector3(0, -1000, 0), ForceMode.Impulse);
        //this.transform.Rotate(-20, 0, 0);

        yield return new WaitForSeconds(deathLength);
        Destroy(this.gameObject);
    }
}
