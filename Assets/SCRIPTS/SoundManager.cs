using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager 
{
    //enum  per definir es sonido
    public enum Sound
    {
        ButtonClick,
        ButtonOver,
        SnakeDie,
        SnakeEat,
        SnakeMove
    }

    public static GameObject soundManagerGameObject;
    private static AudioSource audioSource;

    public static void CreateSoundManagerGameObject()
    {

    }
    /// <summary>
    /// reprodueix un arxiu d'audio
    /// cream un empty object, li asignam s'audio source i reproduim es clip
    /// </summary>
    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound" + sound);
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClipFromSound(sound));
    }

    /// <GetAudioClipFromSound explanation>
    /// amb es bucle accedim a tots es elements de sa llista, que estan fets amb una clase estatica
    /// pues aquests elements que hi ha dins sa llista, que relacionen es Sound enum amb es audioclips,
    /// els anirem comprovant que es paràmetre que hem passat a sa funció GetAudioClipFromSound coincideixi
    /// amb sa variable Sound de s'element de sa llista.
    /// Si coincideix, retornam es clip corresponent 
    /// 
    /// <param name="sound"></param>
    private static AudioClip GetAudioClipFromSound(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.Instance.soundAudioClipsArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found");
        return null;
    }
}
