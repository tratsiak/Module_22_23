using UnityEngine;

public class AutoDestroySound : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.PlayOneShot(_audioSource.clip);

        Destroy(gameObject, _audioSource.clip.length);
    }
}
