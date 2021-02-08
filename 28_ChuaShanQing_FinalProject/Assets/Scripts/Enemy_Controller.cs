using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Controller : MonoBehaviour
{
    public GameObject scoreText;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            score++;
            Destroy(gameObject);
            Destroy(collision.gameObject);

            scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
        }
    }
}
