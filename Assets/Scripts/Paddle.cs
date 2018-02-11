using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public bool autoplay = false; //The paddle follows automatically the ball
    public float minX;
    public float maxX;

    private Ball ball; //We will need to control the ball, to be sticked to our paddle and we need to know where the ball is 

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>(); 
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoplay)
        {
            MoveWithMouse();
        } else
        {
            AutoPlay();
        }
	}

    void AutoPlay()
    {
        Vector3 paddlePos = this.transform.position;
        Vector3 ballPos = ball.transform.position;

        paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);

        this.transform.position = paddlePos;
    }

    void MoveWithMouse()
        //Here we need to obtain the mouse position and transform it into a valid screen position in x
    {
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        //float mousePosInBlocks = Input.mousePosition.x / Screen.width; //Sabremos la proporcion en la que está de la pantalla
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16; //Para que sea ahora en blocks del mundo

        paddlePos.x = Mathf.Clamp(mousePosInBlocks,minX, maxX); //Nunca se saldra de nuestra pantalla

        this.transform.position = paddlePos;
    }
}
