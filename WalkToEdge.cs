using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToEdge : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 2;

    public static float timer;

    
    // Start is called before the first frame update
    void Start()
    {
        timer = 10.0f;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        if (!hitEdge()) {
        timer = 10.0f;
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
        }


        else if(hitEdge()) {
        
        if(timer <= 0.0f)
        {
        Vector3 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
        speed = speed * -1;

        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
        }
        
        }

        
   
        
    } //end update


    public LayerMask groundLayer;

     bool hitEdge() {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down + Vector2.right;
        Vector2 direction2 = Vector2.down + Vector2.left;
        float distance = 2.0f;


    	RaycastHit2D hit; 

        if(speed < 0)
        {
           Debug.DrawRay(position, direction2 * distance, Color.green);
		   hit = Physics2D.Raycast(position, direction2, distance, groundLayer); 
        }
        else
        {
            Debug.DrawRay(position, direction * distance, Color.green);
		    hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        }

        if (hit.collider == null) {
            return true;
        }

        return false;
    }

}//end class
