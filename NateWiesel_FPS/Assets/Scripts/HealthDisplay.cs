using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {
    TextMesh textfield;
    TakesDamage td;

    // Use this for initialization
    void Start()
    {
        textfield = GetComponent<TextMesh>();
        Debug.Assert(textfield != null, "text mesh component error");

        td = transform.parent.GetComponent<TakesDamage>();
        Debug.Assert(td != null, "could not get damage taking component");
    }

    // Update is called once per frame
    void Update () {
        textfield.text = "\u2764" + td.Health;
	}
}
