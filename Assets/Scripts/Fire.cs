using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    private float health;

    private Vector3 scale;

    private FireManager fireManager;

    private float maxScale;

    void Awake()
    {
        fireManager = FindObjectOfType<FireManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        maxScale = transform.localScale.x;
        fireManager.AddFire(this);
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage)
    {

        health -= damage;

        if (health < 0)
        {
            health = 0;
        }

        float num = health == 0 ? 0 : health * maxScale / maxHealth;

        transform.localScale = new Vector3(num, num, 0);

        if (transform.localScale == Vector3.zero)
        {
            Destroy(gameObject);
            fireManager.RemoveFire(this);
        }
    }
}
