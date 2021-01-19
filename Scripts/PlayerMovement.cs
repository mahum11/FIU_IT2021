using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float maxSpeed, jumpHeight;

    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {
            // TODO: Jump
            if (Physics2D.IsTouchingLayers(GetComponent<Collider2D>())) {
                // Then player is touching floor.
                GetComponent<Rigidbody2D>().velocity += new Vector2(0, jumpHeight);
            }
        }

        if (Input.GetKey(KeyCode.A)) {
            // TODO: Go LEFT
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-maxSpeed / 4, 0f), ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.D)) {
            // TODO: Go right
            GetComponent<Rigidbody2D>().AddForce(new Vector2(maxSpeed / 4, 0f), ForceMode2D.Force);
        }
    }

    void FixedUpdate() {
        Rigidbody2D player = GetComponent<Rigidbody2D>();
        if (player.velocity.x > maxSpeed) {
            player.velocity = new Vector2(maxSpeed, player.velocity.y);
        } else if (player.velocity.x < -maxSpeed) {
            player.velocity = new Vector2(-maxSpeed, player.velocity.y);
        }
    }
}
