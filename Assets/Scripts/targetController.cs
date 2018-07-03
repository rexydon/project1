using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetController : MonoBehaviour
{
    private GameObject gameControllerObject;
    private gameController gameController;
    public GameObject pointToRotateAround;
    public GameObject[] waypoints;
    public bool moveByWayPoints = false;
    public bool moveVertically = false;
    public bool moveHorizontally = false;
    public bool moveDepth = false;
    public bool moveAroundPoint = false;
    public bool rotX = false;
    public bool rotY = false;
    public bool rotZ = false;
    public float rotationSpeed = 90;
    public float speed = 5;
    public float xMin = 0;
    public float xMax = 0;
    public float yMin = 0;
    public float yMax = 0;
    public float zMin = 0;
    public float zMax = 0;
    private Vector3 moveDirection = Vector3.zero;
    private int counter = 0;


    // Use this for initialization
    void Start ()
    {
        gameControllerObject = GameObject.Find("gameController");
        gameController = gameControllerObject.GetComponent<gameController>();
        gameController.targets += 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (moveAroundPoint == true)
        {
            if (rotY == true)
            {
                Vector3 diffrence = transform.position - pointToRotateAround.transform.position;
                float rotation = rotationSpeed * Time.deltaTime;
                Quaternion appliedRotation = Quaternion.AngleAxis(rotation, Vector3.up);
                Vector3 rotatedDiffrence = appliedRotation * diffrence;

                transform.position = pointToRotateAround.transform.position + rotatedDiffrence;
            }
            if (rotX == true)
            {
                Vector3 diffrence = transform.position - pointToRotateAround.transform.position;
                float rotation = rotationSpeed * Time.deltaTime;
                Quaternion appliedRotation = Quaternion.AngleAxis(rotation, Vector3.right);
                Vector3 rotatedDiffrence = appliedRotation * diffrence;

                transform.position = pointToRotateAround.transform.position + rotatedDiffrence;
            }
            if (rotZ == true)
            {
                Vector3 diffrence = transform.position - pointToRotateAround.transform.position;
                float rotation = rotationSpeed * Time.deltaTime;
                Quaternion appliedRotation = Quaternion.AngleAxis(rotation, Vector3.forward);
                Vector3 rotatedDiffrence = appliedRotation * diffrence;

                transform.position = pointToRotateAround.transform.position + rotatedDiffrence;
            }
        }
        if (moveDepth == true)
        {
            if (moveDirection.z == 0 )
            {
                moveDirection = new Vector3(moveDirection.x, moveDirection.y, 1);
            }
            if (transform.position.z < zMin )
            {
                moveDirection = new Vector3(moveDirection.x, moveDirection.y, 1);
            }
            else if(transform.position.z > zMax)
            {
                moveDirection = new Vector3(moveDirection.x, moveDirection.y, -1);
            }
        }
        if (moveHorizontally == true)
        {
            if (moveDirection.x == 0)
            {
                moveDirection = new Vector3(1, moveDirection.y, moveDirection.z);
            }
            if (transform.position.x < xMin)
            {
                moveDirection = new Vector3(1, moveDirection.y, moveDirection.z);
            }
            else if (transform.position.x > xMax)
            {
                moveDirection = new Vector3(-1, moveDirection.y, moveDirection.z);
            }
        }
        if (moveVertically == true)
        {
            if (moveDirection.y == 0)
            {
                moveDirection = new Vector3(moveDirection.x, 1, moveDirection.z);
            }
            if (transform.position.y < yMin)
            {
                moveDirection = new Vector3(moveDirection.x, 1, moveDirection.z);
            }
            else if (transform.position.y > yMax)
            {
                moveDirection = new Vector3(moveDirection.x, -1, moveDirection.z);
            }
        }
        if (moveByWayPoints)
        {
            moveDirection = waypoints[counter].transform.position - transform.position;
            if (System.Math.Abs(moveDirection.x) <=.5 && System.Math.Abs(moveDirection.y) <= .5 && System.Math.Abs(moveDirection.z) <= .5)
            {
                if (counter < waypoints.Length - 1)
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }
            }
        }
        transform.position += moveDirection.normalized * speed * Time.deltaTime;
    }


    private void OnDestroy()
    {
        gameController.targets -= 1;
    }
}
