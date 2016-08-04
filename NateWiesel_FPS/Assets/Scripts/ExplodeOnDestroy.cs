using UnityEngine;
using System.Collections;

public class ExplodeOnDestroy : MonoBehaviour {
    public GameObject explosionPrefab;
	// Use this for initialization
	void OnDestroy()
    {
        GameObject go = Instantiate(explosionPrefab, transform.position, transform.rotation) as GameObject;
        go.name = gameObject.name + " " + go.name;
    }
}
