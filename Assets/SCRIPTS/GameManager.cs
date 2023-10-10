using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelGrid levelGrid;
    private Snake snake; //snake és sa referència a s'script snake

    void Start()
    {
        /* Cream un game object anomenat "Snake_Head", l'hem asignat
         * a una variable d'aquest script ("snakeHeadGameObject")
         * Li afegim sa variable spriteRenderer
         * Li posam s'sprite de sa llibreria de sprites des cap de sa snake
         */
        GameObject snakeHeadGameObject = new GameObject("Snake_Head");
        SpriteRenderer snakeSpriteRenderer = snakeHeadGameObject.AddComponent<SpriteRenderer>();
        snakeSpriteRenderer.sprite = GameAssets.Instance.snakeHeadSprite;

        //li dic que snake és s'script i li afegeix aquest script a sa component
        //de snakeHeadGameObject
        snake = snakeHeadGameObject.AddComponent<Snake>();

        //crea un nou level grid
        levelGrid = new LevelGrid(20, 20);

        //asigna valor de level grid a la variable level grid de script snake
        snake.Setup(levelGrid); 

        //asigna valor de snake a sa variable snake de script level grid
        levelGrid.SetupSnake(snake);
    }
}