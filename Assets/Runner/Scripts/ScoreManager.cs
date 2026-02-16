using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        scoreText.text = PlayerRunner.instance.goldNumber.ToString();
    }

    void Update()
    {
        scoreText.text = PlayerRunner.instance.goldNumber.ToString();
    }
}
