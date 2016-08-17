using UnityEngine;
using System.Collections;

public class CreateOnDestroy : MonoBehaviour {
    public GameObject thingToMake;
    public int dropChance = 30;
    bool doDrop = false;

	// Use this for initialization
	void Start () {
        float Rand = Random.Range(0f, 100f);

        if (Rand < dropChance)
        {
            doDrop = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {
        if (doDrop)
        {
            GameObject.Instantiate(thingToMake, transform.position, Quaternion.identity);
        }
    }
}
