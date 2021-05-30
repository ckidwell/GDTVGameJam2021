using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseSelect : MonoBehaviour
{
    [SerializeField] Camera insideCam;
    Animator camAnim;

    // Start is called before the first frame update
    private void Awake()
    {
        var go = GameObject.FindWithTag("InsideCamera");
        insideCam = go.GetComponent<Camera>();
    }

    void Start()
    {
      
        camAnim = insideCam.GetComponent<Animator>();
        camAnim.SetBool("TableFramed", false);
    }

    private void OnMouseDown()
    {
        if (!camAnim.GetBool("TableFramed"))
        {
            camAnim.SetTrigger(gameObject.name);
            camAnim.SetBool("TableFramed", true);
        }else
        {
            camAnim.SetTrigger("BackToDefault");
            camAnim.SetBool("TableFramed", false);
        }
    }
}
