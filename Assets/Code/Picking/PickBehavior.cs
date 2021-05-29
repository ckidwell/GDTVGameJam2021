using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBehavior : MonoBehaviour
{
    private float moveSpeed = .30f;
    private Rigidbody2D r2d;
    public delegate void Triggered();
    public static event Triggered OnTriggered;
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * moveSpeed * Time.deltaTime;
        r2d.MovePosition(r2d.transform.position + tempVect);
       
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Entering collision 2d in pickbehavior");
        LockContact lc = other.gameObject.GetComponent<LockContact>();
        if (lc != null)
        {
            OnTriggered();
        }
    }
}
