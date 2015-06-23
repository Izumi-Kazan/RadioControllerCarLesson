using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {

	public WheelCollider wheelCollider;
	
	private float rotation;
	private WheelHit hit;

	void Update () {
		Vector3 colliderCenter = wheelCollider.transform.TransformPoint(wheelCollider.center);
		
		if (wheelCollider.GetGroundHit(out hit)) {
			transform.position = hit.point + (wheelCollider.transform.up * wheelCollider.radius);
		} else {
			transform.position = colliderCenter - (wheelCollider.transform.up * wheelCollider.suspensionDistance);
		}
		// ハンドルを切った時の前輪の角度：WheelColliderを参照している
		transform.rotation = wheelCollider.transform.rotation * Quaternion.Euler(rotation, wheelCollider.steerAngle, 0);
		
		// タイヤを回転させる
		rotation += wheelCollider.rpm * (360 / 60) * Time.deltaTime;
	}
}
