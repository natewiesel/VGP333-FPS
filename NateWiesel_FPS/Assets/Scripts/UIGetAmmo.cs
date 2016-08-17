using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGetAmmo : MonoBehaviour
{
    Text textfield;
    // Use this for initialization
    void Start()
    {
        textfield = GetComponent<Text>();
        Debug.Assert(textfield != null, "text field component error");
    }

    // Update is called once per frame
    void Update()
    {
        string str = "AMMO: ";
        string amountstr1 = "???";
        string amountstr2 = "???";

        Weapon gunInfo = Overlord.Instance.SelectedGun.gameObject.GetComponent<Weapon>();
        if (Overlord.Instance.SelectedGun != null)
        {
            amountstr1 = gunInfo.Ammo.ToString();
            amountstr2 = gunInfo.maxAmmo.ToString();
        }

        textfield.text = str + amountstr1 + " / " + amountstr2;
    }
}
