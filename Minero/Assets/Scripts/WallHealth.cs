using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealth : MonoBehaviour
{
    public float Health;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(transform.gameObject);
        }
        else
        {
            slider.value = CalculateHealth();
        }

        if (Health > maxHealth)
        {
            Health = maxHealth;
        }
    }

    float CalculateHealth()
    {
        return Health / maxHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Health -= 1;
        }
    }
}
