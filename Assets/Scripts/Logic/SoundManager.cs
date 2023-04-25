using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource _music;
    [SerializeField]
    AudioSource _sound;

    public bool MusicIsOn { get; private set; } = true;
    public bool SoundIsOn { get; private set; } = true;
    public static SoundManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void OnSound()
    {
        _sound.mute = SoundIsOn;
        SoundIsOn = !SoundIsOn;
    }
    public void OnMusic()
    {
        _music.mute = MusicIsOn;
        MusicIsOn = !MusicIsOn;
    }
}
