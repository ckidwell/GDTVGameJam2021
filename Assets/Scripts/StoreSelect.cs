using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSelect : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    Animator camAnim;

    // Start is called before the first frame update
    void Start()
    {
        camAnim = mainCam.GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (!camAnim.GetBool("Framed"))
        {
            camAnim.SetTrigger(gameObject.name);
            camAnim.SetBool("Framed", true);
        }
        else
        {
            camAnim.SetTrigger("BackToDefault");
            camAnim.SetBool("Framed", false);
        }
    }
}
