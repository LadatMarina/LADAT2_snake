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
         * Feim que quant detecti una nova c�pia de Instance,
         * en lloc d'eliminar-la, feim que surti un error que
         * te faci sortir de es modo play (sa nova instance nom�s
         * se far� quant es viatgi entre escenes) i aix� borrar sa 
         * nova c�pia.
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
