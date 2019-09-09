using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveBoat : MonoBehaviour {

	public static float boatspeed = 5f;//default = 5
	public static float turnspeed = 10f;
	public static float stoppingAngle = 45f;

	public Transform compass;

	public Image crossui, leftarrow, rightarrow;
	public static bool cross, left, right, hidearrow = false;
	public static bool training;

	// Use this for initialization
	void Start () {
		//settings
		Settings.reverseHands = true;
		boatspeed = 5f;

		crossui.enabled = false;
		leftarrow.enabled = false;
		rightarrow.enabled = false;

		// check scene name to enable training
		if (SceneManager.GetActiveScene().name == "boat_online") 
			training = false;
		else
			training = true;

		Debug.Log ("scene: " + SceneManager.GetActiveScene().name);
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (Assets.LSL4Unity.Scripts.Examples.ExampleFloatInlet.signal);

		// if simple ERD is selected, then only FWD, else FWD is automatic and L/R is through LDA input
		//if(Input.GetKey(KeyCode.UpArrow))
		transform.Translate(Vector3.forward * boatspeed * Time.deltaTime);

		//if((compass.localEulerAngles.y >= (360 - stoppingAngle) && compass.localEulerAngles.y <= 360) || (compass.localEulerAngles.y >= 0 && compass.localEulerAngles.y <= (0 + stoppingAngle)))
		//	transform.Translate(Vector3.forward * boatspeed * Time.deltaTime);

		if (Receivemarkers.markerint == 1010) //32770 experiment stop
			Debug.Log ("End of Session!");
		//pop window

		//Todo
		// on 32770 experiment stop
		// quit app


		if (training) {

			getStim ();
			
			if (Input.GetKey (KeyCode.LeftArrow) || (left  && hidearrow)) {
				left = true;
				//			right = false;
				if (!Settings.reverseHands)
					transform.Rotate (Vector3.up * turnspeed * Time.deltaTime, Space.World);
				else
					transform.Rotate (Vector3.down * turnspeed * Time.deltaTime, Space.World);
				//	transform.Translate(Vector3.forward * boatspeed * Time.deltaTime);
			}
			if (Input.GetKey (KeyCode.RightArrow) || (right && hidearrow)) {
				//			left = false;
				right = true;
				if (!Settings.reverseHands)
					transform.Rotate (Vector3.down * turnspeed * Time.deltaTime, Space.World);
				else
					transform.Rotate (Vector3.up * turnspeed * Time.deltaTime, Space.World);
				//	transform.Translate(Vector3.forward * boatspeed * Time.deltaTime);
			}

			if (Input.GetKeyUp (KeyCode.LeftArrow))
				left = false;

			if (Input.GetKeyUp (KeyCode.RightArrow))
				right = false;

		} 

		else { // if Online


			getStimOnline ();

//			if (left && hidearrow == true)
//				left = true;
//			else left = false;

			if ((left  && hidearrow)&& ldaSignal()>=0) {
					//left = true;

					//			right = false;
					if(!Settings.reverseHands)
						transform.Rotate (Vector3.up * turnspeed * Time.deltaTime, Space.World);
					else
						transform.Rotate (Vector3.down * turnspeed * Time.deltaTime, Space.World);
					//	transform.Translate(Vector3.forward * boatspeed * Time.deltaTime);
				}
			if ((right && hidearrow) && ldaSignal()<=0) {
					//			left = false;

					right = true;
					if(!Settings.reverseHands)
						transform.Rotate (Vector3.down * turnspeed * Time.deltaTime, Space.World);
					else
						transform.Rotate (Vector3.up * turnspeed * Time.deltaTime, Space.World);
					//	transform.Translate(Vector3.forward * boatspeed * Time.deltaTime);
				}

				if(Input.GetKeyUp(KeyCode.LeftArrow))
					left = false;

				if(Input.GetKeyUp(KeyCode.RightArrow))
					right = false;

			}


	}


	void getStim()
	{
		int stim = Receivemarkers.markerint;

		switch (stim)
		{
		case 800: //hide cross
			crossui.enabled = false;
			leftarrow.enabled = false;
			rightarrow.enabled = false;
			cross= false; 
			left = false;
			right = false;
			hidearrow = false;
			break;
		case 786: // show cross
			crossui.enabled = true;
			leftarrow.enabled = false;
			rightarrow.enabled = false;
			cross = true;
			left = false;
			right = false;
			hidearrow = false;
			break;
		case 770: // right arrow
			crossui.enabled = true;
			leftarrow.enabled = false;
			rightarrow.enabled = true;
			cross= true;
			left = false;
			right = true;
			hidearrow = false;
			break;
		case 769: // left arrow
			crossui.enabled = true;
			leftarrow.enabled = true;
			rightarrow.enabled = false;
			cross= true; 
			left = true;
			right = false;
			hidearrow = false;
			break;
		case 781: // hide arrow
			crossui.enabled = true;
			leftarrow.enabled = false;
			rightarrow.enabled = false;
			cross= true;
			hidearrow = true;
			//left= false;
			//right= false;
			break;
		}
	}

	public static float ldaSignal(){
		return Assets.LSL4Unity.Scripts.Examples.ExampleFloatInlet.signal;
	}


	void getStimOnline()
	{
		int stim = Receivemarkers.markerint;

		switch (stim)
		{
		case 800: //hide cross
			crossui.enabled = false;
			leftarrow.enabled = false;
			rightarrow.enabled = false;
			cross= false;
			left = false;
			right = false;
			hidearrow = false;
			break;
		case 786: // show cross
			crossui.enabled = true;
			leftarrow.enabled = false;
			rightarrow.enabled = false;
			cross = true;
			left = false;
			right = false;
			hidearrow = false;
			break;
		case 770: // right arrow
			crossui.enabled = true;
			leftarrow.enabled = false;
			rightarrow.enabled = true;
			cross= true;
			left = false;
			right = true;
			hidearrow = false;
			break;
		case 769: // left arrow
			crossui.enabled = true;
			leftarrow.enabled = true;
			rightarrow.enabled = false;
			cross= true;
			left = true;
			right = false;
			hidearrow = false;
			break;
		case 781: // hide arrow
			crossui.enabled = true;
			leftarrow.enabled = false;
			rightarrow.enabled = false;
			cross= true;
			hidearrow = true;
			break;
			//		default:
			//			cross.enabled = false;
			//			leftarrow.enabled = false;
			//			rightarrow.enabled = false;
			//			break;
		}
	}

}
