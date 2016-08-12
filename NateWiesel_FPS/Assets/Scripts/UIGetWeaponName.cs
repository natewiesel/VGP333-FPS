using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGetWeaponName : MonoBehaviour {
    Text textfield;
	// Use this for initialization
	void Start () {
        textfield = GetComponent<Text>();
        Debug.Assert(textfield != null, "text field component error");
	}
	
	// Update is called once per frame
	void Update () {
        if (Overlord.Instance.SelectedGun != null)
        {
            textfield.text = "Weapon: " + Overlord.Instance.SelectedGun.name;
        } else
        {
            textfield.text = "Weapon: N/A";
        }
	}
}
