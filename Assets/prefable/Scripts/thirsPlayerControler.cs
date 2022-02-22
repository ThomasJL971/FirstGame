using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirsPlayerControler : MonoBehaviour {

    public FixedJoystick LeftJoystick;
    public FixedButton Button;
    public FixedTouchField Touchfield;

    protected CharacterController Player;
    protected Animator Anim;
    protected Rigidbody Rigidbody;

    protected float CameraAngleY;
    protected float CameraAngleSpeed = 0.1f;
    protected float CameraPosY;
    protected float CameraPosSpeed = 0.1f;

    // Use this for initialization
    void Start () {
        Player = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        //var input = new Vector3(LeftJoystick.inputVector.x, 0, LeftJoystick.inputVector.y);
        //var vel = Quaternion.AngleAxis(CameraAngleY + 180, Vector3.up) * input * 5f;

        //Rigidbody.velocity = new Vector3(vel.x, Rigidbody.velocity.y, vel.z);


    }
}
