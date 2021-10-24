using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.LSL4Unity.Scripts.Examples;

public class MarkersToUI : MonoBehaviour {

    public Text marker;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

        marker.text = LSLMIMarkers.getLSLsample.ToString();
    }
}
