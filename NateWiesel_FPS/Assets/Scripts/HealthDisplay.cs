using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {
    TextMesh textfield;
    TakesDamage td;
    GameObject player;
    public bool mirror = false;

    // Use this for initialization
    void Start()
    {
        if (mirror) {
            transform.localScale.Set(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        textfield = GetComponent<TextMesh>();
        Debug.Assert(textfield != null, "text mesh component error");

        td = transform.parent.GetComponent<TakesDamage>();
        Debug.Assert(td != null, "could not get damage taking component on parent!");

        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Assert(player != null, "Player not found!");
    }

    // Update is called once per frame
    void Update () {
        textfield.text = "\u2764" + td.Health;
        if (player != null)
        {
            transform.LookAt(player.transform);
        }
    }
}
