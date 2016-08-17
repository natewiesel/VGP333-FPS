using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGetHealth : MonoBehaviour {
    public GameObject Object;
    TakesDamage td;

    Text txt;

	// Use this for initialization
	void Start () {
        td = Object.GetComponent<TakesDamage>();
        txt = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        txt.text = "Portal Health: " + td.Health;
	}
}
