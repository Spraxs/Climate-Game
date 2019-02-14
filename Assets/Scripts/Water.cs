using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    private Vector3 spawnPosition;

    private float damage;

    private Fire target;

    private FireManager fireManager;

    [SerializeField]
    private float speed;

    private bool spawned;

    public void SetSpawnPosition(Vector3 _spawnPosition)
    {
        spawnPosition = _spawnPosition;
    }

    public void SetDamage(float _damage)
    {
        damage = _damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        fireManager = FindObjectOfType<FireManager>();

        target = fireManager.GetRandomFire();
    }

    void Update() 
    {
        
        if (spawnPosition != Vector3.zero && !spawned)
        {
            transform.position = spawnPosition;
            spawned = true;
        }

        if (!spawned) return;

        if (target == null)
        {
            target = fireManager.GetRandomFire();

            if (target == null) Destroy(gameObject);

            return;
        }

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < 1)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (!spawned || target == null) return;

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
    }

    void OnDestroy()
    {
        if (target == null) return;
        target.Damage(damage);
        // Maybe particle effect
    }
}
