using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid 
    /* això fa que sigui una clase que no és un comportament,
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

            SpawnFood();
        }
        public void SnakeMoved(Vector2Int snakeGridPosition)
        {
            if(snakeGridPosition == foodGridPosition)
            {
                Object.Destroy(foodGameObject);
                SpawnFood();
            }
        }
        private void SpawnFood()
        {
            foodGridPosition = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));

            foodGameObject = new GameObject("Food");
            SpriteRenderer foodSpriteRenderer = foodGameObject.AddComponent<SpriteRenderer>();
            foodSpriteRenderer.sprite = GameAssets.Instance.foodSprite;
            foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y, 0);
        }
        
        //funció que la feim per guardar es valor de script snake dins sa nostra variable snake
        public void SetupSnake(Snake snake)
        {
        //sa meva snake és igual al paràmetre que li estic ficant
            this.snake = snake;
        }
}
