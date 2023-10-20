using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorWithButton : MonoBehaviour
{
    [SerializeField] private PressButton button;
    [SerializeField] private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("DoorActivateButton").GetComponent<PressButton>();
    }

    // Update is called once per frame
    void Update()
    {
        PressButton();
    }

    private void PressButton()
    {
        if (button.isPressed)
        {
            if (gameObject.transform.position.y <= 5)
            {
                gameObject.transform.position += new Vector3(0, 0.1f, 0);
            }
            renderer.material.color = new Color(0, 1, 0);
        }
        else
        {
            if (gameObject.transform.position.y >= 2)
            {
                gameObject.transform.position += new Vector3(0, -0.1f, 0);
            }
            renderer.material.color = new Color(1, 0, 0);
        }
    }
}
