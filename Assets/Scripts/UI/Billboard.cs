using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Camera cam = default;
    [SerializeField] private Transform _transform = default;

    private void Start()
    {
        cam = Camera.main;

    }

    private void Update()
    {

        transform.position =_transform.position + transform.up * 0.8f;
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.transform.forward);
        
    }
}
