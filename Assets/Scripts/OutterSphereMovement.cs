using UnityEngine;

public class OutterSphereMovement : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1000;


    public void Update()
    {
        // var x = Input.GetAxisRaw("Debug Horizontal");
        // var y = Input.GetAxisRaw("Debug Vertical");
        //rb.AddRelativeTorque(keyValues.x * rotationSpeed * Time.deltaTime, 0, keyValues.y * rotationSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(Input.GetAxis("Debug Vertical") * rotationSpeed * Time.deltaTime, -Input.GetAxis("Debug Horizontal") * rotationSpeed * Time.deltaTime, 0), Space.World);
        // Debug.Log("debug input " + x + y );
    }
}
