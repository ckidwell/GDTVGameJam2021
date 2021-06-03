using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseSelect : MonoBehaviour
{
    [SerializeField] Camera insideCam;
    [SerializeField] Vector3 zoomPos;


    // Start is called before the first frame update
    private void Awake()
    {
        var go = GameObject.FindWithTag("InsideCamera");
        insideCam = go.GetComponent<Camera>();
    }

    void Start()
    {
        SetDesiredPos();
    }

    void SetDesiredPos()
    {
        zoomPos = transform.position + new Vector3(0,50,-115);
    }

    private void OnMouseDown()
    {
        if (!insideCam.GetComponent<CameraMovement>().tableFramed)
        {
            insideCam.GetComponent<CameraMovement>().zoomIn = true;
            insideCam.GetComponent<CameraMovement>().defaultPos = insideCam.transform.position;
            insideCam.GetComponent<CameraMovement>().desiredPos = zoomPos;


            //camAnim.SetTrigger(gameObject.name);
            //camAnim.SetBool("TableFramed", true);
        }else
        {
            insideCam.GetComponent<CameraMovement>().zoomOut = true;
            //insideCam.GetComponent<CameraMovement>().desiredPos = insideCam.GetComponent<CameraMovement>().defaultPos;
            //insideCam.GetComponent<CameraMovement>().defaultPos = insideCam.transform.position;
            //startPos = insideCam.transform.position;

            //insideCam.GetComponent<CameraMovement>().ZoomOnCase(startPos, defaultPos);
            //camAnim.SetTrigger("BackToDefault");
            //camAnim.SetBool("TableFramed", false);
        }
    }
}
