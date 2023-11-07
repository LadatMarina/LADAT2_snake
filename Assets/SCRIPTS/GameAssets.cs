using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets Instance { get; private set; }

    public Sprite snakeHeadSprite; //asignar sprite a s'inspector
    public Sprite snakeBodySprite;
    public Sprite foodSprite;

    public AudioClip buttonClickclip;
    public AudioClip buttonOverClip;
    public AudioClip snakeDieClip;
    public AudioClip snakeEatClip;
    public AudioClip snakeMoveClip;

    public SoundAudioClip[] soundAudioClipsArray;


    /// <SOUND AUDIO CLIP>
    /// estructura que lligar� es enums i es audioclips
    /// �s de tipus serializable per poder accedir a ella des de inspector i asignar es audioclips de forma f�cil
    /// </summary>
    [Serializable] public class SoundAudioClip
    {
        public SoundManager.Sound sound; //un valor de s'enumerado sound 
        public AudioClip audioClip; //un audioclip
        //per tant nom�s necessit dues l�nies i la resta ho faig des d'inspector
    }

    private void Awake()
    {
        /*Nova forma de fer una variable statica:
         * Feim que quant detecti una nova c�pia de Instance,
         * en lloc d'eliminar-la, feim que surti un error que
         * te faci sortir de es modo play (sa nova instance nom�s
         * se far� quant es viatgi entre escenes) i aix� borrar sa 
         * nova c�pia.
         */
        if (Instance != null)
        {
            Debug.LogError("There's more than an Instance");
        }
        Instance = this;

    }
}
