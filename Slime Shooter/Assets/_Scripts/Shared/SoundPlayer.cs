using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource vacuumLoop;

    public static SoundPlayer instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlaySFX(AudioClip _sfx)
    {
        audioSource.PlayOneShot(_sfx);
    }

    public void StopSFX()
    {
        audioSource.Stop();
    }

    public void PlayVacuumLoop()
    {
        vacuumLoop.Play();
    }

    public void StopVacuumLoop()
    {
        vacuumLoop.Stop();
    }
}