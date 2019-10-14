using UnityEngine;
using TMPro;

public class Tries : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI triesText;
    private int tries = 3;

    [SerializeField] private GameOver gameOver;

    public void RemoveTry()
    {
        tries--;
        triesText.text = "x" + tries.ToString();
        CheckGameOver();
    }

    public void AddTry()
    {
        tries++;
        triesText.text = "x" + tries.ToString();
    }

    private void CheckGameOver()
    {
        if(tries <= 0)
        {
            gameOver.CallGameOver();
        }
    }
}
