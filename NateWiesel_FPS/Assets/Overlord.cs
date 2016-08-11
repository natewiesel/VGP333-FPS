using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Overlord : MonoBehaviour {

    private static Overlord instance;
    
    public static  Overlord Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Overlord>();
            }
            return instance;
        }
    }


    void ThingHappens()
    {

    }

	// Use this for initialization
	void Start () {
        SendMessage("ThingHappens", SendMessageOptions.DontRequireReceiver);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
