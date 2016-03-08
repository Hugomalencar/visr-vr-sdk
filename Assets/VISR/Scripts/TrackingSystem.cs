using UnityEngine;
using System.Collections;

using VisrSdk;

public class TrackingSystem : MonoBehaviour {

	void Start () {
        SdkTrackingDriver.Instance.Init();
	}
	
	void LateUpdate () {
        SdkTrackingDriver.Instance.UpdateTracking();

        foreach(Transform child in transform)
        {
            TrackingNode node = SdkTrackingDriver.Instance.GetTrackingNode(child.name.ToLower());
            
            if(node != null)
            {
                child.localPosition = node.LocalPosition;
                child.rotation = node.Rotation;
            }
        }
	}
}
