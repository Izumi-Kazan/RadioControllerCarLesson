using UnityEngine;
using System.Collections;

public class SimpleCarController : MonoBehaviour {
	
	public WheelCollider wheelFrontRight;
	public WheelCollider wheelFrontLeft;
	public WheelCollider wheelRearRight;
	public WheelCollider wheelRearLeft;
	
	public float enginPower = 1000.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float currentPower = wheelRearRight.motorTorque;
		
		if ( Input.GetKey( KeyCode.W ) ) {
			wheelFrontRight.motorTorque = wheelFrontLeft.motorTorque = wheelRearRight.motorTorque = wheelRearLeft.motorTorque = enginPower;
		} else if ( Input.GetKey( KeyCode.S ) ) {
			wheelFrontRight.motorTorque = wheelFrontLeft.motorTorque = wheelRearRight.motorTorque = wheelRearLeft.motorTorque = enginPower * -0.7f;
		} else {
			wheelFrontRight.motorTorque = wheelFrontLeft.motorTorque = wheelRearRight.motorTorque = wheelRearLeft.motorTorque = 0;
			// 惰性が、だんだん無くなる
			wheelFrontRight.brakeTorque = wheelFrontLeft.brakeTorque = wheelRearRight.brakeTorque = wheelRearLeft.brakeTorque = currentPower * 1f;
		}
		
		
		
		
	}
}
