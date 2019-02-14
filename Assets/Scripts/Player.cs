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

    [SerializeField]
    private GameObject waterObject;

    [SerializeField]
    private Transform gunTransform;

    private GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        FindObjectOfType<HitCircle>().player = this;
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

        if (health == 0)
        {
            gameManager.EndGame(MenuManager.MenuType.LOSE);
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

        Shoot(points);
    }

    private void Shoot(float points)
    {

        Water water = Instantiate(waterObject).GetComponent<Water>();

        water.SetSpawnPosition(gunTransform.position);
        water.SetDamage(points);
    }
}
