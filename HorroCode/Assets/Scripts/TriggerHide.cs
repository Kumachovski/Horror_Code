using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHide : MonoBehaviour
{
    public GameObject player;
    public GameObject Baddie;
    public bool PlayerDead;
    // Start is called before the first frame update
    void Start()
    {
        PlayerDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    void OnTriggerEnter(Collider other)
    {
        if (!player.GetComponent<PlayerControllerInformation>().hiddenState)
        {
            PlayerDead = true;
        }
    }
}
