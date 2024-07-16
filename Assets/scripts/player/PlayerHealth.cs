using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;

    
    public float hp;

  


    private void Start()
    {
        hp = 100;
        UpdateHealthUI();
    }

    private void Update()
    {

        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOver");

        }


        UpdateHealthUI();

    }

    public void RecibirDanio(float dmg)
    {
        hp -= dmg;
        UpdateHealthUI();
    }


    void UpdateHealthUI()
    {
        hp = Mathf.Clamp(hp, 0, 100);
        healthSlider.value = hp;

    }
}
