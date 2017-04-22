using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostScript : MonoBehaviour {

    public GameObject Parent;

    public Sprite idle;
	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 tmpPosition = new Vector3(-1 * Parent.transform.position.x, Parent.transform.position.y, this.transform.position.z);
        Vector3 moveVec = Parent.GetComponent<PlayerMovementScript>().moveVec;
        this.transform.position = tmpPosition;

        if (moveVec.x > 0.01)
        {
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveVec.x < -0.01)
        {
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = idle;
        }

    }
}
