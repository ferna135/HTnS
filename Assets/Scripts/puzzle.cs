using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour {
    public GameObject cube;
    private GameObject[] cubes;
    public int gameDif = 5;
    


	// Use this for initialization
	void Start () {
        for (int y = -7; y < 0; y++)
        {
            
            
            for (int x = 20; x < 27; x++)
            {
                Vector3 spawnPos = new Vector3(x, y, 10f);
                Instantiate(cube, spawnPos, Quaternion.identity);
            }
        }

        cubes = GameObject.FindGameObjectsWithTag("cube");

        Debug.Log(cubes.Length);
        CubeMooving();
        
    }
	
	// Update is called once per frame
	void Update () {
        //impCube.transform.Rotate(0, 100 * Time.deltaTime, 0);
        
        
        
    }
    void CubeMooving()
    {
        
        for (int i = 0; i < gameDif; i++)
        {
            int cubsNumber = Random.Range(0, cubes.Length);
            cubes[cubsNumber].transform.Translate(new Vector3(-10f, 0, 0));
            cubes[cubsNumber].layer = 9;
            cubes = GameObject.FindGameObjectsWithTag("cube");
        }
        
        


    }

}
