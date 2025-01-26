using System;
using TMPro;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    bool valid = true;
    //SCORE

    [SerializeField]
    private TMP_Text text;

    private Rigidbody rb;

    private static int score = 0;
    public float normalMultiplier = 1f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameOver.gameObject.SetActive(!valid);
    }
    private void OnCollisionEnter(Collision collision)
    {
        UpdateScore(1);
        Vector3 normal = collision.GetContact(0).normal;
        rb.AddForce(normal * normalMultiplier, ForceMode.Force);
    }

    private void UpdateScore(int increment)
    {
        if (valid == true)
        {
            score += increment;
            text.text = $"SCORE\n{100 * score:d8}";
        }
    }


    // ------------------------------------
    //TIME   +     GAME OVER MECHANICS

    public float targetTime = 10.0f;

    [SerializeField]
    private TMP_Text TimeText;
    [SerializeField]
    private TMP_Text GameOver;

    private void Update()
    {
        if (valid == true)
        {
            targetTime -= Time.deltaTime;


            TimeText.text = "TIME:" + "\n  " + Mathf.Round(targetTime);

            if (targetTime <= 0.0f)
            {
                timerEnded();
            }
        }
        else
        {
            if(score*100 > 50000)
            {
                GameOver.text = "         Good job. YOU WON!";
            }
            else
            {
                GameOver.text = "         YOU LOST!hAHAHA-";
            }
            GameOver.gameObject.SetActive(!valid);
        }
    }
    private void timerEnded()
    {
        valid = false;
        targetTime = 0f;
        // DO YOUR STUFF HERE
    }

}
