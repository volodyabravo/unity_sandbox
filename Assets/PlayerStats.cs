using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int healthMax = 100;
    public int healthCurrent = 100;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.setMaxHealth(healthMax);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.setHealth(healthCurrent);
    }

    public void DealDamage()
    {
        healthCurrent -= 1;
    }
}
