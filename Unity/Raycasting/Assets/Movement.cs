using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject myCube;

    private float cubeSpeed;

    private RaycastHit hitObject;

    private float rayLength;

    private Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - myCube.transform.position;

        cubeSpeed = 0.05f;
        rayLength = 50.0f;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = myCube.transform.position + cameraOffset;

        Vector3 oldPos = myCube.transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            myCube.transform.position = (new Vector3(oldPos.x - cubeSpeed, oldPos.y, oldPos.z));
        }

        if (Input.GetKey(KeyCode.D))
        {
            myCube.transform.position = (new Vector3(oldPos.x + cubeSpeed, oldPos.y, oldPos.z));
        }

        if (Input.GetKey(KeyCode.W))
        {
            myCube.transform.position = (new Vector3(oldPos.x, oldPos.y, oldPos.z + cubeSpeed));
        }

        if (Input.GetKey(KeyCode.S))
        {
            myCube.transform.position = (new Vector3(oldPos.x, oldPos.y, oldPos.z - cubeSpeed));
        }

        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(myRay, out hitObject, rayLength))
        {
            hitObject.transform.Rotate(new Vector3(0.0f, 0.5f, 0.0f));

            Renderer r = hitObject.collider.GetComponent<Renderer>();
            r.material.color = Color.green;
        }
    }
}
