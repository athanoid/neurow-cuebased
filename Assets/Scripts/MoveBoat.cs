using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveBoat : MonoBehaviour {

	public static float boatspeed = 5f;//default = 5
	public static float turnspeed = 10f;
	public static float stoppingAngle = 45f;

	public Transform compass;
	public GameObject EndofSessionPanel;

	public Image crossui, leftarrow, rightarrow;
	public static bool cross, left, right, hidearrow = false;
	public static bool training;

	// Use this for initialization
	void Start () {

		Cursor.visible = false;
		//settings
		EndofSessionPanel.SetActive(false);
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

		if (Input.GetKey("escape"))
		{
			Debug.Log ("Quit!");
			Application.Quit();
		}

		//Debug.Log (Assets.LSL4Unity.Scripts.Examples.ExampleFloatInlet.signal);

		// if simple ERD is selected, then only FWD, else FWD is automatic and L/R is through LDA input
		//if(Input.GetKey(KeyCode.UpArrow))
		transform.Translate(Vector3.forward * boatspeed * Time.deltaTime);

		//if((compass.localEulerAngles.y >= (360 - stoppingAngle) && compass.localEulerAngles.y <= 360) || (compass.localEulerAngles.y >= 0 && compass.localEulerAngles.y <= (0 + stoppingAngle)))
		//	transform.Translate(Vector3.forward * boatspeed * Time.deltaTime);

		if (Assets.LSL4Unity.Scripts.Examples.ReceiveLSLmarkers.markerint == 1010 || Assets.LSL4Unity.Scripts.Examples.ReceiveLSLmarkers.markerint == 11) //32770 experiment stop
			EndofSessionPanel.SetActive(true); //pop window
                      
        //Debug.Log ("End of Session!");
        if (Assets.LSL4Unity.Scripts.Examples.ReceiveLSLmarkers.markerint == 33282 || Assets.LSL4Unity.Scripts.Examples.ReceiveLSLmarkers.markerint == 2) //32770 experiment start
            EndofSessionPanel.SetActive(false); //pop window

        //Todo
        // on 32770 experiment stop
        // quit app
        //if (Assets.LSL4Unity.Scripts.Examples.ReceiveLSLmarkers.markerint == 32770) //32770
			//Debug.Log ("32770 experiment stop");
		


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

			if (Input.GetKey (KeyCode.LeftArrow) ||((left  && hidearrow) && ldaSignal()<0.0f)) {
					left = true;
					right = false;

					if(!Settings.reverseHands)
						transform.Rotate (Vector3.up * turnspeed * Time.deltaTime, Space.World);
					else
						transform.Rotate (Vector3.down * turnspeed * Time.deltaTime, Space.World);
					//	transform.Translate(Vector3.forward * boatspeed * Time.deltaTime);
				}
			if (Input.GetKey (KeyCode.RightArrow) ||((right && hidearrow) && ldaSignal()>=0.0f)) {
					left = false;
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
		int stim = Assets.LSL4Unity.Scripts.Examples.ReceiveLSLmarkers.markerint;

		switch (stim)
		{
		case 800: case 10: //hide cross
            crossui.enabled = false;
			leftarrow.enabled = false;
			rightarrow.enabled = false;
			cross= false; 
			left = false;
			right = false;
			hidearrow = false;
			break;
		case 33282: case 6: //beep
            crossui.enabled = true;
			leftarrow.enabled = false;
			rightarrow.enabled = false;
			cross = true;
			left = false;
			right = false;
			hidearrow = false;
			break;  
		case 786: case 5: // show cross
            crossui.enabled = true;
			leftarrow.enabled = false;
			rightarrow.enabled = false;
			cross = true;
			left = false;
			right = false;
			hidearrow = false;
			break;
		case 770: case 8: // right arrow
            crossui.enabled = true;
			leftarrow.enabled = false;
			rightarrow.enabled = true;
			cross= true;
			left = false;
			right = true;
			hidearrow = false;
			break;
		case 769: case 7: // left arrow
            crossui.enabled = true;
			leftarrow.enabled = true;
			rightarrow.enabled = false;
			cross= true; 
			left = true;
			right = false;
			hidearrow = false;
			break;
		case 781: case 9: // hide arrow
            crossui.enabled = true;
			leftarrow.enabled = false;
			rightarrow.enabled = false;
			cross= true;
			hidearrow = true;
			//left= false;
			//right= false;
			break;
        default:
            crossui.enabled = false;
            leftarrow.enabled = false;
            rightarrow.enabled = false;
            cross = false;
            left = false;
            right = false;
            hidearrow = false;
            break;
        }
	}

	public static float ldaSignal(){
        return Assets.LSL4Unity.Scripts.Examples.ReceiveLSLsignal.signal;
    }


	void getStimOnline()
	{
		int stim = Assets.LSL4Unity.Scripts.Examples.ReceiveLSLmarkers.markerint;

		switch (stim)
		{
        case 800: case 10: //hide cross
            crossui.enabled = false;
			leftarrow.enabled = false;
			rightarrow.enabled = false;
			cross= false;
			left = false;
			right = false;
			hidearrow = false;
			break;
		case 33282: case 6://beep
            crossui.enabled = true;
			leftarrow.enabled = false;
			rightarrow.enabled = false;
			cross = true;
			left = false;
			right = false;
			hidearrow = false;
			break;  
		case 786: case 5:// show cross
            crossui.enabled = true;
			leftarrow.enabled = false;
			rightarrow.enabled = false;
			cross = true;
			left = false;
			right = false;
			hidearrow = false;
			break;
		case 770: case 8:// right arrow
            crossui.enabled = true;
			leftarrow.enabled = false;
			rightarrow.enabled = true;
			cross= true;
			left = false;
			right = true;
			hidearrow = false;
			break;
		case 769: case 7:// left arrow
            crossui.enabled = true;
			leftarrow.enabled = true;
			rightarrow.enabled = false;
			cross= true;
			left = true;
			right = false;
			hidearrow = false;
			break;
		case 781: case 9:// hide arrow
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
