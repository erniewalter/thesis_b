using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Clock : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text clockText;
    // Update is called once per frame
    void Update()
    {
        clockText.text = DateTime.Now.ToString();

    }
}
