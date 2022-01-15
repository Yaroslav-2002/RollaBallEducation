using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Canvas loseTextObject;
    public int maxHealth = 3;
    public int currentHealth;
    public Image[] lives;
    public Sprite live;
    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        loseTextObject.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void TakeDamage(int amount)
    {
        lives[currentHealth - 1].enabled = false;
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            loseTextObject.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TheEnd"))
        {
            transform.position = new Vector3(0, 0.5f, 0);
        }
    }
}