using System;
using UnityEngine;

public class SunBehavior : MonoBehaviour
{
    [SerializeField] private Vector3 forward = Vector3.zero;    

    private void Update()
    {
        this.forward = this.transform.forward;
        this.transform.Rotate(Vector3.right, 18.0f * Time.deltaTime);
    }
}
