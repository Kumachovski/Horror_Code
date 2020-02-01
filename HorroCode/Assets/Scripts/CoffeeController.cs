using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeController : MonoBehaviour
{
	public float level = 0;
    public float offset = 0;

	private Material material;
    private Mesh mesh;
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        mesh = GetComponent<MeshFilter>().mesh;
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
		float angle = Vector3.Angle(transform.forward, Vector3.up);
		float rads = angle * Mathf.Deg2Rad;

        float max = renderer.bounds.size[1];

        float l =  max * (Mathf.Cos(rads) / 2f + level + offset - 0.5f);

        material.SetFloat("y", transform.position.y + l);

        float r = mesh.bounds.extents[0];
        float h = mesh.bounds.size[2];

        Debug.Log(r + " " + h);
        
		float x = r * Mathf.Tan(rads);
		if (h < l / Mathf.Cos(rads) + x) {
			level -= Time.deltaTime;
            Debug.Log("leaking!");
		}

		level = Mathf.Clamp(level, 0, 1);
    }
}
