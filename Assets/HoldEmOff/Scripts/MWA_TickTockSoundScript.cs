using UnityEngine;

public class TimerAudio : MonoBehaviour
{
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioSource audioSource;

    private bool playFirstClip = true;

    public void PlayTickTock(float timeRemaining)
    {
        if (Mathf.FloorToInt(timeRemaining) % 2 == 1 && playFirstClip)
        {
            PlayClip(audioClip1);
            playFirstClip = false;
        }
        else if (Mathf.FloorToInt(timeRemaining) % 2 == 0 && !playFirstClip)
        {
            PlayClip(audioClip2);
            playFirstClip = true;
        }
    }

    private void PlayClip(AudioClip clip)
    {
        if (audioSource.isPlaying) return;
        audioSource.clip = clip;
        audioSource.Play();
    }
}
