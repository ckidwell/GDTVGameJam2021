using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBehavior : MonoBehaviour
{
    private SoundController soundController;
    private float moveSpeed = .30f;
    private Rigidbody2D r2d;
    public delegate void Triggered();
    public static event Triggered OnTriggered;
    private float jiggleTime;
    void Start()
    {
        soundController = GameObject.Find("GameController").GetComponent<SoundController>();
        jiggleTime = Time.time + 2f;
        r2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * moveSpeed * Time.deltaTime;
        r2d.MovePosition(r2d.transform.position + tempVect);

        if (jiggleTime < Time.time)
            JiggleTime();
    }

    private void JiggleTime()
    {
        jiggleTime = Time.time + Random.Range(2.5f, 4.1f);
        soundController.PlayLockJiggle();
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
