using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{

    [SerializeField] private Transform player_ship = default;
    // Start is called before the first frame update
    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        player_ship = player.GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        if(player_ship != null)
        transform.position = new Vector3(player_ship.position.x, player_ship.position.y, transform.position.z);
    }
}
