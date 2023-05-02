using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        if (player)
            scoreText.text = player.position.z.ToString("0");
        else
            scoreText.text = scoreText.text;
    }
}
