using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    public PressButton pressButton;
    private float distanceToButton;
    [SerializeField] private Renderer renderer;
    [SerializeField] private GameObject player;
    public bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        player = GameObject.Find("Player");
        renderer.material.color = new Color(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        distanceToButton = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToButton <= 2.5f)
        {
            isPressed = !isPressed;
        }

        if (isPressed )
        {
            renderer.material.color = new Color(0, 1, 0);
        }
        else
        {
            renderer.material.color = new Color(1, 0, 0);
        }
    }

}
