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
    /// estructura que lligarà es enums i es audioclips
    /// és de tipus serializable per poder accedir a ella des de inspector i asignar es audioclips de forma fàcil
    /// </summary>
    [Serializable] public class SoundAudioClip
    {
        public SoundManager.Sound sound; //un valor de s'enumerado sound 
        public AudioClip audioClip; //un audioclip
        //per tant només necessit dues línies i la resta ho faig des d'inspector
    }

    private void Awake()
    {
        /*Nova forma de fer una variable statica:
         * Feim que quant detecti una nova còpia de Instance,
         * en lloc d'eliminar-la, feim que surti un error que
         * te faci sortir de es modo play (sa nova instance només
         * se farà quant es viatgi entre escenes) i així borrar sa 
         * nova còpia.
         */
        if (Instance != null)
        {
            Debug.LogError("There's more than an Instance");
        }
        Instance = this;

    }
}
