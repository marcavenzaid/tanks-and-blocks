using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

	public Transform target;
	public float distance = -3.5f;
	public float height = 1.5f;
	public float damping = 5;
	public float rotationDamping = 5;
	
	void FixedUpdate () {
		float degreeInX = (360 - (target.eulerAngles.x)) * 0.1f;

		Vector3 wantedPosition = target.TransformPoint (0, height + degreeInX, distance);
					
		transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);

		Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);

		transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
	}
}
