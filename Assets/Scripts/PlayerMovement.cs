using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public int playerNumber;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float yMove = Input.GetAxisRaw("Vertical" + playerNumber);

        rb.velocity = new Vector3(0, yMove, 0) * speed;
    }
}
