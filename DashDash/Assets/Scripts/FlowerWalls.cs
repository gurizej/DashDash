using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerWalls : MonoBehaviour {

    public GameObject flower;

	// Use this for initialization
	void Start () {
        //TODO: set i = position - 10
        for (float i = transform.position.z - 10; i < transform.position.z + 10; i++)
        {
            GameObject fRight = Instantiate(flower, new Vector3(3, 0, i), Quaternion.identity);
            GameObject fLeft = Instantiate(flower, new Vector3(-3, 0, i), Quaternion.identity);
            fRight.transform.SetParent(transform);
            fLeft.transform.SetParent(transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
