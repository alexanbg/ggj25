using TMPro;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;


    private Rigidbody rb;

    private static int score = 0;
    public float normalMultiplier = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        UpdateScore(1);
        Vector3 normal = collision.GetContact(0).normal;
        rb.AddForce(normal * normalMultiplier, ForceMode.Force);
    }

    private void UpdateScore(int increment)
    {
        score += increment;
        text.text = $"SCORE\n{score:d4}";
    }

}
