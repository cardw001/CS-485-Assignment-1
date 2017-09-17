using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_block : MonoBehaviour {

	public Transform movePoints;
	public float moveSpeed;
	private Vector3 startingPoint;

	
	void Start()
	{
		startingPoint = transform.position;
	}
	// Update is called once per frame
	void Update () {
		float speed = moveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, movePoints.position, speed);

		if(transform.position == movePoints.position)
		{
			transform.position = startingPoint;
		}
		
	}
}