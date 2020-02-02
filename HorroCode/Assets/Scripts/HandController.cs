using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device controller
     {
         get { return SteamVR_Controller.Input((int)trackedObject.index); }
     }
 
	private GameObject selectedObject;
	private Vector3 posDiff;
	private Quaternion rotDiff;


    // Start is called before the first frame update
    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
		if(selectedObject && controller.GetHairTriggerDown()) {
			selectedObject.GetComponent<Rigidbody>().isKinematic = true;
		}
		if(selectedObject && controller.GetHairTriggerUp()) {
			selectedObject.GetComponent<Rigidbody>().isKinematic = false;
		}

        if(selectedObject && controller.GetHairTrigger()) {
			selectedObject.transform.position = transform.position + posDiff;
			selectedObject.transform.rotation = transform.rotation * rotDiff;
		}
    }

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.layer == LayerMask.NameToLayer("Interactable")) {
			selectedObject = other.gameObject;

			posDiff = transform.position - other.transform.position;
			rotDiff = transform.rotation * Quaternion.Inverse(other.transform.rotation);
		}
	}
	private void OnTriggerExit(Collider other) {
		if(other.gameObject == selectedObject && !controller.GetHairTrigger()) {
			selectedObject = null;
			other.GetComponent<Rigidbody>().isKinematic = false;
		}
	}
}
