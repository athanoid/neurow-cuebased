﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class MatchWidth : MonoBehaviour
{

    // Set this to the in-world distance between the left & right edges of your scene.
    public float sceneWidth = 10;

    public float horizontalFoV = 90.0f;

    Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Adjust the camera's height so the desired scene width fits in view
    // even if the screen/window size changes dynamically.
    void Update()
    {
        //  float unitsPerPixel = sceneWidth / Screen.width;

        //   float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

        //   _camera.orthographicSize = desiredHalfHeight;

        float halfWidth = Mathf.Tan(0.5f * horizontalFoV * Mathf.Deg2Rad);

        float halfHeight = halfWidth * Screen.height / Screen.width;

        float verticalFoV = 2.0f * Mathf.Atan(halfHeight) * Mathf.Rad2Deg;

        _camera.fieldOfView = verticalFoV;

    }


    


}