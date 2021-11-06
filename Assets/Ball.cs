using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;// We have to add the UnityEngine.UI namespace in order to work with Text variables

public class Ball : MonoBehaviour 
{   
    public Text scorerightText;
	public Text scoreleftText;
	int scoreRight;
	int scoreLeft;
    public float speed = 30;

    void Start() 
    {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
    }
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight){
        //ascii art:
        //|| 1 <- Au haut de la racket 
        //||
        //|| 0 <- Au milieu de la racket 
        //|| 
        //||-1 <- Au bas de la racket 
        return(ballPos.y-racketPos.y)/racketHeight;
    }
    void OnCollisionEnter2D(Collision2D col) 
  {
  
  
    // Note: 'col' holds the collision information. If the
    // Ball collided with a racket, then:
    //   col.gameObject is the racket
    //   col.transform.position is the racket's position
    //   col.collider is the racket's collider

    // Hit the left Racket?
    if (col.gameObject.name == "RacketLeft") 
	{
        // Calculate hit Factor
        float y = hitFactor(transform.position,
                            col.transform.position,
                            col.collider.bounds.size.y);

        // Calculate direction, make length=1 via .normalized
        Vector2 dir = new Vector2(1, y).normalized;

        // Set Velocity with dir * speed
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

    // Hit the right Racket?
    if (col.gameObject.name == "RacketRight") 
    {
        // Calculate hit Factor
        float y = hitFactor(transform.position,
                            col.transform.position,
                            col.collider.bounds.size.y);

        // Calculate direction, make length=1 via .normalized
        Vector2 dir = new Vector2(-1, y).normalized;

        // Set Velocity with dir * speed
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }
        //this is our condition (if the ball collides with an object with the name Wallright)
        if (col.gameObject.name == "Wallright") {
			//this line will just add 1 point to the score
			scoreLeft ++;
			//this line will convert the int score variable to a string variable
			scoreleftText.text = scoreLeft.ToString ();
		}
		if (col.gameObject.name == "Wallleft") {
			scoreRight ++;
			scorerightText.text = scoreRight.ToString ();
		}
  }

}


    
