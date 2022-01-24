using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float t = 0;
    public float Amp = 0.25f;
    public float Freq = 3;
    public float Offset = 0;
    public Vector3 StartPos;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartPos = transform.position;
    }

    private void Update()

    {
        t += Time.deltaTime;
        Offset = Amp * Mathf.Sin(t * Freq);

        rb.transform.position =  StartPos + new Vector3(0, Offset, 0);
        rb.transform.Rotate(new Vector3(45, 45, 45) * Time.deltaTime);
    }
}