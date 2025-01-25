using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1000;

    
    public void Update()
    {
        //rb.AddRelativeTorque(keyValues.x * rotationSpeed * Time.deltaTime, 0, keyValues.y * rotationSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0),Space.World);
    }
}
