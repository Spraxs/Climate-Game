using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    private float health = 100.0f;

    private SoundEffectManager soundEffectManager;

    void Awake()
    {
        soundEffectManager = FindObjectOfType<SoundEffectManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.value = health / 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        health -= 0.02f;

        slider.value = Mathf.Lerp(slider.value, health / 100.0f, .5f);
    }

    public void Damage()
    {
        health -= 20;
        
        if (health < 0)
        {
            health = 0;
        }
    }

    public void Correct(float points)
    {
        soundEffectManager.PlayWaterShoot();

        health += points / 10;

        if (health > 100)
        {
            health = 100;
        }
    }
}
