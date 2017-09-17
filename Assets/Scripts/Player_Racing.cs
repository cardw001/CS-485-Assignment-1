using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Racing : MonoBehaviour {

	public Text countText;
	public Text winText;
	public Text trysText;
	
	private Rigidbody rb;
	private int count;
	private int trys;
	
	public float speed;
	
	private Vector3 spawn;

	void Start ()
	{
		rb = GetComponent <Rigidbody> ();
		count = 0;
		trys = 0;
		SetCountText ();
		winText.text = "";
		spawn = transform.position;
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 1);

		rb.AddForce (movement * speed);
	}	
		
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Finish Line")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}
		
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Blocker")
		{
			trys = trys + 1;
			SetTrysText();
			transform.position = spawn;
		}
	}
	void SetTrysText()
	{
		trysText.text = "Attempts: " + trys.ToString();
	}
	void SetCountText()
	{
		if (count >= 1) {
			winText.text = "You made it!!";
		}
		if(count >= 1)
		{
			SceneManager.LoadScene("Level Select");	
		}
	
	}
}