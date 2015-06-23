using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	public WheelCollider wcFrontLeft;
	public WheelCollider wcFrontRight;
	public WheelCollider wcRearLeft;
	public WheelCollider wcRearRight;

	
	public Vector3 centerOfMass;
	public float enginePower = 30f;
	public float brakePower = 10f;
	public float steerAngleMax = 20f;
	
	private bool isAccelOn;
	private bool isFoward;
	private bool isBack;
	
	void Start () {
		GetComponent<Rigidbody>().centerOfMass = centerOfMass;
	}
	
	void FixedUpdate () {
		
		if (Input.GetKey(KeyCode.W) || isFoward) {
			isAccelOn = true;
			float torue = enginePower;
			float torueIdle = enginePower * 0.2f;

			wcFrontLeft.motorTorque = torue;
			wcFrontRight.motorTorque = torue;
			wcRearLeft.motorTorque = torue;
			wcRearRight.motorTorque = torue;
			//  wcFrontLeft.motorTorque = (wcFrontLeft.isGrounded) ? torue : torueIdle;
			//  wcFrontRight.motorTorque = (wcFrontRight.isGrounded) ? torue : torueIdle;
			//  wcRearLeft.motorTorque = (wcRearLeft.isGrounded) ? torue : torueIdle;
			//  wcRearRight.motorTorque = (wcRearRight.isGrounded) ? torue : torueIdle;
			
			Debug.Log("W:" + wcFrontLeft.motorTorque);
			
		} else if (Input.GetKey(KeyCode.S) || isBack) {
			isAccelOn = true;
			float torue = enginePower * -0.8f;
			float torueIdle = enginePower * -0.2f;
			wcFrontLeft.motorTorque = (wcFrontLeft.isGrounded) ? torue : torueIdle;
			wcFrontRight.motorTorque = (wcFrontRight.isGrounded) ? torue : torueIdle;
			wcRearLeft.motorTorque = (wcRearLeft.isGrounded) ? torue : torueIdle;
			wcRearRight.motorTorque = (wcRearRight.isGrounded) ? torue : torueIdle;
		} else {
			isAccelOn = false;
			wcFrontLeft.motorTorque = 0;
			wcFrontRight.motorTorque = 0;
			wcRearLeft.motorTorque = 0;
			wcRearRight.motorTorque = 0;
			
			wcFrontLeft.brakeTorque = brakePower;
			wcFrontRight.brakeTorque = brakePower;
			wcRearLeft.brakeTorque = brakePower;
			wcRearRight.brakeTorque = brakePower;
		}
		
		float h = Input.GetAxis("Horizontal") + -Input.acceleration.y;
		float angle = h * steerAngleMax;
		wcFrontLeft.steerAngle = angle;
		wcFrontRight.steerAngle = angle;
	}
	
	public bool IsAccelOn () {
		return isAccelOn;
	}
	
	public bool IsWheelGrounded () {
		return wcFrontLeft.isGrounded || wcFrontRight.isGrounded 
			|| wcRearLeft.isGrounded || wcRearRight.isGrounded;
	}
	
	public float GetEngineRevolution () {
		return Mathf.Abs(wcFrontLeft.rpm + wcFrontRight.rpm + wcRearLeft.rpm + wcRearRight.rpm) * 0.25f;
	}
	
//  #if UNITY_IPHONE || UNITY_ANDROID
//  	void OnGUI () {
//  		isFoward = GUI.RepeatButton(new Rect(Screen.width - 80, Screen.height - 160, 80, 70), "GO");
//  		isBack = GUI.RepeatButton(new Rect(Screen.width - 80, Screen.height - 80, 80, 70), "BACK");
//  	}
//  #endif
}
