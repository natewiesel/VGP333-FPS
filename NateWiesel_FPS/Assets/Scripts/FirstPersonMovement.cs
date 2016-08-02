using UnityEngine;
using System.Collections;

public class FirstPersonMovement : MonoBehaviour {

    public float moveSpeed = 6.0f;
    private float gravity = -Physics.gravity.magnitude;
    private float gravityPull = 0.5f;

    private float Xspeed = 0f;
    private float Zspeed = 0f;

    private CharacterController _char;

	// Use this for initialization
	void Start () {
        _char = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        //Movement Input
        Xspeed = Input.GetAxis("Horizontal") * moveSpeed;
        Zspeed = Input.GetAxis("Vertical") * moveSpeed;
        float jumpInput = Input.GetAxis("Jump");

        Vector3 move = new Vector3(Xspeed, 0, Zspeed);
        move = Vector3.ClampMagnitude(move, moveSpeed);

        ////Gravity
        //if (move.y > gravity)
        //{
        //    move.y -= gravityPull;
        //}
        ////move.y = gravity;

        move *= Time.deltaTime;
        move = transform.TransformDirection(move);
        _char.Move(move);
	}
}
