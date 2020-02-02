using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeDropper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnParticleCollision(GameObject other) {
		CoffeeController cc = other.transform.GetChild(0).GetComponent<CoffeeController>();
		cc.level += 0.01f;
	}
}
