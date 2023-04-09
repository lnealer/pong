using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    public float borderSpeedMultiplier = 2;
    public float pongBoardMultiplier = 1F;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        print("start");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D collRb = collision.gameObject.GetComponent<Rigidbody2D>();
        float positionFactor = calculatePositionFactor(collision);
        int signX = System.Math.Sign(rb.velocity.x);
        int signY = System.Math.Sign(rb.velocity.y);
        if (collision.gameObject.name == "Border") {
            // border collision
            rb.velocity = new Vector2(signX*borderSpeedMultiplier*speed,-1*signY*borderSpeedMultiplier*speed);
            print(rb.velocity);
        }
        else {
            // player collision
            print("play collision");
            print(positionFactor);
            rb.velocity = new Vector2(-1*signX*speed,positionFactor*speed);
            print(rb.velocity); 
        }
    }

    private float calculatePositionFactor(Collision2D collision) {
        Transform collTransform =collision.gameObject.transform;
        float num = (this.gameObject.transform.localPosition.y - collTransform.localPosition.y);
        float factor = num/collTransform.localScale.y;
        factor *= pongBoardMultiplier;
        return factor;
    }
}
