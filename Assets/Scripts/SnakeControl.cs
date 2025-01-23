using System;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    //variables
    Vector3 direction;
    public float speed;
    public Transform bodyPrefab;
    public List<Transform> snakeBodies = new List<Transform> ();
    String lastKeyCodeStr = "";
    public GameUI gameUI;
    public AudioControl audioControl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(transform.position);
        //Debug.Log(KeyCode.W.ToString());
        //transform.Translate(1,0,0);
        Time.timeScale = speed;
        GameReset();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && direction != Vector3.down) //&& !lastKeyCodeStr.Equals(KeyCode.S.ToString()
        {
            //Debug.Log("W");
            //transform.Translate(0, 1, 0);
            lastKeyCodeStr = KeyCode.W.ToString();
            direction = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.S) && direction != Vector3.up) //&& !lastKeyCodeStr.Equals(KeyCode.W.ToString()
        {
            //Debug.Log("S");
            //transform.Translate(0, -1, 0);
            lastKeyCodeStr = KeyCode.S.ToString();
            direction = Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.A) && direction != Vector3.right) //&& !lastKeyCodeStr.Equals(KeyCode.D.ToString()
        {
            //Debug.Log("A");
            //transform.Translate(-1, 0, 0);
            lastKeyCodeStr = KeyCode.A.ToString();
            direction = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.D) && direction != Vector3.left) //&& !lastKeyCodeStr.Equals(KeyCode.A.ToString()
        {
            //Debug.Log("D");
            //transform.Translate(1, 0, 0);
            lastKeyCodeStr = KeyCode.D.ToString();
            direction = Vector3.right;
        }
        //transform.Translate(direction * Time.deltaTime);

        //¬ö¿ý¤W¤@¦¸«öÁä
    }

    private void FixedUpdate()
    {
        for (int i = snakeBodies.Count-1; i > 0; i--)
        {
            snakeBodies[i].position = snakeBodies[i - 1].position;
        }
        transform.Translate(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SnakeAppleCollision"))
        {
            audioControl.PlayEatSound();
            snakeBodies.Add (Instantiate(bodyPrefab, transform.position, Quaternion.identity));
            gameUI.CountScore();
        }

        if (collision.CompareTag("Boundary"))
        {
            Debug.Log("Game Over");
            audioControl.PlayGameOverSound();
            GameReset();
        }
    }

    private void GameReset()
    {
        gameUI.ResetScore();
        transform.position = Vector3.zero;
        direction = Vector3.zero;
        for (int i = 1; i < snakeBodies.Count; i++)
        {
            Destroy(snakeBodies[i].gameObject);
        }
        snakeBodies.Clear();
        snakeBodies.Add(transform);
        audioControl.PlayBackgroundSound();
    }
}
