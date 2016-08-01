using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

    private float _rotX = 0;
    private float _rotY = 0;
    public float verticalLookLimit = 60.0f;

    public float sensitivityHorizontal = 5f;
    public float sensitivityVertical = 5f;


	// Use this for initialization
	void Start () {
        Rigidbody rbody = GetComponent<Rigidbody>();
        if (rbody != null)
        {
            rbody.freezeRotation = true;
        }
	}
	

	// Update is called once per frame
	void Update () {
        _rotX -= Input.GetAxis("Mouse Y") * sensitivityVertical;
        _rotX = Mathf.Clamp(_rotX, -verticalLookLimit, verticalLookLimit);

        float d = Input.GetAxis("Mouse X") * sensitivityHorizontal;
        _rotY = transform.localEulerAngles.y + d;
        transform.localEulerAngles = new Vector3(_rotX, _rotY, 0);
	}
}
