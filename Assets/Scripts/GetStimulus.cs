using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetStimulus : MonoBehaviour {

	public Image cross, leftarrow, rightarrow;

	// Use this for initialization
	void Start () {
		
		cross.enabled = false;
		leftarrow.enabled = false;
		rightarrow.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKey("escape"))
		{
			Debug.Log ("Quit!");
			Application.Quit();
		}


		getStim ();

	}


	void getStim()
	{
		int stim = Receivemarkers.markerint;

		switch (stim)
		{
		case 800: //hide cross
			cross.enabled = false;
			leftarrow.enabled = false;
			rightarrow.enabled = false;
			break;
		case 786: // show cross
			cross.enabled = true;
			leftarrow.enabled = false;
			rightarrow.enabled = false;
			break;
		case 770: // right arrow
			cross.enabled = true;
			leftarrow.enabled = false;
			rightarrow.enabled = true;
			break;
		case 769: // left arrow
			cross.enabled = true;
			leftarrow.enabled = true;
			rightarrow.enabled = false;
			break;
		case 781: // hide arrow
			cross.enabled = true;
			leftarrow.enabled = false;
			rightarrow.enabled = false;
			break;
//		default:
//			cross.enabled = false;
//			leftarrow.enabled = false;
//			rightarrow.enabled = false;
//			break;
		}
	}


}
