using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    public string SeuraavaLeveli;

    public void SkipLevel() {
        if(GameManager.instanssi != null) {
            GameManager.instanssi.level++;
        }
        SceneManager.LoadScene(SeuraavaLeveli);
    }
}
