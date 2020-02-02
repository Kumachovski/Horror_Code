using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControllerInformation : MonoBehaviour
{
	
	public GameObject hunger;
	public GameObject coffeine;
    public Animator animator;
    public bool hiddenState;
    public float coffee;
    public float food;
    public float timer;
  
    // Start is called before the first frame update
    void Start()
    {
     
		timer += Time.deltaTime;
        hiddenState = false;
        coffee = 100.0f;
		food = 100.0f;
      
    }

    // Update is called once per frame
    void Update()
    {
	    food -= timer;
	    coffee -= timer;
       
	    coffeine.transform.localScale = new Vector3(coffee/10f,coffeine.transform.localScale.y,coffeine.transform.localScale.z);
	    hunger.transform.localScale = new Vector3(food/10f,hunger.transform.localScale.y,hunger.transform.localScale.z);

        animator.SetFloat("SleepyState", coffee);
	}

}
