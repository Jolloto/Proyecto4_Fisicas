using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody playerRigibody;
    [SerializeField] private float speed = 30f;
    private float forwardInput;

    [SerializeField] private GameObject focalPointGameObject;

    public bool hasPowerup;
    [SerializeField] private float powerupForce = 10f;

    [SerializeField] private GameObject[] PowerupIndicators;

    private bool isGameOver;

    private int lives;

    private float lowerlimit = -3f;

    private Vector3 initialPosition;

    private void Awake()
    {
        playerRigibody = GetComponent<Rigidbody>();
        hasPowerup = false;
        initialPosition = Vector3.zero;
        lives = 3;
        isGameOver = false;
    }

    private void Start() 
    {
        HideAllPowerupIndicators();
    }

    private void Update()
    {
        if (isGameOver) 
        {
            return;
        }

        Movement();

        if (transform.position.y < lowerlimit)
        {
            lives--;
            if (lives <= 0) 
            {
                //GAME OVER
                isGameOver = true;
            }
            else 
            {
                //Puedo seguir jugando
                transform.position = initialPosition;
                playerRigibody.velocity = Vector3.zero;
                StartCoroutine(InvulnerabilityCountdown());
            }
        }
    }  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("POWERUP"))
        {
            hasPowerup = true;
            StartCoroutine(PowerupCountdown());
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ENEMY") && hasPowerup)
        {
            // El enemigo sufre un empujón alejándolo del player
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();

            Vector3 direction = (other.transform.position -
                                 transform.position).normalized;

            enemyRigidbody.AddForce(direction * powerupForce,
                ForceMode.Impulse);
        }
    }

    private void Movement()
    {
        forwardInput = Input.GetAxis("Vertical");


        playerRigibody.AddForce(focalPointGameObject.transform.forward * speed * forwardInput);

        //SI QUEREMOS QUE EL PLAYER FRENE CUANDO NO PULSAMOS VERTICAL INPUT
        // // forwardInput > -0.01f && forwardInput < 0.01f
        // {
        //      playerRigidbody.velocity = Vector3.zero;
        // }
        // else
        // {
        //    playerRigidbody.AddForcce(focalPointGameObject.transform.forward * speed * forwardInput);
        // }

    }

    private IEnumerator PowerupCountdown()
    {
        for (int i = 0; i < PowerupIndicators.Length; i++) 
        {
            PowerupIndicators[i].SetActive(true);
            yield return new WaitForSeconds(2);
            PowerupIndicators[i].SetActive(false);
        }

        hasPowerup = false;
    }

    private IEnumerator InvulnerabilityCountdown() 
    {
        playerRigibody.constraints = RigidbodyConstraints.FreezePosition | 
            RigidbodyConstraints.FreezeRotation;
        yield return new WaitForSeconds(0.5f);
        playerRigibody.constraints = RigidbodyConstraints.None;
    }

    private void HideAllPowerupIndicators() 
    {
      foreach (GameObject indicator in PowerupIndicators)
      {
        indicator.SetActive(false);
      }

    }

    public bool GetIsGameOver() 
    {
        return isGameOver;
    }

    
}
