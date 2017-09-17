using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;
	
	private Vector3 spawn;

	void Start ()
	{
		rb = GetComponent <Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		spawn = transform.position;
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}	
		
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick-up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}
		
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Blocker")
		{
			transform.position = spawn;
		}
	}
	
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 18) {
			winText.text = "You Win!!";
		}
		if(count >= 18)
		{
			SceneManager.LoadScene("Level Select");	
		}
	
	}
}
