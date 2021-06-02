using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float moveSpeed = 100f;
    float t = 0f;
    public Vector3 desiredPos;
    public Vector3 defaultPos;
    public bool zoomIn = false;
    public bool zoomOut = false;
    public bool tableFramed = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xAxisValue = 0f;

        //Only accept input if we're not framed on a table
        if(!tableFramed)
            xAxisValue = Input.GetAxisRaw("Horizontal");

        //If the player moves right or left
        if (Mathf.Abs(xAxisValue) > 0)
        {
            transform.Translate(new Vector3(xAxisValue*moveSpeed*Time.deltaTime, 0.0f, 0.0f));

            if (transform.position.x < 778)
                transform.position = new Vector3(778, transform.position.y, transform.position.z);
            if(transform.position.x > 1140)
                transform.position = new Vector3(1140, transform.position.y, transform.position.z);
        }

        if(zoomIn)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(defaultPos, desiredPos, t);
            if (t >= 1)
            {
                zoomIn = false;
                tableFramed = true;
                t = 0;
            }
        }
        if (zoomOut)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(desiredPos, defaultPos, t);
            if (t >= 1)
            {
                zoomOut = false;
                tableFramed = false;
                t = 0;
            }
        }
    }

}
