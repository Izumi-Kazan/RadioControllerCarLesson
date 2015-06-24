using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {

	public WheelCollider wheelCollider;
	
	private float rotation;
	private WheelHit hit;

	void Update () {
		
		Quaternion quat;
        Vector3 position;
		// ホイールコライダの位置と回転をワールド座標系で取得する
        wheelCollider.GetWorldPose(out position, out quat);
		
		//  Vector3 colliderCenter = wheelCollider.transform.TransformPoint(wheelCollider.center);
		//  if (wheelCollider.GetGroundHit(out hit)) {
		
			// 位置の更新
			transform.position = position;
		//  } else {
		//  	transform.position = colliderCenter - (wheelCollider.transform.up * wheelCollider.suspensionDistance);
		//  }
		// ハンドルを切る：WheelColliderを参照している：ハンドルを切ったホイールコライダーのみ反応
		transform.rotation = wheelCollider.transform.rotation * Quaternion.Euler(rotation, wheelCollider.steerAngle, 0);
		
		// タイヤを回転させる
		transform.rotation = quat;
	}
}
