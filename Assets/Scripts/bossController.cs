using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour {
    public float hitPoints = 10;
    public GameObject target;
    private GameObject spawn;
    System.Random r = new System.Random();
    public float spawnTime = 2.5f;
    private float timer = 0;
    private float lastSpawn = 0;
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
		if (timer - lastSpawn > spawnTime)
        {
            spawn = Instantiate(target, transform.position, Quaternion.identity);
            if (r.Next(0,5) >= 2)
            {
                spawn.GetComponent<targetController>().moveHorizontally = true;
                spawn.GetComponent<targetController>().xMin = Mathf.Clamp(
                    transform.position.x - r.Next(1, 11), xMin, transform.position.x);
                spawn.GetComponent<targetController>().xMax = Mathf.Clamp(
                    transform.position.x + r.Next(1, 11), transform.position.x, xMax);
            }
            if (r.Next(0, 5) >= 4)
            {
                spawn.GetComponent<targetController>().moveVertically = true;
                spawn.GetComponent<targetController>().yMin = transform.position.y;
                spawn.GetComponent<targetController>().yMax = transform.position.y + r.Next(1, 4);
            }
            if (r.Next(0, 5) >= 2)
            {
                spawn.GetComponent<targetController>().moveDepth = true;
                spawn.GetComponent<targetController>().zMin = Mathf.Clamp(
                    transform.position.z - r.Next(1, 11), zMin, transform.position.z);
                spawn.GetComponent<targetController>().zMax = Mathf.Clamp(
                    transform.position.z + r.Next(1, 11), transform.position.z, zMax);
            }
            lastSpawn = timer;
        }
	}
}
