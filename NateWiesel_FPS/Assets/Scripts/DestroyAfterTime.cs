using UnityEngine;
using System.Collections;
using System;

public class DestroyAfterTime : MonoBehaviour {

    public float DestroyTime;
    private float clock;

	// Use this for initialization
	void Start () {
        clock = DestroyTime;

        //StartCoroutine(DestroyCallback());
	}

    //private IEnumerator DestroyCallback()
    //{
    //    //this is kind of crazy
    //    yield return new WaitForSeconds(DestroyTime);
    //    KillMe();

    //    yield return null;
    //}

    // Update is called once per frame
    void Update () {
        clock -= Time.deltaTime;
        if (clock <= 0)
        {
            KillMe();
        }
	}

    void KillMe()
    {
        Destroy(this.gameObject);
    }
}
