using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;
    public float maxSpeed, jumpHeight;

    void Update() {
        animator.SetFloat("isMoving", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        if (Input.GetKeyDown(KeyCode.W)) {
            // TODO: Jump
            if (Physics2D.IsTouchingLayers(GetComponent<Collider2D>())) {
                // Then player is touching floor.
                GetComponent<Rigidbody2D>().velocity += new Vector2(0, jumpHeight);
            }
        }

        if (Input.GetKey(KeyCode.A)) {
            // Go left
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-maxSpeed / 4, 0f), ForceMode2D.Force);

            // Turn left
            GetComponent<Rigidbody2D>().transform.rotation = new Quaternion(0, 180, 0, 0);
        }

        if (Input.GetKey(KeyCode.D)) {
            // Go right
            GetComponent<Rigidbody2D>().AddForce(new Vector2(maxSpeed / 4, 0f), ForceMode2D.Force);

            // Turn right
            GetComponent<Rigidbody2D>().transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    void FixedUpdate() {
        Rigidbody2D player = GetComponent<Rigidbody2D>();
        // Capping the max speed
        if (player.velocity.x > maxSpeed) {
            player.velocity = new Vector2(maxSpeed, player.velocity.y);
        } else if (player.velocity.x < -maxSpeed) {
            player.velocity = new Vector2(-maxSpeed, player.velocity.y);
        }
    }
}
