using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockZoom : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] Collider2D doorCollider;
    Animator camAnim;

    // Start is called before the first frame update
    void Start()
    {
        camAnim = mainCam.GetComponent<Animator>();
        doorCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(camAnim.GetBool("StoreFramed"))
        {
            doorCollider.enabled = true;
            camAnim.SetBool("LockFramed", false);
        } else
        {
            doorCollider.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if(camAnim.GetBool("StoreFramed"))
        {
            camAnim.SetTrigger(gameObject.name);
            camAnim.SetBool("LockFramed", true);
            camAnim.SetBool("StoreFramed", false);
        }
    }
}
