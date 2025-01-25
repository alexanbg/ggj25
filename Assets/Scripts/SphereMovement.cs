using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1000;

    
    public void Update()
    {
        //rb.AddRelativeTorque(keyValues.x * rotationSpeed * Time.deltaTime, 0, keyValues.y * rotationSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(Input.GetAxisRaw("Vertical") * rotationSpeed * Time.deltaTime, -Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, 0),Space.World);
    }
}
