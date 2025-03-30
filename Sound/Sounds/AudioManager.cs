using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    public AudioClip theme;
    public AudioClip burning;
    public AudioClip dyingchild;
    public AudioClip grunt;
    public AudioClip gunshot;
    public AudioClip paper1;
    public AudioClip paper2;
    public AudioClip peopleshouting;
    public AudioClip policesiren;
    public AudioClip trumpet;

    private void Start()
    {
        musicSource.clip = theme;
        musicSource.loop = true;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
