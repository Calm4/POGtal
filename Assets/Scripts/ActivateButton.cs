using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    public Renderer renderer;
    public bool isActivated;
    // Start is called before the first frame update
    void Start()
    {
        renderer.material.color = new Color(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("TouchObject"))
        {

            renderer.material.color = new Color(0, 1, 0);
            isActivated = true;
        }

    }

    private void OnCollisionExit(Collision collision )
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("TouchObject"))
        {
            renderer.material.color = new Color(1, 0, 0);
            isActivated = false;
        }

    }
}
