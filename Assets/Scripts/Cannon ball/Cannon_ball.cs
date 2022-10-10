using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_ball : MonoBehaviour
{
    [SerializeField] private GameObject explosion_effect = default;
    [SerializeField] private float time = default;
    [SerializeField] private int damage = default;
    [SerializeField] private bool player_ball = default;
    [SerializeField] private bool enemy_ball = default;

    private void Update()
    {
        time += Time.deltaTime;

        if (time > 3)
            Explosion();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit_obj = collision.gameObject;

        if (player_ball && hit_obj.CompareTag("Enemy_shooter") || hit_obj.CompareTag("Enemy_chaser"))
        {
            hit_obj.gameObject.GetComponent<Enemy>().Take_Damage(damage);
            Explosion();
        }
        else if (enemy_ball && hit_obj.CompareTag("Player"))
        {
            hit_obj.gameObject.GetComponent<Player_health>().Take_Damage(damage);
            Explosion();
        }
        else
        {
            Explosion();
        }
        
    }

    private void Explosion()
    {
        GameObject effect = Instantiate(explosion_effect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }

    public void Set_Ball_Damage(int _damage)
    {
        damage = _damage;
    }

    public void Shoot_From_Player(bool _player_ball)
    {
        player_ball = _player_ball;
    }
    public void Shoot_From_Enemy(bool _enemy_ball)
    {
        enemy_ball = _enemy_ball;
    }
}
