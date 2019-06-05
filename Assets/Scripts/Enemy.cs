using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public Transform healthBarParent; // Refers to Empty Camvas element
    public GameObject healthBarUIPrefab; // Healthbar Prefab to spawn
    public Transform healthBarPoint;

    private int health = 0;
    private Slider healthSlider;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn a new healthaBar under "HealthBarParent"
        GameObject clone = Instantiate(healthBarUIPrefab, healthBarParent);
        // Get Slider component from new HealthBar
        healthSlider = clone.GetComponent<Slider>();
        // Set health to maxHealth
        health = maxHealth;
        // Get the renderer attached to Enemy
        rend = GetComponent<Renderer>();
    }

    void OnDestroy()
    {
        // If healthSlider exists
        if (healthSlider)
        {
            // Destroy the HealthBar with it
            Destroy(healthSlider.gameObject);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // healthSlider.gameObject.SetActive(rend.isVisible);
        // Vector3 screenPosition = Camera.main.WorldToScreenPoinr(healthBarPoint.position);
        // healthSlider.transform.position = screenPosition;

        // OR

        // If the renderer (Enemy) is Visible
        if (rend.isVisible)
        {
            //Activates the HealthBar
            healthSlider.gameObject.SetActive(true);
            // Update position of healthbar with enemy
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(healthBarPoint.position);
            healthSlider.transform.position = screenPosition;
        }
        // If it is not visible
        else
        {
            healthSlider.gameObject.SetActive(false);
        }

    }

    public void TakeDamage(int damage)
    {
        // Reduce health with damage
        health -= damage;
        // Update Health Slider
        healthSlider.value = (float)health / (float)maxHealth;
        // If health reaches zero
        if(health < 0)
        {
            // Destroy the GameObject
            Destroy(gameObject);
        }
    }
}
