using UnityEngine;
using System.Collections;

public class FirstPersonMovement : MonoBehaviour {

    public float moveSpeed = 6.0f;
    public float gravity = Physics.gravity.magnitude;

    private CharacterController _char;

	// Use this for initialization
	void Start () {
        _char = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
