using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [System.Serializable]
    public class Weapon
    {
        public string name;
        public int damage;
        public float fireRate;
    }

    public Weapon currentWeapon;
    public Weapon[] weaponList;

    public GameObject projectile;

    public float projectileSpeed = 10f;

    private float timer;
    public float shotWaitTime;

    void Start()
    {
        currentWeapon = weaponList[0];
    }

    void Update()
    {

        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= currentWeapon.fireRate)
        {
            timer = 0;

            Vector3 projectileRotation = transform.eulerAngles + projectile.transform.eulerAngles;

            GameObject spawn = Instantiate(projectile, transform.position, Quaternion.Euler(projectileRotation));

            spawn.GetComponent<Rigidbody>().velocity = transform.forward * projectileSpeed;

            Destroy(spawn, 5);

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = weaponList[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = weaponList[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = weaponList[2];
        }
    }
}
