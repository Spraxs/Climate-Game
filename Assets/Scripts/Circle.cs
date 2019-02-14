using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites = new Sprite[4];

    [HideInInspector]
    public Image image;

    public InputController.ButtonInput button;

    private HitCircle hitCircle;
    private Player player;

    private float spawnTime;

    private float speed;

    private CircleSpawner circleSpawner;

    private void Awake()
    {
        hitCircle = FindObjectOfType<HitCircle>();
        player = FindObjectOfType<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        circleSpawner = transform.parent.GetComponent<CircleSpawner>();
        speed = circleSpawner.speed;
        spawnTime = Time.time;
        image = GetComponent<Image>();

        int i = Random.Range(0, 4);

        button = (InputController.ButtonInput) i;

        image.sprite = sprites[i];
       // StartCoroutine(MoveToPosition(transform, hitCircle.transform));
    }

    void Update()
    {

        if (transform.position.x > hitCircle.transform.position.x + 100f)
        {
            player.Damage();

            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
    }

    void OnDestroy()
    {
        circleSpawner.circles.Remove(this);
    }
}
