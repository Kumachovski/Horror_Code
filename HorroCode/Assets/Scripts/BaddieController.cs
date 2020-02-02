using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieController : MonoBehaviour
{
    public float timer;
    public float speed;
    public bool right;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(10, 21);
        right = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;

        if (this.transform.position.x < 5f && right && timer > 0)
        {
            this.transform.position = new Vector3(this.transform.position.x + speed, this.transform.position.y, this.transform.position.z);
        }

        if (this.transform.position.x > 4.5f && right && timer < 0)
        {
            timer = Random.Range(10,21);
            right = false;
        }

        if (this.transform.position.x > -5f && !right && timer > 0)
        {
            this.transform.position = new Vector3(this.transform.position.x - speed, this.transform.position.y, this.transform.position.z);
        }

        if (this.transform.position.x < -4.5f && !right && timer < 0)
        {
            timer = Random.Range(10, 21);
            right = true;
        }
    }
}
