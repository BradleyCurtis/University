using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int bulletDamage;

    private void Start()
    {
        PlayerShoot player = FindObjectOfType<PlayerShoot>();
        bulletDamage = player.currentWeapon.damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {

            Enemy enemy = other.GetComponent<Enemy>();


            enemy.health = enemy.health - bulletDamage;
            Destroy(gameObject);
        }
    }
   
}
