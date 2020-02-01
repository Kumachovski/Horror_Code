using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeController : MonoBehaviour
{
	public float level = 0;
	public float r = 0.5f;
	public float h = 1;
	private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
		float angle = Vector3.Angle(transform.forward, Vector3.up);
		float rads = angle * Mathf.Deg2Rad;
		
		float l = h * (Mathf.Log(level, 1 / (h / (4f * r))) + 1);

        material.SetFloat("y", transform.position.y + l * Mathf.Cos(rads));

		float x = r * Mathf.Tan(rads);
		if (h < l + x) {
			level -= Time.deltaTime;
		}

		level = Mathf.Clamp(level, 0, 1);
    }
}
