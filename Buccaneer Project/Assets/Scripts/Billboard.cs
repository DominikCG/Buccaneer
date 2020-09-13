using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;
    [SerializeField] private Transform player_transform = default;
    


    private void Update()
    {

        transform.position =player_transform.position - transform.up * 0.8f;
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
        
    }
}
