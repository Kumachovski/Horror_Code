using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeDropper : MonoBehaviour
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

	private void OnParticleCollision(GameObject other) {
		if(other.layer == LayerMask.NameToLayer("Coffee") || (other.transform.childCount > 0 && other.transform.GetChild(0).gameObject.layer == LayerMask.NameToLayer("Coffee"))) {
			CoffeeController cc = null;

			try {
				cc = GetComponent<CoffeeController>();
			} catch { }

			try {
				cc = other.transform.GetChild(0).GetComponent<CoffeeController>();
			} catch { }
			
			if(cc != null) {
				cc.level += 0.0005f;
			}			
		}

		if(other.layer == LayerMask.NameToLayer("Player")) {
			player.coffee += 0.5f;
		}
	}
}
