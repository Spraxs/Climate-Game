using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCircle : MonoBehaviour
{
    private InputController inputController;
    private Player player;

    public float travelTimeInSeconds;

    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<Player>();
        inputController = FindObjectOfType<InputController>();

        inputController.buttonInputAction += ButtonInput;
    }

    private void ButtonInput(InputController.ButtonInput buttonInput)
    {
        if (GetActiveCircle() == null) return;

        Circle circle = GetActiveCircle();

        float distance = Vector3.Distance(transform.position, circle.transform.position);

        float points = 0;

        if (distance < 5 && points == 0) points = 300;
        if (distance < 20 && points == 0) points = 100;
        if (distance < 90 && points == 0) points = 50;

        if (points > 0)
        {
            if (CheckCircleButton(circle, buttonInput))
            {

                player.Correct(points);

            } else
            {
                // DAMAGE

                player.Damage();
            }
        } else
        {
            // DAMAGE
            player.Damage();
        }

        Destroy(circle.gameObject);


    }

    private bool CheckCircleButton(Circle circle, InputController.ButtonInput buttonInput)
    {
        if (circle == null) return false;

        return circle.button == buttonInput;
    }

    private Circle GetActiveCircle()
    {
        if (CircleSpawner.instance.circles.Count <= 0) return null;

        return CircleSpawner.instance.circles[0];
    }
}
