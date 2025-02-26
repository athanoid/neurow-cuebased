﻿using UnityEngine;
using System.Collections;
using Assets.LSL4Unity.Scripts.Examples;

public class RotateRow : MonoBehaviour {

	public static  float speed = 300f;

	public float angle, angle1;
	public float xDiff, yDiff;

	float angleOffset = 0f;
	Quaternion initRotationL, initRotationR;

	public Transform targetHand;

	// Use this for initialization
	void Start () {
	
		angleOffset = 90.0f;
		initRotationL = GameObject.FindGameObjectWithTag ("LeftRow").transform.localRotation;
		initRotationR = GameObject.FindGameObjectWithTag ("RightRow").transform.localRotation;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (GameObject.Find ("rigidHand") != null)
			targetHand = GameObject.Find ("rigidHand").transform;
		else
			targetHand = targetHand;


		if (MoveBoat.training) {

			// Row Left 
			if ((Input.GetKey (KeyCode.LeftArrow) || (MoveBoat.left && MoveBoat.hidearrow)) && this.gameObject.name == "Lpivot") {
				GameObject.FindGameObjectWithTag ("LeftRow").transform.Rotate (Vector3.right * speed * Time.deltaTime);
			}
			
			// Row Right 
			if ((Input.GetKey (KeyCode.RightArrow) ||(MoveBoat.right && MoveBoat.hidearrow)) && this.gameObject.name == "Rpivot") {
				GameObject.FindGameObjectWithTag ("RightRow").transform.Rotate (Vector3.right * speed * Time.deltaTime);

			}

		} else { // for ONLINE

			// Row Left 
			if ((Input.GetKey (KeyCode.LeftArrow) ||(MoveBoat.left && MoveBoat.hidearrow && (LSLClassMarkers.getLSLsample == 769 || LSLClassMarkers.getLSLsample == 7)) ) && this.gameObject.name == "Lpivot") {
				GameObject.FindGameObjectWithTag ("LeftRow").transform.Rotate (Vector3.right * speed * Time.deltaTime);
			}

			// Row Right 
			if ((Input.GetKey (KeyCode.RightArrow) || (MoveBoat.right && MoveBoat.hidearrow && (LSLClassMarkers.getLSLsample == 770 || LSLClassMarkers.getLSLsample == 8)) ) && this.gameObject.name == "Rpivot") {
				GameObject.FindGameObjectWithTag ("RightRow").transform.Rotate (Vector3.right * speed * Time.deltaTime);

			}

		}



	}
}
