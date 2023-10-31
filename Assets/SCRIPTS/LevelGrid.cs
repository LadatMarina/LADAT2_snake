using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid 
    /* aix� fa que sigui una clase que no �s un comportament,
     * una estructira, una plantilla, algo que de fineix un objecte
     */
{
    
    private Vector2Int foodGridPosition;
    private GameObject foodGameObject;

    private int width;
    private int height;

    private Snake snake;

    public LevelGrid(int w, int h)
    {
        width = w;
        height = h;
    }
    
    //funci� que la feim per guardar es valor de script snake dins sa nostra variable snake
    public void Setup(Snake snake)
    {
        this.snake = snake;
        //sa meva snake �s igual al par�metre que li estic ficant
        SpawnFood();
    }

    /// <summary>
    /// funci� que s'encarrega de mirar si sa serp ha menjat una poma
    /// si n'ha menjada, torna a instanc�ar una nova poma
    /// Aquesta funci� la cridam a nes handleMovevent de script snake, quant 
    /// comprovam si ha menjat o no
    /// <param name="snakeGridPosition"></param>
    /// <returns></returns>
    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if(snakeGridPosition == foodGridPosition)
        {
        Object.Destroy(foodGameObject);
        SpawnFood();
        GameManager.Instance.AddScore(GameManager.POINTS);
        return true;
        }
        else
        {
            return false;
        }
    }
    private void SpawnFood()
    {
        // while (condicion){
        // cosas
        // }

        // { cosas }
        // while (condicion)
    do
    {
        foodGridPosition = new Vector2Int(
            Random.Range(-width / 2, width / 2),
            Random.Range(-height / 2, height / 2));

    } while (snake.GetFullSnakeBodyGridPosition().IndexOf(foodGridPosition) != -1);

        foodGameObject = new GameObject("Food");
        SpriteRenderer foodSpriteRenderer = foodGameObject.AddComponent<SpriteRenderer>();
        foodSpriteRenderer.sprite = GameAssets.Instance.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y, 0);
    }

    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        int w = Half(width);
        int h = Half(height);

        // Me salgo por la derecha
        if (gridPosition.x > w)
        {
            gridPosition.x = -w;
        }
        if (gridPosition.x < -w)
        {
            gridPosition.x = w;
        }
        if (gridPosition.y > h)
        {
            gridPosition.y = -h;
        }
        if (gridPosition.y < -h)
        {
            gridPosition.y = h;
        }

        return gridPosition;
    }

    private int Half(int number)
    {
        return number / 2;
    }
}

