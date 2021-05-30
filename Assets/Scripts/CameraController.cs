using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject outsideCam;
    [SerializeField] GameObject insideCam;
    [SerializeField] float movementSpeed = 5.0f;

    //Serialized for testing
    [SerializeField] bool playerInsideStore = false;

    // Start is called before the first frame update
    void Start()
    {
        outsideCam.SetActive(true);
        insideCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInsideStore)
        {
            outsideCam.SetActive(false);
            insideCam.SetActive(true);
        }else
        {
            outsideCam.SetActive(true);
            insideCam.SetActive(false);
        }
    }

    //Meant to be called once the player is successfully in the store
    public void doorIsOpen()
    {
        playerInsideStore = true;
    }
}
