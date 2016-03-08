using UnityEngine;
using System.Collections;

[SelectionBase]
[RequireComponent(typeof(Rigidbody))]
public class ExplodingBottle : MonoBehaviour {

    Vector3 worldPosition;
    Quaternion worldRotation;

    Rigidbody rigidBody;
    bool triggered = false;

    void Start()
    {
        worldPosition = transform.position;
        worldRotation = transform.rotation;

        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!triggered && rigidBody.velocity.sqrMagnitude > 0.5f)
        {
            triggered = true;
            Invoke("SendResetToParent", 10.0f);

            if(ScoreBoard.Instance != null)
            {
                ScoreBoard.Instance.IncrementScore();
            }
        }
    }

    //resets all the bottles in this group
    void SendResetToParent()
    {
        transform.parent.BroadcastMessage("ResetToStart");
    }

    void ResetToStart()
    {
        transform.position = worldPosition;
        transform.rotation = worldRotation;
        rigidBody.velocity = Vector3.zero;

        triggered = false;
    }

    void OnLookStateAction(RaycastHit rayHit)
    {
        Handheld.Vibrate();
        GetComponent<Rigidbody>().AddForceAtPosition(rayHit.normal * -5, rayHit.point, ForceMode.Impulse);
    }
}
