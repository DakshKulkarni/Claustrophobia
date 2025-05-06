using UnityEngine;
public class Footstep : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip footstepSound;
    public float stepInterval = 0.5f;
    private float stepTimer = 0f;
    private Vector3 lastPosition;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        lastPosition = transform.position;
    }
    void Update()
    {
        float speed = (transform.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = transform.position;

        if (speed > 0.1f)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepInterval)
            {
                PlayFootstepSound();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }
    void PlayFootstepSound()
    {
        if (footstepSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(footstepSound);
        }
    }
}
