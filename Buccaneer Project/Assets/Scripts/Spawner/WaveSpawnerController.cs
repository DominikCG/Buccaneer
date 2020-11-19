using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveItem
{

    public int Amount;
    public GameObject Enemy;

}

public class WaveSpawnerController : MonoBehaviour
{
    
    [SerializeField] private List<WaveItem> _enemies = default;
    [SerializeField] private int _maxEnemiesSpawned = 5;
    [SerializeField] private float _spawnTime = 2f;

    [SerializeField] private LayerMask dont_spawn_layer = default;
    [SerializeField] private float check_radius = default;
    
    private float _screenHeight = default;
    private float _screenWidth = default;
    private Camera _camera;

    private List<Vector3> tryList;

    private int _currentAlive = 0;

    void Start()
    {
        _camera = Camera.main;
        _screenHeight = 2f * _camera.orthographicSize;
        _screenWidth = _screenHeight * _camera.aspect;
        
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        int spawnAmount = 0;
        foreach (var item in _enemies)
        {
            spawnAmount += item.Amount;
        }


        int index = 0;
        while (true)
        {
            yield return new WaitWhile(() => _currentAlive >= _maxEnemiesSpawned);

            int tries = 0;
            while (_enemies[index].Amount <= 0)
            {
                tries += 1;
                if (tries >= _enemies.Count) break;
                index = (index + 1) % _enemies.Count;
            }
            if (tries >= _enemies.Count) break;
            
            tryList = new List<Vector3>();
            GameObject created = Instantiate(_enemies[index].Enemy, GetSpawnPoint(), Quaternion.identity);
            _enemies[index].Amount -= 1;
            _currentAlive += 1;

            created.GetComponent<Enemy>().OnDeah += () => _currentAlive -= 1;

            yield return new WaitForSeconds(_spawnTime);
            index = (index + 1) % _enemies.Count;
        }

        yield return new WaitWhile(() => _currentAlive > 0);
        GameObject.FindObjectOfType<Game_UI>().Victory();
    }

    private Vector3 GetSpawnPoint()
    {
        float spawn_x = Random.Range(-3f, 3f);
        float spawn_y = Random.Range(-3f, 3f);

        if (spawn_x >=0)
            spawn_x += _screenWidth / 2;
        if (spawn_x <0)
            spawn_x -= _screenWidth / 2;

        if (spawn_y >=0)
            spawn_y += _screenHeight / 2;
        if (spawn_y <0)
            spawn_y -= _screenHeight / 2;

        Vector3 spawn_point = new Vector3(spawn_x, spawn_y, 10);
        spawn_point = _camera.transform.position + spawn_point;

        if (!CheckOverlap(spawn_point))
        {
            tryList.Add(spawn_point);
            return GetSpawnPoint();
        }

        return spawn_point;
    }

    private bool CheckOverlap(Vector3 pos)
    {
        Collider2D coll = Physics2D.OverlapCircle(pos, check_radius, dont_spawn_layer);
        return coll == null;
    }

    void OnDrawGizmos()
    {
        if (tryList == null) return;
        foreach (var item in tryList)
        {
            Gizmos.DrawWireSphere(item, .5f);
        }
    }

}
