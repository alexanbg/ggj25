using System.Collections.Generic;
using UnityEngine;

public class SphericalGravity : MonoBehaviour
{
    public float forceFactor = 200f;

    [SerializeField]
    private List<Rigidbody> rgBalls;

    Transform magnetP;

    void Start()
    {
        magnetP = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        foreach (Rigidbody rgBall in rgBalls)
        {
            rgBall.AddForce(Vector3.Normalize(transform.position - rgBall.position)
                * forceFactor
                * Time.fixedDeltaTime);
        }
    }

}
