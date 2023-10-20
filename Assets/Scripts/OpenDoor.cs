using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private ActivateButton button;
    [SerializeField] private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Button").GetComponent<ActivateButton>();
    }

    // Update is called once per frame
    void Update()
    {
        OpenAndCloseDoor();
    }

    private void OpenAndCloseDoor()
    {
        if (button.isActivated)
        {
            if (gameObject.transform.position.y <= 5f)
            {
                gameObject.transform.position += new Vector3(0, 0.1f, 0);
                renderer.material.color = new Color(0, 1, 0);
            }
            else if (gameObject.transform.position.y == 5f)
            {
                gameObject.transform.position = new Vector3(0, 5f, 0);
            }
        }
        else
        {
            if (gameObject.transform.position.y >= 2)
            {
                gameObject.transform.position += new Vector3(0, -0.1f, 0);
                renderer.material.color = new Color(1, 0, 0);
            }
        }
    }
}
