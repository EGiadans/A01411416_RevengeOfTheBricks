using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour{
    void OnTriggerEnter2D(Collider2D collider) //En realidad no utilizamos el parametro
        //pero puede darse el caso que pueda ser colisionado por otros objetos aparte de la de la pelota
    {
        LevelManager levelManager = new LevelManager();
        levelManager.LoadLevel("Lose");
    }
}
