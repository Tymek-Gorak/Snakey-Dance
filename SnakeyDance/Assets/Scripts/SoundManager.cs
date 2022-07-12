using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();
    [SerializeField]private AudioSource audioS;
    [SerializeField]private AudioSource musicSource;
    [SerializeField]private AudioSource musicLoop;
    public static SoundManager instance;
    public static SoundManager Instance{
        get{
        if(instance == null){
            instance = FindObjectOfType<SoundManager>();
        } return instance;}
    }
    void Start()
    {
        sounds.Add("Bite", Resources.Load<AudioClip>("Sounds/Bite"));
        sounds.Add("Mace", Resources.Load<AudioClip>("Sounds/MaceHit"));
        sounds.Add("TailS", Resources.Load<AudioClip>("Sounds/TailSoundS"));
        sounds.Add("TailB", Resources.Load<AudioClip>("Sounds/TailSoundB"));
        sounds.Add("MoveScreen", Resources.Load<AudioClip>("Sounds/death"));
        sounds.Add("Death", Resources.Load<AudioClip>("Sounds/death"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(string soundName, float volume){
        audioS.PlayOneShot(sounds[soundName], volume);
    }

    private IEnumerator Music(){
        musicSource.Play();
        yield return new WaitForSeconds(0.2f);
        while(true){
            if(!musicSource.isPlaying && !musicLoop.isPlaying){
            musicLoop.Play();
            yield return new WaitForSeconds(0f);
        }
        yield return new WaitForSeconds(0.1f);
        }
    }
}
