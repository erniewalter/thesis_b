using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

using TMPro;

public class GetPosition : MonoBehaviour
{
    public GameObject sphereMarker;
    GameObject leftIndexObject, rightIndexObject;
    public MixedRealityPose leftPose, rightPose;
    private Vector3 left, right, distance;

    public TMP_Text posText;

    // Start is called before the first frame update
    void Start()
    {
        rightIndexObject = Instantiate(sphereMarker, this.transform);
        leftIndexObject = Instantiate(sphereMarker, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        rightIndexObject.GetComponent<Renderer>().enabled = false;
        leftIndexObject.GetComponent<Renderer>().enabled = false;

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out rightPose))
        {
            rightIndexObject.GetComponent<Renderer>().enabled = true;
            rightIndexObject.transform.position = rightPose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out leftPose))
        {
            leftIndexObject.GetComponent<Renderer>().enabled = true;
            leftIndexObject.transform.position = leftPose.Position;
        }

        right = rightIndexObject.transform.position;
        left = leftIndexObject.transform.position;

        distance = left - right;
        posText.text = distance.ToString("F4");
    
      
    }

  
}