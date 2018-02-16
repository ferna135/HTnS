using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour
{
    public GameObject cube;
    private GameObject[] cubes;
    public List<GameObject> randomCubes;
    public List<int> cubeCheck;

    public int gameDif = 5;



    // Use this for initialization
    void Start()
    {
        for (int y = 1; y < 8; y++) //Creting the block of cubes
        {


            for (int x = -100; x < -93; x++)
            {
                Vector3 spawnPos = new Vector3(x, y, 10f);
                Instantiate(cube, spawnPos, Quaternion.identity);
            }
        }

        cubes = GameObject.FindGameObjectsWithTag("EditorOnly");
        Debug.Log(cubes.Length);

        randomCubes = new List<GameObject>();

        CubeMooving();



    }

    // Update is called once per frame
    void Update()
    {
        //impCube.transform.Rotate(0, 100 * Time.deltaTime, 0);



    }
    void CubeMooving()//finding the cubes with the tag, picking random cubes and moving them by fixed position
                      // gameDif is a number of cubes that will be moved 
    {

        for (int i = 0; i < gameDif; i++)
        {

            int cubsNumber = Random.Range(0, cubes.Length);
            while (!cubeCheck.Contains(cubsNumber))
            {
                cubes[cubsNumber].transform.Translate(new Vector3(-10f, 0, 0));
                cubes[cubsNumber].layer = 9;
                cubeCheck.Add(cubsNumber);
                randomCubes.Add(cubes[cubsNumber]);
            }
            

            
        }

        Debug.Log("Random cubes: " + randomCubes.Count);




    }

}
