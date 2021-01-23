using UnityEngine;
using System.Collections;

public class Audio_player : MonoBehaviour {

    public AudioClip[] clips;

    AudioSource source;

    Transform camera;

	void Awake() {
        DontDestroyOnLoad(gameObject);
        source = GetComponent<AudioSource>();
        source.loop = false;
        camera = Camera.main.gameObject.transform;
	}

    void Start() // We want a specific song to be played at the menu!
    {
        source.clip = clips[0];
        source.Play();
    }
	
	void Update ()
    {
	    if(!source.isPlaying)
        {
            source.clip = newClip();
            source.Play();
        }

        transform.position = camera.position;
	}

    void OnLevelWasLoaded(int level)
    {
        Awake();
    }

    AudioClip newClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }
}
