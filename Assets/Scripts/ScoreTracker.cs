using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    private int score;

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int amount)
    {
        score += amount;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
