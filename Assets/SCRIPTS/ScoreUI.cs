using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// Script que s'encarregarà de mostrar tata sa lògica interna
/// </summary>
public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    //funció que actualitza es text, la cridam a dedins es game manager, funció AddScore
    public void UpdateScoreText(int score)
    {
        //es to string és lo mateix que posar "{score}"
        scoreText.text = score.ToString(); 
    }
}
