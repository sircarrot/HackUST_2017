using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchScript : MonoBehaviour
{
    public GameObject doorScript_Var;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        doorScript_Var.GetComponent<doorScript>().on = false;
        this.transform.localScale = new Vector3(-1,1,1);
    }
}
