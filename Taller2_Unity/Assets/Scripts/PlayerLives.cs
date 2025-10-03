using TMPro;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int maxLives = 3;      
    public int currentLives;      
    public TMP_Text livesText;    

    void Start()
    {
        currentLives = maxLives;
        UpdateLivesUI();
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = currentLives.ToString();
    }
}
