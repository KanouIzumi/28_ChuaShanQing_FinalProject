using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy_Controller : MonoBehaviour
{

    public GameObject scoreText;
    public static int score;

    private NavMeshAgent navMeshAgent;
    private GameObject character;



    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("ScoreText");
        character = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(character.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
       navMeshAgent.SetDestination(character.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            score +=6;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("Hit");
            scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
        }
    }
}
