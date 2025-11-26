using UnityEngine;

public class CarAudio : MonoBehaviour
{
    public Rigidbody carRigidbody; 
    public AudioSource engineAudio;
    public AudioClip startClip; 
    public AudioClip idleClip;   
    public AudioClip runningClip; 
    public float minPitch = 0.45f;
    public float maxPitch = 1.0f;
    public float maxSpeed = 100f; 
    public float idleThreshold = 0.1f;
    private bool hasStarted = false;

    void Start()
    {
        engineAudio.clip = startClip;
        engineAudio.loop = false;
        engineAudio.Play();
    }

    void Update()
    {
        if (!engineAudio.isPlaying && !hasStarted)
        {
            hasStarted = true;
            engineAudio.clip = idleClip;
            engineAudio.loop = true;
            engineAudio.Play();
        }
        float speed = carRigidbody.velocity.magnitude;
        if (speed > idleThreshold)
        {
            if (engineAudio.clip != runningClip)
            {
                engineAudio.clip = runningClip;
                engineAudio.loop = true;
                engineAudio.Play();
            }
            float pitch = Mathf.Lerp(minPitch, maxPitch, speed / maxSpeed);
            engineAudio.pitch = pitch;
        }
        else
        {
            if (engineAudio.clip != idleClip)
            {
                engineAudio.clip = idleClip;
                engineAudio.loop = true;
                engineAudio.Play();
                engineAudio.pitch = 1.0f; 
            }
        }
    }
}
