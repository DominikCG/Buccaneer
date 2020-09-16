using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_control : MonoBehaviour
{
    [SerializeField] private Camera cam = default;
    [SerializeField] private GameObject[] enemy = default;

    [SerializeField] private float spawn_time = 5;
    private float timer = default;
    [SerializeField] private Vector3 spawn_point = default;
    [SerializeField] private float spawn_x = default;
    [SerializeField] private float spawn_y = default;
    [SerializeField] private float screen_h = default;
    [SerializeField] private float screen_w = default;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        screen_h = 2f * cam.orthographicSize;
        screen_w = screen_h * cam.aspect;

    }

    // Update is called once per frame
    void Update()
    {
        if(screen_h != cam.pixelHeight || screen_w != cam.pixelWidth)
        {
            screen_h = 2f * cam.orthographicSize;
            screen_w = screen_h * cam.aspect;
        }

        timer += Time.deltaTime;
        Spawn_Enemy();
    }


    private void Spawn_Enemy()
    {
        if(timer > spawn_time)
        {

            Set_Spawn_Point();


            int _enemy = Random.Range(0, enemy.Length);
            Instantiate(enemy[_enemy],spawn_point, Quaternion.identity);

            timer = 0f;
        }

    }

    private void Set_Spawn_Point()
    {
        spawn_x = Random.Range(-3,3);
        spawn_y = Random.Range(-3,3);


        if (spawn_x >=0)
            spawn_x += screen_w / 2;
        if (spawn_x <0)
            spawn_x -= screen_w / 2;

        if (spawn_y >=0)
            spawn_y += screen_h / 2;
        if (spawn_y <0)
            spawn_y -= screen_h / 2;

        spawn_point = new Vector3(spawn_x, spawn_y,10);
        spawn_point = cam.transform.position + spawn_point;
    }

}
