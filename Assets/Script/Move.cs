using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float higiht;
    public float radius;
    int dirIndex = 0;

    public Transform Targetpos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
    void FixedUpdate()
    {
        Vector3[] pose = new Vector3[]
        {
            new Vector3(0,0,-radius),
            new Vector3 (radius,0,0),
            new Vector3 (0,0,radius),
            new Vector3(-radius,0,0)
        };
        if (Input.GetKeyDown(KeyCode.J))
        {
                dirIndex++;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
                dirIndex--;
        }
        if (dirIndex > 3) dirIndex = 0;
        if (dirIndex < 0) dirIndex = 3;

        Vector3 offset = transform.position - Targetpos.position;
        offset.y = 0;
        Vector3 temp = pose[dirIndex];
        offset = Vector3.Slerp(offset, temp, 0.1f);
        transform.position = offset + Targetpos.position + new Vector3(0, higiht, 0);
        transform.LookAt(Targetpos.position);
    }
}
