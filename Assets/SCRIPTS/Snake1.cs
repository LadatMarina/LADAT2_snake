using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake1 : MonoBehaviour
{
    private Vector2Int gridPosition; //posici� actual de snake
    private Vector2Int startGridPosition; // initial pos
    private Vector2Int gridMoveDirection; //direcci� de moviment de snake

    private float horizontalInput, verticalInput;

    private float gridMoveTimer; //temps actual, contador
    private float gridMoveTimerMax = 1f; //cada quant es mour� s'snake

    private LevelGrid levelGrid;
    void Awake()
    {
        startGridPosition = new Vector2Int(0, 0);
        gridPosition = startGridPosition; //set the snake initial pos at 0,0
        gridMoveDirection = new Vector2Int(0, 1); //posam com a direcci� default arriba
        transform.eulerAngles = Vector3.zero; //set the initial rotation amb 0
    }

    void Update()
    {
        HandleMoveDirection();
        HandleMoveMovement();
    }

    /* funci� que tenc perqu� sa meva variable levelGrid guardi 
     * sa informaci� des nou level grid que he creat a nes gameManager
     */
    public void Setup(LevelGrid levelGrid)
    {
        //sa meva variable levelGrid ser� igual a nes par�metre que li estic ficant
        this.levelGrid = levelGrid;
    }

    private void HandleMoveDirection()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Cambio direcci�n hacia arriba
        if (verticalInput > 0) // he tocat cap a dalt?
        {
            if (gridMoveDirection.x != 0) // estic a s'eix horizontal?
            {
                // Cambio la direcci�n hacia arriba (0,1)
                gridMoveDirection = new Vector2Int(0, 1);
            }
        }
        // ABAIX
        if (verticalInput < 0) //he tocat abaix?
        {
            // anava en horizontal?
            if (gridMoveDirection.x != 0)
            {
                gridMoveDirection = new Vector2Int(0, -1);

            }
        }

        // DRETA
        if (horizontalInput > 0)
        {
            if (gridMoveDirection.y != 0)
            {
                gridMoveDirection = new Vector2Int(1, 0);

            }
        }

        // ESQUERRA
        if (horizontalInput < 0)
        {
            if (gridMoveDirection.y != 0)
            {
                gridMoveDirection = new Vector2Int(-1, 0);

            }
        }

    }

    private void HandleMoveMovement()
    {
        gridMoveTimer += Time.deltaTime; //actualitzar es temps i asignar-ho a sa variable

        if (gridMoveTimer >= gridMoveTimerMax) //si es temps �s major al max...
        {
            gridPosition += gridMoveDirection; //canviam sa posici� en direcci� a sa que toca
            gridMoveTimer -= gridMoveTimerMax; //reiniciam es temporitzador

            transform.position = new Vector3(gridPosition.x, gridPosition.y, 0);
            //reflexar es moviment des vector2 al vector3 de es game object


            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection));

            //ha menjat?
        }

    }

    /*aquesta funci� agafa sa direcci� que obtenim dels inputs i calcula es graus
     * entre la pos1 i pos2, aix� que obtenc es angles que he de girar sprite
     * perqu� sa rotaci� de s'sprite concordi amb sa diracci�
     */

    private float GetAngleFromVector(Vector2Int direction)
    {
        float degrees = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (degrees < 0)
        {
            degrees += 360;
        }

        return degrees - 90;
    }

    public Vector2Int GetGridPosition()
    {
        return gridPosition;
    }

}
