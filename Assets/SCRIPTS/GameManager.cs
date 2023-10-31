using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    public const int POINTS = 100; //constant per guardar es punts que s'ha de sumar/rstar
    private int score; // puntuaci�

    private LevelGrid levelGrid;
    private Snake snake; //snake �s sa refer�ncia a s'script snake

    public ScoreUI scoreUIScript;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than an Instance");
        }
        Instance = this;
    }
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

        //li dic que snake �s s'script i li afegeix aquest script a sa component
        //de snakeHeadGameObject
        snake = snakeHeadGameObject.AddComponent<Snake>();

        //crea un nou level grid
        levelGrid = new LevelGrid(20, 20);

        //asigna valor de level grid a la variable level grid de script snake
        snake.Setup(levelGrid); 

        //asigna valor de snake a sa variable snake de script level grid
        levelGrid.Setup(snake);

        //refer�ncia a script de sa UI
        scoreUIScript = GetComponentInChildren<ScoreUI>();

        //inicialitzaci� dels punts
        score = 0;
        //aqu� cridam sa funci� perqu� es text s'acutialitzi es text de forma visual
        AddScore(0); 
    }
    /// <summary>
    /// funci� que s'encarrega de mostrar sa puntuaci� 
    /// tamb� se podria fer amb {get;private set;}
    /// </summary>
    /// <returns>score </returns>
    public int GetScore()
    {
        return score;
    }

    /// <summary>
    /// funci� que s'encarrega d'augmentar la puntuaci�
    /// </summary>
    /// <param name="pointsToAdd"></param>
    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreUIScript.UpdateScoreText(score);
    }
}