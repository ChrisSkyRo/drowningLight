using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    [SerializeField] private Transform demonicEye;
    [SerializeField] private Transform devil;
    [SerializeField] private Transform imp;
    [SerializeField] private Transform darkAngel;
    [SerializeField] private Transform waveText;
    private DarkAngelScript das;
    private Transform player;
    private int wave;
    public int enemiesAlive;
    public Animator victory;
    private Vector3[] Spawners = new[] {
        new Vector3(0, 28, 0),
        new Vector3(30, 28, 0),
        new Vector3(30, 0, 0),
        new Vector3(30, -28, 0),
        new Vector3(0, -28, 0),
        new Vector3(-30, -28, 0),
        new Vector3(-30, 0, 0),
        new Vector3(-30, 28, 0),
    };


    private void Awake() {
        wave = 0;
        enemiesAlive = 0;
        player = GameObject.Find("Angel").GetComponent<Transform>();
    }

    private void Update() {
        if(enemiesAlive == 0) {
            wave++;
            WaveSpawn(wave);
        }
    }

    private void WaveSpawn(int number) {
        Transform wt = Instantiate(waveText, Vector3.zero, Quaternion.identity);
        WaveTextScript ws = wt.GetComponent<WaveTextScript>();
        ws.Setup(number);
        Transform eye;
        EyeScript es;
        if (number == 1) {
            enemiesAlive = 16;
            // 3 small eyes in each corner
            for(int i = 1;i <= 3; i++) {
                eye = Instantiate(demonicEye, Spawners[1], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[3], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[5], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[7], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
            }
            // 1 medium eye on each edge
            eye = Instantiate(demonicEye, Spawners[0], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(2);
            eye = Instantiate(demonicEye, Spawners[2], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(2);
            eye = Instantiate(demonicEye, Spawners[4], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(2);
            eye = Instantiate(demonicEye, Spawners[6], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(2);
        }
        else if (number == 2) {
            enemiesAlive = 28;
            // 2 big eyes
            eye = Instantiate(demonicEye, Spawners[1], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(3);
            eye = Instantiate(demonicEye, Spawners[5], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(3);
            // 6 medium eyes
            for (int i = 1; i <= 3; i++) {
                eye = Instantiate(demonicEye, Spawners[7], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
                eye = Instantiate(demonicEye, Spawners[3], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
            }
            // 20 small eyes
            for (int i = 1;i <= 5; i++) {
                eye = Instantiate(demonicEye, Spawners[0], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[2], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[4], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[6], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
            }
        }
        else if (number == 3) {
            enemiesAlive = 37;
            // 1 imp
            Instantiate(imp, Spawners[0], Quaternion.identity);
            // 4 medium eyes
            for(int i = 1;i <= 4; i++) {
                eye = Instantiate(demonicEye, Spawners[0], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
            }
            // 2 big eyes
            eye = Instantiate(demonicEye, Spawners[1], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(3);
            eye = Instantiate(demonicEye, Spawners[7], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(3);
            // 30 small eyes
            for(int i = 1;i <= 10; i++) {
                eye = Instantiate(demonicEye, Spawners[3], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[4], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[5], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
            }
        }
        else if (number == 4) {
            enemiesAlive = 74;
            // 2 imps
            Instantiate(imp, Spawners[2], Quaternion.identity);
            Instantiate(imp, Spawners[6], Quaternion.identity);
            // 52 small eyes
            for (int i = 1;i <= 13; i++) {
                eye = Instantiate(demonicEye, Spawners[1], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[3], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[5], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[7], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
            }    
            // 20 medium eyes
            for (int i = 1;i <= 10; i++) {
                eye = Instantiate(demonicEye, Spawners[0], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
                eye = Instantiate(demonicEye, Spawners[4], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
            }
        }
        else if (number == 5) {
            enemiesAlive = 44;
            // 4 imps
            Instantiate(imp, Spawners[1], Quaternion.identity);
            Instantiate(imp, Spawners[3], Quaternion.identity);
            Instantiate(imp, Spawners[5], Quaternion.identity);
            Instantiate(imp, Spawners[7], Quaternion.identity);
            // 40 medium eyes
            for (int i = 1;i <= 10; i++) {
                eye = Instantiate(demonicEye, Spawners[0], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
                eye = Instantiate(demonicEye, Spawners[2], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
                eye = Instantiate(demonicEye, Spawners[4], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
                eye = Instantiate(demonicEye, Spawners[6], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
            }
        }
        else if (number == 6) {
            enemiesAlive = 46;
            // 1 devil
            Instantiate(devil, Spawners[0], Quaternion.identity);
            // 5 imps
            Instantiate(imp, Spawners[1], Quaternion.identity);
            Instantiate(imp, Spawners[3], Quaternion.identity);
            Instantiate(imp, Spawners[4], Quaternion.identity);
            Instantiate(imp, Spawners[5], Quaternion.identity);
            Instantiate(imp, Spawners[7], Quaternion.identity);
            // 40 small eyes
            for(int i = 1;i <= 5; i++) {
                eye = Instantiate(demonicEye, Spawners[0], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[1], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[2], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[3], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[4], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[5], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[6], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
                eye = Instantiate(demonicEye, Spawners[7], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(1);
            }
        }
        else if (number == 7) {
            enemiesAlive = 56;
            // 4 devils
            Instantiate(devil, Spawners[0], Quaternion.identity);
            Instantiate(devil, Spawners[2], Quaternion.identity);
            Instantiate(devil, Spawners[4], Quaternion.identity);
            Instantiate(devil, Spawners[6], Quaternion.identity);
            // 4 imps
            Instantiate(imp, Spawners[1], Quaternion.identity);
            Instantiate(imp, Spawners[3], Quaternion.identity);
            Instantiate(imp, Spawners[5], Quaternion.identity);
            Instantiate(imp, Spawners[7], Quaternion.identity);
            // 48 medium eyes
            for(int i = 1;i <= 6; i++) {
                eye = Instantiate(demonicEye, Spawners[0], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
                eye = Instantiate(demonicEye, Spawners[1], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
                eye = Instantiate(demonicEye, Spawners[2], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
                eye = Instantiate(demonicEye, Spawners[3], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
                eye = Instantiate(demonicEye, Spawners[4], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
                eye = Instantiate(demonicEye, Spawners[5], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
                eye = Instantiate(demonicEye, Spawners[6], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
                eye = Instantiate(demonicEye, Spawners[7], Quaternion.identity);
                es = eye.GetComponent<EyeScript>();
                es.Setup(2);
            }
        }
        else if (number == 8) {
            enemiesAlive = 112;
            StartCoroutine(Wave8());
        }
        else if (number == 9) {
            enemiesAlive = 1000000;
            Transform dark = Instantiate(darkAngel, new Vector3(0, 30, 0), Quaternion.identity);
            das = dark.GetComponent<DarkAngelScript>();
        }
    }

    IEnumerator Wave8() {
        Transform eye;
        EyeScript es;
        // 8 devils
        Instantiate(devil, Spawners[0], Quaternion.identity);
        yield return new WaitForSeconds(3);
        Instantiate(devil, Spawners[1], Quaternion.identity);
        yield return new WaitForSeconds(3);
        Instantiate(devil, Spawners[2], Quaternion.identity);
        yield return new WaitForSeconds(3);
        Instantiate(devil, Spawners[3], Quaternion.identity);
        yield return new WaitForSeconds(3);
        Instantiate(devil, Spawners[4], Quaternion.identity);
        yield return new WaitForSeconds(3);
        Instantiate(devil, Spawners[5], Quaternion.identity);
        yield return new WaitForSeconds(3);
        Instantiate(devil, Spawners[6], Quaternion.identity);
        yield return new WaitForSeconds(3);
        Instantiate(devil, Spawners[7], Quaternion.identity);
        yield return new WaitForSeconds(3);
        // 8 imps
        Instantiate(imp, Spawners[0], Quaternion.identity);
        yield return new WaitForSeconds(3);
        Instantiate(imp, Spawners[1], Quaternion.identity);
        yield return new WaitForSeconds(3);
        Instantiate(imp, Spawners[2], Quaternion.identity);
        yield return new WaitForSeconds(3);
        Instantiate(imp, Spawners[3], Quaternion.identity);
        yield return new WaitForSeconds(3);
        Instantiate(imp, Spawners[4], Quaternion.identity);
        yield return new WaitForSeconds(3);
        Instantiate(imp, Spawners[5], Quaternion.identity);
        yield return new WaitForSeconds(3);
        Instantiate(imp, Spawners[6], Quaternion.identity);
        yield return new WaitForSeconds(3);
        Instantiate(imp, Spawners[7], Quaternion.identity);
        yield return new WaitForSeconds(90);
        // 96 eyes
        // 48 small eyes    
        for (int i = 1; i <= 6; i++) {
            eye = Instantiate(demonicEye, Spawners[0], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(1);
            eye = Instantiate(demonicEye, Spawners[1], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(1);
            eye = Instantiate(demonicEye, Spawners[2], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(1);
            eye = Instantiate(demonicEye, Spawners[3], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(1);
            eye = Instantiate(demonicEye, Spawners[4], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(1);
            eye = Instantiate(demonicEye, Spawners[5], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(1);
            eye = Instantiate(demonicEye, Spawners[6], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(1);
            eye = Instantiate(demonicEye, Spawners[7], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(1);
            yield return new WaitForSeconds(5);
        }
        // 32 medium eyes
        for (int i = 1; i <= 4; i++) {
            eye = Instantiate(demonicEye, Spawners[0], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(2);
            eye = Instantiate(demonicEye, Spawners[1], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(2);
            eye = Instantiate(demonicEye, Spawners[2], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(2);
            eye = Instantiate(demonicEye, Spawners[3], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(2);
            eye = Instantiate(demonicEye, Spawners[4], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(2);
            eye = Instantiate(demonicEye, Spawners[5], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(2);
            eye = Instantiate(demonicEye, Spawners[6], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(2);
            eye = Instantiate(demonicEye, Spawners[7], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(2);
            yield return new WaitForSeconds(5);
        }
        // 16 big eyes
        for (int i = 1; i <= 2; i++) {
            eye = Instantiate(demonicEye, Spawners[0], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(3);
            eye = Instantiate(demonicEye, Spawners[1], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(3);
            eye = Instantiate(demonicEye, Spawners[2], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(3);
            eye = Instantiate(demonicEye, Spawners[3], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(3);
            eye = Instantiate(demonicEye, Spawners[4], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(3);
            eye = Instantiate(demonicEye, Spawners[5], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(3);
            eye = Instantiate(demonicEye, Spawners[6], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(3);
            eye = Instantiate(demonicEye, Spawners[7], Quaternion.identity);
            es = eye.GetComponent<EyeScript>();
            es.Setup(3);
            yield return new WaitForSeconds(5);
        }
    }

}
