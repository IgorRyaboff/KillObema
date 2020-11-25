using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    new AudioSource audio;
    public AudioClip[] menuClips, ingameClips;
    public UIManager uiMan;
    int currentState;
    float clipLengthLeft = 10000;
    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        Reset(0);
    }

    void Update() {
        clipLengthLeft -= Time.deltaTime;
        if (clipLengthLeft <= 0) Reset(currentState);
    }

    public void Reset(int state) {
        if (audio == null) return;
        AudioClip[] clips;
        if (state == 0) clips = menuClips;
        else clips = ingameClips;

        audio.Stop();
        audio.clip = clips[Random.Range(0, clips.Length)];
        audio.Play();
        clipLengthLeft = audio.clip.length;
        currentState = state;
        uiMan.UpdateBGMusicName(audio.clip.name);
    }

    public void SetVolume(float value) {
        audio.volume = value;
    }
}
