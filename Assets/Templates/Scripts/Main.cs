using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private bool isGrounded;
    public int jumpForce;

    private Rigidbody rb;
    private int health;
    private int count;
    private int PickUpsCount;
    private int healthComponent;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);

        GameObject[] PickUps = GameObject.FindGameObjectsWithTag("PickUp");
        PickUpsCount = PickUps.Length;
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= PickUpsCount)
        {
            winTextObject.SetActive(true);
        }
    }

    private void SetLoseText()
    {
        if (count >= PickUpsCount)
        {
            winTextObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
    }

    private void Jump()
    {
        isGrounded = false;
        rb.AddForce(new Vector3(0, jumpForce, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;

            SetCountText();
        }
        if (other.gameObject.CompareTag("TheEnd"))
        {
            rb.transform.position = new Vector3(101.21f, -66f, 267.12f);
            var healthComponent = rb.GetComponent<Health>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}