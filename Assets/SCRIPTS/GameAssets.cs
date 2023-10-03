using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets Instance { get; private set; }

    public Sprite snakeHeadSprite; //asignar sprite a s'inspector

    private void Awake()
    { 
        /*Nova forma de fer una variable statica:
         * Feim que quant detecti una nova còpia de Instance,
         * en lloc d'eliminar-la, feim que surti un error que
         * te faci sortir de es modo play (sa nova instance només
         * se farà quant es viatgi entre escenes) i així borrar sa 
         * nova còpia.
         */
        if(Instance != null)
        {
            Debug.LogError("There's more than an Instance");
        }
        Instance = this;

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
