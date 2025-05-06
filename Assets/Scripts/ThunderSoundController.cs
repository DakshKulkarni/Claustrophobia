using UnityEngine;

public class ThunderSoundController : MonoBehaviour
{
    public AudioSource thunderAudioSource;  // Assign your AudioSource component here
    public float minInterval = 10f;         // Minimum time between thunder sounds
    public float maxInterval = 30f;         // Maximum time between thunder sounds

    private float nextThunderTime;

    private void Start()
    {
        if (thunderAudioSource == null)
        {
            thunderAudioSource = GetComponent<AudioSource>();
        }

        ScheduleNextThunder();
    }

    private void Update()
    {
        if (Time.time >= nextThunderTime)
        {
            PlayThunder();
            ScheduleNextThunder();
        }
    }

    private void PlayThunder()
    {
        if (thunderAudioSource != null)
        {
            thunderAudioSource.Play();
        }
    }

    private void ScheduleNextThunder()
    {
        nextThunderTime = Time.time + Random.Range(minInterval, maxInterval);
    }
}
