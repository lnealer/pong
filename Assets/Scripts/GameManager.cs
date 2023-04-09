using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

public GameObject player1;
public GameObject player2;
public GameObject ball;
public bool started = false;
public float direction=1; // direction to start ball, based on previous winner

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Jump") && !started) {
            StartGame();
            started = true;
        }
    }

    public void StartGame() {
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(direction*2,0);
    }

    public float GetDirection(int winnerNumber) {
        return winnerNumber*2-3;
    }

    public void StopGame(int winnerNumber) {
        Debug.Log("stopping game");

        ball.GetComponent<Rigidbody2D>().position = new Vector2(0,0);
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        direction = GetDirection(winnerNumber);
        started = false;
    }
}
