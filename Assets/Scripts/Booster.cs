using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField]
    private float boosterMultiplier;

    private void OnCollisionEnter(Collision collision)
    {
        collision.body.transform.GetComponent<Rigidbody>().AddForce(-collision.GetContact(0).normal * boosterMultiplier, ForceMode.Force);
    }
}
