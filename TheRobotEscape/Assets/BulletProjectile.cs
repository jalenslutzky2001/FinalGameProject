using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    private Rigidbody bulletRigidbody;
    public AudioSource gameOver;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        gameOver = GetComponent<AudioSource>();
    }

    private void Start()
    {
        float speed = 40f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletTarget>() != null)
        {
            // Hit Target
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            gameOver.Play();
        }
        else
        {
            // Hit something else
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

}
