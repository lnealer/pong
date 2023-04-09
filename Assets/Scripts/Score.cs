using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score; 
    public int playerNumber;
    public TMPro.TextMeshProUGUI scoreUI;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        scoreUI = GameObject.Find("Player"+playerNumber+" Score").GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.name == "Ball") {
            ScorePoint();
            FindObjectOfType<GameManager>().StopGame(playerNumber);
        }
    }

    void ScorePoint() {
        Debug.Log("scoring");
        score++;
        scoreUI.SetText(score.ToString());
    }
}
