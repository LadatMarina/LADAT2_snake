using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public static PauseUI Instance { get; private set; }

    public Button resumeButton;
    public Button mainMenuButton;

    private void Awake()
    {
        if (Instance != null)
        {
            //com que ja hi ha una instancia, hi ha més d'una instancia jiji
            Debug.LogError("Is more than one instance");
        }
        Instance = this;

        //asignam ses funcions a nes botons corresponents
        resumeButton.onClick.AddListener(()=> { GameManager.Instance.ResumeGame(); }); 

        mainMenuButton.onClick.AddListener(()=>
        {
            Time.timeScale = 1f;
            Loader.Load(Loader.Scene.MainMenu);
        });
        //inicialitzam es panel hided
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
