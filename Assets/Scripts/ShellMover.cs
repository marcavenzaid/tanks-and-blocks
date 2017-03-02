using UnityEngine;
using System.Collections;

public class ShellMover : MonoBehaviour {

	public GameObject explosion;
	public float force = 1500;

	void Start () {
		GetComponent<Rigidbody> ().AddForce (transform.forward * force);
	}

	void OnCollisionEnter(){
		Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
