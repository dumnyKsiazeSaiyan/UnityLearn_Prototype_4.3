using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private GameObject focalPoint;

    [SerializeField] float speed = 800;

    //PowerUp
    public bool hasPowerup;
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal_Point");
        powerupIndicator = GameObject.Find("Powerup_Indicator");
        powerupIndicator.SetActive(false);

    }

    private void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        _rigidbody.AddForce(Time.deltaTime * speed * forwardInput * focalPoint.transform.forward);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }
}


