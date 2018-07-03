using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class megaBossController : MonoBehaviour {

    public float hitPoints = 50;
    public GameObject target;
    private GameObject spawn;
    public GameObject rotatePoint;
    public float spawnTime = 2.5f;
    private float timer = 0;
    private float lastSpawn = 0;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer - lastSpawn > spawnTime)
        {
            spawn = Instantiate(target, new Vector3(transform.position.x + 10,
                1, transform.position.z), Quaternion.identity);
            lastSpawn = timer;

            spawn.GetComponent<targetController>().moveAroundPoint = true;
            spawn.GetComponent<targetController>().pointToRotateAround = rotatePoint;
            spawn.GetComponent<targetController>().rotY = true;
        }
    }
}
