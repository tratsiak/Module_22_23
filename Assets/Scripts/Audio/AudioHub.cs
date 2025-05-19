using UnityEngine;
using UnityEngine.Audio;

public class AudioHub : MonoBehaviour
{
    private const string MusicVolumeKey = "MusicVolume";
    private const string SoundsVolumeKey = "SoundsVolume";

    private const float MaxVolume = 0f;
    private const float MinVolume = -80f;

    [SerializeField] private AudioMixer _audioMixer;

    private bool isMusicMuted = false;
    private bool isSoundsMuted = false;

    public void ToggleMusic()
    {
        isMusicMuted = !isMusicMuted;
        _audioMixer.SetFloat(MusicVolumeKey, isMusicMuted ? MinVolume : MaxVolume);
    }

    public void ToggleSounds()
    {
        isSoundsMuted = !isSoundsMuted;
        _audioMixer.SetFloat(SoundsVolumeKey, isSoundsMuted ? MinVolume : MaxVolume);
    }
}
