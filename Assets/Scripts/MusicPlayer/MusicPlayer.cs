using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource music;


    private void Start() 
    {
        music.Play();
    }
}
