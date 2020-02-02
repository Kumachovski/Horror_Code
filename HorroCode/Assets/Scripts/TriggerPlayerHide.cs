using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayerHide : MonoBehaviour
{
    public GameObject player;
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
        player.GetComponent<PlayerControllerInformation>().hiddenState = true;
    }
    void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayerControllerInformation>().hiddenState = false;
    }
}
