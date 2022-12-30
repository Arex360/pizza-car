using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health = 1;
    public float damageAmount = 0.15f;
    public UnityEngine.UI.Image healthFill;
    public float fillRate;
    public float targetHealth;
    void Start()
    {
        targetHealth = healthFill.fillAmount;
    }

    // Update is called once per frame
    void Update()
    {
        healthFill.fillAmount = Mathf.Lerp(healthFill.fillAmount,targetHealth,fillRate*Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("car") || collision.transform.CompareTag("obs")){
            health -= damageAmount;
        }
        targetHealth = health;
        if(health <= 0){
            UIManager.instance.ShowLoseScreen();
        }
    }
}
