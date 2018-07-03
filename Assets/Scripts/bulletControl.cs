using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour {
    public float speed = 10;
    public float rotationSpeed = 180;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * speed * Time.deltaTime;
        transform.Rotate(transform.forward, rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Target")
        { 
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<bossController>().hitPoints--;
            if (collision.gameObject.GetComponent<bossController>().hitPoints <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "MegaBoss")
        {
            collision.gameObject.GetComponent<megaBossController>().hitPoints--;
            if (collision.gameObject.GetComponent<megaBossController>().hitPoints <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        Destroy(gameObject);
    }
    
}
