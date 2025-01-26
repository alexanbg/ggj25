using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyPowerUp : MonoBehaviour
{
    [SerializeField]
    private float innerCircleRadius;
    [SerializeField]
    private float outterCircleradius;
    [SerializeField]
    private float minTeleportDistance;
    [SerializeField]
    private int ballCopies;
    [SerializeField]
    private SphericalGravity sphericalGravity;


    private Collider collider;
    private MeshRenderer renderer;
    private List<GameObject> copies;

    private void Start()
    {
        copies = new List<GameObject>();
        collider = GetComponent<Collider>();
        renderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collided with {LayerMask.LayerToName(collision.collider.gameObject.layer)}");
        if (LayerMask.LayerToName(collision.collider.gameObject.layer) == "Ball")
        {
            StartCoroutine(SpawnBalls(collision.collider.gameObject));
        }
    }

    private IEnumerator SpawnBalls(GameObject ball)
    {
        collider.enabled = false;
        renderer.enabled = false;
        for(int i = 0; i < ballCopies; i++)
        {
            yield return new WaitForSeconds(0.5f);
            copies.Add(Instantiate(ball));
            copies[i].transform.position = transform.position;
            sphericalGravity.rgBalls.Add(copies[i].GetComponent<Rigidbody>());
        }
        yield return new WaitForSeconds(10);
        foreach (var copy in copies)
        {
            sphericalGravity.rgBalls.Remove(copy.GetComponent<Rigidbody>());
            Destroy(copy);
        }
        copies = new List<GameObject>();
        collider.enabled = true;
        renderer.enabled = true;
        Respawn();
    } 

    private void Respawn()
    {
        Vector3 newPosition = new Vector3();
        do
        {
            newPosition = new Vector3(
            Random.Range(-outterCircleradius, outterCircleradius),
            Random.Range(-outterCircleradius, outterCircleradius),
            Random.Range(-outterCircleradius, outterCircleradius)
            );
        } while (Vector3.Distance(transform.position, newPosition) < minTeleportDistance || Vector3.Distance(newPosition, Vector3.zero) < innerCircleRadius);

        transform.position = newPosition;
    }
}
