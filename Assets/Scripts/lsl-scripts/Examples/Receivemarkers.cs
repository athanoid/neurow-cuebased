using UnityEngine;
using System;
using System.Linq;
using Assets.LSL4Unity.Scripts;
using Assets.LSL4Unity.Scripts.AbstractInlets;

public class Receivemarkers : AIntInlet {

	public string marker = String.Empty;
	public static int markerint;

		protected override void Process(int[] newSample, double timeStamp)
		{
			// just as an example, make a string out of all channel values of this sample
			marker = string.Join(" ", newSample.Select(c => c.ToString()).ToArray());

			//Debug.Log(string.Format("Got {0} samples at {1}", newSample.Length, timeStamp));
			//marker = newSample [0];
			//Debug.Log (marker);
			markerint = newSample [0];
		}

	}

