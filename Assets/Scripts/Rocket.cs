using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 20f;
    public GameObject shellPrefab;
    public Weapon weapon;
    public GameObject explosionParticles;
    public AudioClip damageSound;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    public void InstantiateShell()
    {

        Instantiate(weapon.bulletPrefab, transform.position, transform.rotation);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        AudioSystem.Play(damageSound);
        var health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(10);
        }
        // Destroy(gameObject);
        transform.forward = other.contacts[0].normal;
        Instantiate(explosionParticles, transform.position, transform.rotation);
    }
}
