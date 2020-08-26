using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private AudioClip heartbeat;
    [SerializeField] private AudioClip instr;
    private AudioSource source;

    private void Awake() {
        source = gameObject.GetComponent<AudioSource>();
    }

    public void PlaySound(string sound) {
        if (sound == "heart")
            source.PlayOneShot(heartbeat);
        else if (sound == "instr")
            source.PlayOneShot(instr);
    }

}
