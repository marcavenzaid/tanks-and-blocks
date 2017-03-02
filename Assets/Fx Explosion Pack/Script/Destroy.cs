using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public float explosionForce = 500;
	public float explosionRadius = 10;
	public float upwardModifier = 1f;

	void Start(){
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere (explosionPos, explosionRadius);
		foreach (Collider hit in colliders) {
			Rigidbody rb = hit.GetComponent<Rigidbody> ();
			if (rb != null) {
				rb.AddExplosionForce (explosionForce, explosionPos, explosionRadius);
			}
		}
	}

	void Update () {
		Destroy (gameObject, 3);
	}
}
