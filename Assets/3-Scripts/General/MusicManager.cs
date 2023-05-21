using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip[] musicClips;
    [SerializeField] private int currentClipIndex = 0;

    private void Start()
    {
        // Get the AudioSource component attached to the GameObject
        musicSource = GetComponent<AudioSource>();
        // Set the initial music clip to play
        musicSource.clip = musicClips[currentClipIndex];
        // Start the PlayMusic coroutine
        StartCoroutine(PlayMusic());
    }

    private void FixedUpdate()
    {
        // Update the music volume based on the saved MusicVolume value in PlayerPrefs
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    // Coroutine that plays music clips in sequence
    private IEnumerator PlayMusic()
    {
        while (true)
        {
            // Play the next clip in the sequence
            PlayNextClip();
            // Wait for the duration of the current clip before continuing the loop
            yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        }
    }

    // Function to play the next music clip in the sequence
    private void PlayNextClip()
    {
        // If the currentClipIndex is equal to or greater than the number of music clips, reset the index
        if (currentClipIndex >= musicClips.Length)
        {
            currentClipIndex = 0;
        }

        // Set the current clip to play and then play it
        GetComponent<AudioSource>().clip = musicClips[currentClipIndex];
        GetComponent<AudioSource>().Play();
        // Increment the currentClipIndex to prepare for the next clip
        currentClipIndex++;
    }
}
