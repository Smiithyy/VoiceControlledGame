using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreUI;
    private static int score;

    void Start()
    {
        scoreUI = GetComponent<Text>();
        score = 0;
    }

    void Update()
    {
        scoreUI.text = "" + score;
    }

    public static void AddScore()
    {
        score += 1;
    }
}
