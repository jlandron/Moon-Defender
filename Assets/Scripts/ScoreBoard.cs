using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    Text scoreText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>( );
        scoreText.text = score.ToString();
        score = 0;
    }
    public void ScoreHit(int scorePerEnemy ) {
        score = score + scorePerEnemy;
        scoreText.text = score.ToString( );
    }
}
