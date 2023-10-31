using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// Script que s'encarregar� de mostrar tata sa l�gica interna
/// </summary>
public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    //funci� que actualitza es text, la cridam a dedins es game manager, funci� AddScore
    public void UpdateScoreText(int score)
    {
        //es to string �s lo mateix que posar "{score}"
        scoreText.text = score.ToString(); 
    }
}
