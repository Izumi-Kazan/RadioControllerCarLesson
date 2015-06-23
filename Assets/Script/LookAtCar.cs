using UnityEngine;
using System.Collections;

public class LookAtCar : MonoBehaviour {
	
	public GameObject car;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt( car.transform );
	}
}
