using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Configurations : MonoBehaviour
{
    public static Game_Configurations Config { get; set; }
    [SerializeField]private float game_time = default;
    [SerializeField]private float spawn_time = default;

    private void Awake()
    {
        if(Config == null)
        {
            Config = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void Set_Game_Time(float _game_time)
    {
        game_time = _game_time;
        Debug.Log(game_time + "<<>>" + _game_time);
    }
    public void Set_Spawn_Time(float _spawn_time)
    {
        spawn_time = _spawn_time;
        Debug.Log(spawn_time + "<<>>" + _spawn_time);
    }


    public float Get_Game_Time()
    {
        return game_time;
    }
    public float Get_Spawn_Time()
    {
        return spawn_time;
    }
}
