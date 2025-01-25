using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 1f;

    private float shakedurationTracker = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 1.0f;
    public float decreaseFactor = 1.0f;

    public bool shaketrue = false;

    Vector3 originalPos;

    void Awake()
    {
        camTransform = transform;
        originalPos = camTransform.localPosition;
        shakedurationTracker = shakeDuration;
    }

    

    void Update()
    {
        if (shaketrue)
        {
            if (shakedurationTracker > 0)
            {
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

                shakedurationTracker -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakedurationTracker = shakeDuration;
                camTransform.localPosition = originalPos;
                shaketrue = false;
            }
        }
    }

    public void shakecamera()
    {
        shaketrue = true;
    }

}