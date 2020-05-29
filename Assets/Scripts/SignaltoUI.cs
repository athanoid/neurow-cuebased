using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignaltoUI : MonoBehaviour
{
    public Text lda;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        lda.text = MoveBoat.ldaSignal().ToString();
    }
}
