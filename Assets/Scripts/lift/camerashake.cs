using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerashake : MonoBehaviour
{
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 1f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.3f;
    public float decreaseFactor = 2.0f;

    private float timer;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }



    void Update()
    {
        if (Mathf.FloorToInt(timer % 60) > 5)
        {
            if (shakeDuration > 0)
            {
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeDuration = 0f;
                camTransform.localPosition = originalPos;
                timer = 0;
            }
        }

        timer += Time.deltaTime;    
    }
}
