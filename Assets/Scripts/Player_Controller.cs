using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody playerRigibody;
    [SerializeField] private float speed = 30f;
    private float forwardInput;

    [SerializeField] private GameObject focalPointGameObject;

    public bool hasPowerup;

    [SerializeField] private float powerupForce = 10f;

    private void Awake()
    {
        playerRigibody = GetComponent<Rigidbody>();
        hasPowerup = false;
    }


    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
         

         playerRigibody.AddForce(focalPointGameObject.transform.forward * speed * forwardInput);

        //SI QUEREMOS QUE EL PLAYER FRENE CUANDO NO PULSAMOS VERTICAL INPUT
        // // forwardInput > -0.01f && forwardInput < 0.01f
        // if (Mathf.Abs(forwardInput) < 0.01f)
        //{
        //    playerRigibody.velocity = Vector3.zero;
        //}
        //else
        //{
        //    playerRigibody.AddForce(focalPointGameObject.transform.forward *
        //                            speed * forward);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            StartCoroutine(PowerupCountdown());
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            // El enemigo sufre un empujón alejándolo del player
            Rigidbody enemyRigidbody = other.gameObject.
                GetComponent<Rigidbody>();

            Vector3 direction = (other.transform.position -
                                 transform.position).normalized;

            enemyRigidbody.AddForce(direction * powerupForce,
                ForceMode.Impulse);
        }
    }

    private IEnumerator PowerupCountdown()
    {
        // Espera 6 segundos
        yield return new WaitForSeconds(6);

        hasPowerup = false;
    }
}
