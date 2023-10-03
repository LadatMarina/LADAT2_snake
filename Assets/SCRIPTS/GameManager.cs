using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        snakeSpriteRenderer.AddComponent<Snake>();
    }
}