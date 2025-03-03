using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class knifeController : MonoBehaviour
{
    private knifeManager managerKnife;
    private Rigidbody2D knifeRigidbody;
    [SerializeField] private float moveSpeed;

    private bool canShoot;

    private void Start()
    {
        GetComponentValues();
    }

    private void Update()
    {
        HandleShootInput();
    }

    private void FixedUpdate()
    {
        Shoot();
    }

    private void GetComponentValues()
    {
        knifeRigidbody = GetComponent<Rigidbody2D>();
        managerKnife = GameObject.FindObjectOfType<knifeManager>();
    }

    private void HandleShootInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canShoot = true;
            managerKnife.setDisableKnifeIconColor();
        }
    }

    private void Shoot()
    {
        if (canShoot)
        {
            knifeRigidbody.AddForce(Vector2.up * moveSpeed * Time.fixedDeltaTime);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("circle"))
        {
            managerKnife.setActiveKnife();
            canShoot = false;
            knifeRigidbody.isKinematic = true;
            transform.SetParent(collision.transform);
            knifeRigidbody.angularVelocity = 0;
            knifeRigidbody.velocity = new Vector3 (0, 0, 0);
        }

        if (collision.gameObject.CompareTag("knife"))
        {
            SceneManager.LoadScene(0);
        }
    }

}
