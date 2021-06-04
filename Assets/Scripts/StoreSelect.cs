using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSelect : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    Animator camAnim;

    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        mainCam = Camera.main;
        camAnim = mainCam.GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
            //On strip mall view, zoom in on selected store
            if (!camAnim.GetBool("StoreFramed") && !camAnim.GetBool("LockFramed"))
            {
                camAnim.SetTrigger(gameObject.name);
                camAnim.SetBool("StoreFramed", true);
            }
            //If storefront is clicked when not in default view, zoom back out
            else
            {
                // leave the store
                gameController.LeaveStore();
                camAnim.SetTrigger("BackToDefault");
                camAnim.SetBool("StoreFramed", false);
                camAnim.SetBool("LockFramed", false);
            }
    }
}
