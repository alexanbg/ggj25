using UnityEngine;

public class ScorePickUp : MonoBehaviour
{
    [SerializeField]
    private float innerCircleRadius;
    [SerializeField]
    private float outterCircleradius;
    [SerializeField]
    private float minTeleportDistance;
    [SerializeField]
    private AudioSource pickUpSound;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log($"Collided with {LayerMask.LayerToName(collision.collider.gameObject.layer)}");
        if (LayerMask.LayerToName(collision.collider.gameObject.layer)=="Ball")
        {
            collision.collider.transform.GetComponent<ScoringSystem>().UpdateScore(200);
            pickUpSound.Play();
            Respawn();
        }
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
