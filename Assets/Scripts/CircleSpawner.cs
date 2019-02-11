using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleSpawner : MonoBehaviour
{

    public List<Circle> circles = new List<Circle>();
    private Canvas canvas;

    public GameObject circleObject;

    private bool canSpawn;

    public static CircleSpawner instance;

    public float speed;


    [SerializeField]
    private int amount;
    [SerializeField]
    private float spawnDelay;

    [SerializeField]
    private float rowDelay;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        canvas = FindObjectOfType<Canvas>();

        StartCoroutine(SpawnRow(amount));
    }

    public void SpawnCircle()
    {
        
        Circle circle = Instantiate(circleObject).GetComponent<Circle>();

        circle.transform.parent = transform;

        circle.transform.localPosition = Vector3.zero;

        circles.Add(circle);
    }

    private IEnumerator SpawnRow(int amount)
    {

        for (int i = 0; i < amount; i++)
        {
            SpawnCircle();

            yield return new WaitForSeconds(spawnDelay);
        }

        RowSpawned();
    }

    private IEnumerator RowSpawnCooldown()
    {
        yield return new WaitForSeconds(rowDelay);

        StartCoroutine(SpawnRow(amount));
    }

    private void RowSpawned()
    {

        StartCoroutine(RowSpawnCooldown());

    }


}
