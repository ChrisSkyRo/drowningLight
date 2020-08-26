using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour {

    public void OpenTwitter() {
        #if !UNITY_EDITOR
            openWindow("https://twitter.com/ChrisSkyRo");
        #endif
    }
    [DllImport("__Internal")]
    private static extern void openWindow(string url);

}