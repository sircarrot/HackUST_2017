using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerMovementScript : MonoBehaviour {

    public int Player;
    public float moveSpeed = 0.5f;
    public float JumpSpeed = 5f;

    public bool IsJumping = false;

    Rigidbody2D myBody;
	// Use this for initialization
	void Start ()
    {
        myBody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 moveVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal_" + Player), 0, 0) * moveSpeed;
        this.transform.Translate(moveVec);
    }

    public void JumpCommand()
    {
        if (IsJumping == false)
        {
            myBody.velocity += JumpSpeed * Vector2.up;
            IsJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            IsJumping = false;
        }
    }
}
