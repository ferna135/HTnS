using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    //Code based on PushyPixels video
    //Link: https://www.youtube.com/watch?v=sxjJTNDmsug


    public float grabDistance = 10f;
    public string grabButton = "Fire1";
    public Transform holdPosition;
    public LayerMask layerMask = -1;
    public bool defaultObjectState = false;

    public Texture2D crossHairImage;


    public float smooth = 5f;
    private Quaternion targetRotation;

    public puzzle puzzleScript;

    private GameObject heldObject = null;

    // Use this for initialization
    void Start()
    {
    }

    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (crossHairImage.width / 2);
        float yMin = (Screen.height / 2) - (crossHairImage.height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, crossHairImage.width, crossHairImage.height), crossHairImage);
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 middleOfScreen = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray myRay = Camera.main.ScreenPointToRay(middleOfScreen);
        Debug.Log(heldObject);
        if (heldObject == null)
        {
            if (Input.GetButton(grabButton))
            {
                RaycastHit hit;
                if (Physics.Raycast(myRay, out hit, grabDistance, layerMask))
                {
                    heldObject = hit.collider.gameObject;
                    for (int i = 0; i < puzzleScript.randomCubes.Count; i++)
                    {
                        //Code for cube puzzle, that allows to move several cube block as one
                        if (puzzleScript.randomCubes[i] == heldObject)
                        {
                            for (int j = 0; j < puzzleScript.randomCubes.Count; j++)
                                if (puzzleScript.randomCubes[j] != heldObject)
                                {
                                    puzzleScript.randomCubes[j].transform.parent = heldObject.transform;
                                }
                        }
                    }
                    
                    defaultObjectState = heldObject.GetComponent<Rigidbody>().isKinematic;
                    heldObject.GetComponent<Rigidbody>().isKinematic = true;
                }


            }

        }
        else
        //Object is grabbed
        {
            //Rotate to the left
            if (Input.GetKey(KeyCode.Q))
            {
                RotateObject(heldObject, "l");
            }

            //Rotate to the right
            if (Input.GetKey(KeyCode.E))
            {
                RotateObject(heldObject, "r");
            }



            //Let go of the object
            if (Input.GetButtonUp(grabButton))
            {
                heldObject.GetComponent<Rigidbody>().isKinematic = defaultObjectState;
                heldObject = null;

                
                for (int i = 0; i < puzzleScript.randomCubes.Count; i++)
                {
                    puzzleScript.randomCubes[i].transform.parent = null;
                }
            }
            else
            {
                heldObject.transform.position = holdPosition.position;
            }

        }

    }



    void RotateObject(GameObject obj, string orientation)
    {


        targetRotation = obj.transform.rotation;

        if (orientation == "l")
        {
            targetRotation *= Quaternion.AngleAxis(-10, Vector3.forward);
            obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
        }

        if (orientation == "r")
        {
            targetRotation *= Quaternion.AngleAxis(10, Vector3.forward);
            obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
        }

    }



}
