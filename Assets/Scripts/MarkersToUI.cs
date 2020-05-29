using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkersToUI : MonoBehaviour {

    public Text marker;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

        marker.text = Receivemarkers.markerint.ToString();
    }
}
