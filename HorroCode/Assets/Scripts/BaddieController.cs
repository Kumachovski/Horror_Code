using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieController : MonoBehaviour
{
	public PlayerControllerInformation pci;
    public float speed;
    private bool right;

	private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        float timeout = Random.Range(10, 21);
        right = true;

		animator = GetComponent<Animator>();

		StartCoroutine(Wait(timeout, Walk()));
    }

    // Update is called once per frame
    void Update()
    {
		if(Mathf.Abs(transform.position.x) < 0.1) {
			if(!pci.hiddenState) {
				//StopAllCoroutines();
			}
		}
    }

	private IEnumerator Wait(float seconds, IEnumerator callback) {
		yield return new WaitForSeconds(seconds);

		StartCoroutine(callback);
	}

	private IEnumerator Walk() {
		animator.SetBool("Walking", true);

		if(right) {
			while(transform.position.x > 0) {
				transform.Translate(0f, 0f, speed * Time.deltaTime);
				yield return null;
			}

			animator.SetTrigger("LookRight");
			yield return new WaitForSeconds(4f);

			while(transform.position.x > -5) {
				transform.Translate(0f, 0f, speed * Time.deltaTime);
				yield return null;
			}
		} else {
			while(transform.position.x < 0) {
				transform.Translate(0f, 0f, speed * Time.deltaTime);
				yield return null;
			}

			animator.SetTrigger("LookLeft");
			yield return new WaitForSeconds(4f);

			while(transform.position.x < 5) {
				transform.Translate(0f, 0f, speed * Time.deltaTime);
				yield return null;
			}
		}

		animator.SetBool("Walking", false);
		transform.Rotate(0f, 180f, 0f);
		right = !right;
		StartCoroutine(Wait(Random.Range(10,21), Walk()));
	}
}
