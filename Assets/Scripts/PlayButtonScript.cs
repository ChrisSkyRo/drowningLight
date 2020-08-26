using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    private TextMeshPro text;
    private MenuManager sound;

    private void Awake() {
        text = gameObject.GetComponent<TextMeshPro>();
        sound = GameObject.Find("AudioManager").GetComponent<MenuManager>();
    }

    private void OnMouseEnter() {
        text.color = new Color(168, 0, 0);
        text.text = "Suffer";
        sound.PlaySound("heart");
    }

    private void OnMouseExit() {
        text.color = Color.white;
        text.text = "Play";
    }

    private void OnMouseDown() {
        SceneManager.LoadScene(1);
    }

}
