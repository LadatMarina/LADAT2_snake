using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int gridPosition; //posici� actual de snake
    private Vector2Int startGridPosition; // initial pos
    private Vector2Int gridMoveDirection; //direcci� de moviment de snake

    private float horizontalInput, verticalInput;

    private float gridMoveTimer; //temps actual, contador
    private float gridMoveTimerMax = 1f; //cada quant es mour� s'snake


    void Awake()
    {
        startGridPosition = new Vector2Int(0, 0);
        gridPosition = startGridPosition; //set the snake initial pos at 0,0
        gridMoveDirection = new Vector2Int(0, 1); //posam com a direcci� default arriba
    }

    void Update()
    {
        gridMoveTimer += Time.deltaTime; //actualitzar es temps i asignar-ho a sa variable
        if(gridMoveTimer >= gridMoveTimerMax) //si es temps �s major al max...
        {
            gridPosition += gridMoveDirection; //canviam sa posici� en direcci� a sa que toca
            gridMoveTimer -= gridMoveTimerMax; //reiniciam es temporitzador

            transform.position = new Vector3(gridPosition.x, gridPosition.y, 0); 
            //reflexar es moviment des vector2 al vector3 de es game object

        }
    }
}
