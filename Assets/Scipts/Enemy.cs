using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    [SerializeField] private float speed = 500;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce( lookDirection * Time.deltaTime * speed);

        if (transform.position.y < -15)
            Destroy(gameObject);
    }

}
