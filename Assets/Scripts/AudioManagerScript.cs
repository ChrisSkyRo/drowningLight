using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] private AudioClip enemyDeath;
    [SerializeField] private AudioClip enemyTeleport;
    [SerializeField] private AudioClip playerDeath;
    [SerializeField] private AudioClip playerHurt;
    [SerializeField] private AudioClip playerShoot;
    [SerializeField] private AudioClip playerTeleport;
    private AudioSource source;

    private void Awake() {
        source = gameObject.GetComponent<AudioSource>();
    }

    public void PlaySound(string sound) {
        if (sound == "ed")
            source.PlayOneShot(enemyDeath);
        else if (sound == "et")
            source.PlayOneShot(enemyTeleport);
        else if (sound == "pd")
            source.PlayOneShot(playerDeath);
        else if (sound == "ph")
            source.PlayOneShot(playerHurt);
        else if (sound == "ps")
            source.PlayOneShot(playerShoot);
        else if (sound == "pt")
            source.PlayOneShot(playerTeleport);
    }
}
