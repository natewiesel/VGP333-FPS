using UnityEngine;
using System.Collections;
public class LineRenderRaycast : MonoBehaviour {
    //public GameObject prefab;
    public float range;

    private LineRenderer line;

	// Use this for initialization
	void Start () {
        //GameObject go = Instantiate(prefab);

        SetLineLength(range);
	}
	
    private void SetLineLength(float length)
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.forward * length);
    }

	// Update is called once per frame
	void Update () {
        SetLineLength(range);
	}
}
