using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetStimulus : MonoBehaviour {

	public Image cross, leftarrow, rightarrow;

	public GameObject EndofSessionPanel;

	//public GameObject lslobject;

	// Use this for initialization
	void Start () {
		
		cross.enabled = false;
		leftarrow.enabled = false;
		rightarrow.enabled = false;
		EndofSessionPanel.SetActive(false);

		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {


		//quit 
		if (Input.GetKey("escape"))
		{
			Debug.Log ("Quit!");
			Application.Quit();
		}

		//reload scene
//		if (Input.GetKey(KeyCode.R))
//		{
//			ReloadScene();
//		}


		getStim ();

		if (Receivemarkers.markerint == 1010) //32770 experiment stop
			EndofSessionPanel.SetActive(true); //pop window

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


//	public void ReloadScene(){
//		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
//		Instantiate(lslobject, new Vector3(0, 0, 0), Quaternion.identity);
//		Debug.Log ("RELOAD Scene!");
//	}


}
