using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostScript : MonoBehaviour {

    public GameObject Parent;

    public Sprite idle;
    public Sprite jump;
	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 tmpPosition = new Vector3(-1 * Parent.transform.position.x, Parent.transform.position.y, this.transform.position.z);
        this.transform.position = tmpPosition;

        bool isJumping = Parent.GetComponent<PlayerMovementScript>().IsJumping;
        Vector3 moveVec = Parent.GetComponent<PlayerMovementScript>().moveVec;

        if (isJumping)
        {
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = jump;
            if (moveVec.x > 0.01)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (moveVec.x < -0.01)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
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
}
