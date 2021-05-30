using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        float xAxisValue = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(xAxisValue) > 0)
        {
            animator.enabled = false;
            transform.Translate(new Vector3(xAxisValue, 0.0f, 0.0f));
        }
    }
}
