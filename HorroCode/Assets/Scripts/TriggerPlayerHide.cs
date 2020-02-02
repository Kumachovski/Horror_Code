using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayerHide : MonoBehaviour
{
    public PlayerControllerInformation player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
		if(other.tag == "MainCamera") {
        	player.hiddenState = true;
		}
    }
    void OnTriggerExit(Collider other)
    {
		if(other.tag == "MainCamera") {
        	player.hiddenState = false;
		}
    }
}
