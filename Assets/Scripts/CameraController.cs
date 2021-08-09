using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform player;
	public Vector3 offset;

	void Start()
	{
		// Initial position of Camera controller
		transform.position = new Vector3(22, 26, 7);
		transform.rotation = Quaternion.Euler(44f, 0, 0);
	}
	// Update is called once per frame
	void Update()
	{
		transform.position = player.position + offset;
	}
}
