using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PizzaInventory : MonoBehaviour
{
    public static PizzaInventory instance;
    public static Action<Transform> onPizzaDeleiver;
    public int pizzas;
    public TMPro.TextMeshProUGUI pizzaText;
    void Start()
    {
        onPizzaDeleiver += OnPizzaDeleiver;
    }
    private void OnPizzaDeleiver(Transform marker){
        Destroy(marker.gameObject);
        pizzas--;
        pizzaText.text = $"{pizzas}/3";
        if(pizzas == 0){
            UIManager.instance.ShowWinScreen();
        }else{
            UIManager.instance.ShowDeleiverScreen();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
