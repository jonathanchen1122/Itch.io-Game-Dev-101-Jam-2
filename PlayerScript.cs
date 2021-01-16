using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public bool isAlive;
    public Vector3 initSize;

    private void Start()
    {
        isAlive = true;
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePos;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Maze"))
        {
            // size is zero
            isAlive = false;

            transform.localScale = new Vector3(0f, 0f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn") && isAlive == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.CompareTag("Redo"))   // && POSITION AT START
        {
            isAlive = true;
            transform.localScale = initSize;

            //size is normal
        }


        if (collision.CompareTag("Obstacle")) //Enemy
        {
            // size is zero
            isAlive = false;

            transform.localScale = new Vector3(0f, 0f, 1f);
        }
    }
}
