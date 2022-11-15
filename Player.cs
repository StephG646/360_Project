using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    float speed = 3f;
    Rigidbody2D rb;
    int coins = 0;
    Vector3 startingPosition; // If we hit a spike we will teleport player to starting position.

    public Sprite runSprite;
    public Sprite jumpSprite;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component added to the object and store it in rb
        startingPosition = transform.position;
    }

    void Update()
    {
        if (Scoring.lives == 0)
        {
            GameState.state = GameState.GameOver;
        }
            
        

        Debug.DrawRay(this.transform.position, rb.velocity, Color.green);
        
        var input = Input.GetAxis("Horizontal"); // This will give us left and right movement (from -1 to 1). 
        var movement = input * speed;
        
        if (movement < 0)
        {
            float xScale = Mathf.Abs(transform.localScale.x);
            transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
        }

        if (movement > 0)
        {
            float xScale = Mathf.Abs(transform.localScale.x);
            transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
        }
       

        int yMovement = (int) Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(movement, rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(new Vector3(0, 100, 0)); // Adds 100 force straight up, might need tweaking on that number   
            rb.AddForce(transform.up * 9, ForceMode2D.Impulse);         
        }


        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        sr.sprite = jumpSprite;

        if (Mathf.Abs(rb.velocity.y) < 0.01) {
            sr.sprite = runSprite;
        }

        if (rb.velocity.y != 0)
        Debug.Log("Update: "+rb.velocity.y);

        if (Input.GetButtonUp("Jump"))
        {
           rb.AddForce(transform.up * -1, ForceMode2D.Impulse);
        }
        
    }


    void OnTriggerEnter2D(Collider2D col) // col is the trigger object we collided with
    { 
        if (col.tag == "Coin")
        {
            coins++;
            Destroy(col.gameObject); // remove the coin
            Scoring.score += 5;
        }
        else if (col.tag == "Water")
        {
            // Death? Reload Scene? Teleport to start:
            transform.position = startingPosition;
        }
        
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Pink")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
            Scoring.lives--;
        }

        else if(coll.gameObject.tag == "Spike")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
            Scoring.lives--;
        }

        else if(coll.gameObject.tag == "End")
        {
            SceneManager.LoadScene("endScene"); 
            //add end title?
        }
    }

    public LayerMask groundLayer;

    bool IsGrounded() {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 2.0f;

        Debug.DrawRay(position, direction * distance, Color.green);
		RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);

        if (hit.collider != null) {
            return true;
        }

        return false;
    }

}//end class