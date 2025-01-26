using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField]
    private float boosterMultiplier;
    [SerializeField]
    private AudioSource whooshSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (LayerMask.LayerToName(collision.collider.gameObject.layer) == "Ball")
        {
            whooshSound.Play();
            collision.body.transform.GetComponent<Rigidbody>().AddForce(-collision.GetContact(0).normal * boosterMultiplier, ForceMode.Force);
        }

            
    }
}
