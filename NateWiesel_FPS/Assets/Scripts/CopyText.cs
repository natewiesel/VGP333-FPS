using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CopyText : MonoBehaviour {

    public string TextPrefix;
    public string TextSuffix;
    public GameObject TextToCopy;
    Text mytext;
    Text othertext;

	// Use this for initialization
	void Start () {
        mytext = gameObject.GetComponent<Text>();
        othertext = TextToCopy.gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        mytext.text = TextPrefix + othertext.text + TextSuffix;
	}
}
