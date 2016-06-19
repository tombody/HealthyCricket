using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ControllerPickupParent : MonoBehaviour {

    SteamVR_Controller.Device device;
    SteamVR_TrackedObject trackedObj;

    void Awake ()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	void FixedUpdate ()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        //if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
          //  BowlingMachine.bowlAgain();
	}

    void OnTriggerStay(Collider col)
    {
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            col.attachedRigidbody.isKinematic = true;
            col.gameObject.transform.parent = gameObject.transform;
        }
        if(device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            col.attachedRigidbody.isKinematic = false;
            col.gameObject.transform.parent = null;
            tossObject(col.attachedRigidbody);
        }
    }
    
    void tossObject(Rigidbody rigidBody)
    {
        float throwSpeed = 1.0f; // adjusts the velocity at which an object leaves your hand
        Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
        if (origin != null)
        {
            rigidBody.velocity = origin.TransformVector(device.velocity) * throwSpeed;
            rigidBody.angularVelocity = origin.TransformVector(device.angularVelocity) * throwSpeed;
        }
        else
        {
            rigidBody.velocity = device.velocity;
            rigidBody.angularVelocity = device.angularVelocity;
        }
    }
    
            

}
