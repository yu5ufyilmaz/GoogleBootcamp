using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathCollider : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    private void Start()
    {
        score = PlayerPrefs.GetInt("DeathCount");
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IncreaseScore();
            SceneManager.LoadScene("StartScene");
            
        }
    }

    private void IncreaseScore()
    {
        score = PlayerPrefs.GetInt("DeathCount");
        score++;
        PlayerPrefs.SetInt("DeathCount",score);
        scoreText.text = score.ToString();
    }
}