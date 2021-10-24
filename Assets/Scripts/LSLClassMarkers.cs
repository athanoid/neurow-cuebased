﻿using System.Collections; 
using UnityEngine;
using UnityEngine.UI;
using Assets.LSL4Unity.Scripts.AbstractInlets;

namespace Assets.LSL4Unity.Scripts.Examples
{

    /// <summary>
    /// Example that works with the Resolver component.
    /// This script waits for the resolver to resolve a Stream which matches the Name and Type.
    /// See the base class for more details. 
    /// 
    /// The specific implementation should only deal with the moment when the samples need to be pulled
    /// and how they should processed in your game logic
    ///
    /// </summary>
    public class LSLClassMarkers : InletFloatSamples
    {

        private bool pullSamplesContinuously = false;

        private static int lslsample;
        public int lslDebug;

        //public Text stim1;
        //public Text stim2;


        public static int getLSLsample
        {
            get { return lslsample; }   // get
            set { lslsample = value; }  // set
        }

        void Start()
        {
            // [optional] call this only, if your gameobject hosting this component
            // got instantiated during runtime

            registerAndLookUpStream();
        }

        protected override bool isTheExpected(LSLStreamInfoWrapper stream)
        {
            // the base implementation just checks for stream name and type
            var predicate = base.isTheExpected(stream);
            // add a more specific description for your stream here specifying hostname etc.
            //predicate &= stream.HostName.Equals("Expected Hostname");
            return predicate;
        }

        /// <summary>
        /// Override this method to implement whatever should happen with the samples...
        /// IMPORTANT: Avoid heavy processing logic within this method, update a state and use
        /// coroutines for more complexe processing tasks to distribute processing time over
        /// several frames
        /// </summary>
        /// <param name="newSample"></param>
        /// <param name="timeStamp"></param>
        protected override void Process(float[] newSample, double timeStamp)
        {

            getLSLsample = (int)newSample[0];

            lslDebug = getLSLsample;
            //Debug.Log("Class Marker: " + getLSLsample);

            //stim1.text = lslsignal.ToString();
            //stim2.text = lslsignal.ToString();

        }

        protected override void OnStreamAvailable()
        {
            pullSamplesContinuously = true;
        }

        protected override void OnStreamLost()
        {
            pullSamplesContinuously = false;
        }

        private void Update()
        {
            if (pullSamplesContinuously)
                pullSamples();
        }
    }
}