using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClipDoneTrain;

    public void PlayDone()
    {
        _audioSource.PlayOneShot(_audioClipDoneTrain);
    }
}