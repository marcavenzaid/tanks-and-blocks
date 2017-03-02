using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject shell;
	public Transform shotSpawn;
	public Transform head;
	public float moveSpeed;
	public float turnSpeed;
	public float gunTurnSpeed = 30;
	public float fireRate = 2f;
	public float shotForce = 10;

	private Rigidbody rb;
	private float nextFire = 0;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		GunController ();
	}

	void FixedUpdate(){
		float move = Input.GetAxis ("Vertical") * moveSpeed;
		float turn = Input.GetAxis ("Horizontal") * turnSpeed;

		//rb.velocity = move * transform.forward * Time.deltaTime;

		rb.AddForce (move * transform.forward * Time.deltaTime);

		Quaternion turnRotation = Quaternion.Euler (0, turn * Time.deltaTime, 0);

		rb.MoveRotation (rb.rotation * turnRotation);
	}

	private void GunController(){
		if (Input.GetKey (KeyCode.J)) {
			head.Rotate (0, -gunTurnSpeed * Time.deltaTime, 0, Space.World);
		}

		if (Input.GetKey (KeyCode.L)) {
			head.Rotate (0, gunTurnSpeed * Time.deltaTime, 0, Space.World);
		}

		if (Input.GetKey (KeyCode.I)) {
			head.Rotate (-gunTurnSpeed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey (KeyCode.K)) {
			head.Rotate (gunTurnSpeed * Time.deltaTime, 0, 0);
		}
			
		head.eulerAngles = new Vector3 (Mathf.Clamp (head.eulerAngles.x, 325, 358), head.eulerAngles.y, 0);

		if (Input.GetKey (KeyCode.Space) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shell, shotSpawn.position, shotSpawn.rotation);
			rb.AddForce (-head.forward * shotForce, ForceMode.Impulse);
		}
	}
}
