using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI :MonoBehaviour
{
    // Singleton
    public static GameOverUI Instance { get; private set; }

    [SerializeField] private Button restartButton;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Instance");
        }

        Instance = this;

        restartButton.onClick.AddListener(() => { Loader.Load(Loader.Scene.Game); });
        //restartButton.onClick.AddListener(RestartButtonFunction);

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

    // private void RestartButtonFunction()
    // {
    //     Loader.Load(Loader.Scene.Game);
    // }
}
