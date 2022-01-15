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

    private void Start()
    {
        StartPos = transform.position;
    }

    private void FixedUpdate()
    {
        t += Time.deltaTime;
        Offset = Amp * Mathf.Sin(t * Freq);

        transform.position = StartPos + new Vector3(0, Offset, 0);
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}