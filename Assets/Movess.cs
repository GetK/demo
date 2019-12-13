using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movess : MonoBehaviour
{
    Transform cam;
    Rigidbody rigidbody;
    Vector3 fown;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 forward = (transform.position - cam.position);
        forward.y = 0;
        forward = forward.normalized;

        Vector3 right = Quaternion.Euler(0, 90, 0) * forward;
        fown = forward*v + h*right;
    }
    private void FixedUpdate()
    {
        rigidbody.AddForce(fown * 20);
    }
}
