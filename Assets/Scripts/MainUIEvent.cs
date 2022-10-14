using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIEvent:MonoBehaviour
{
    public void EnterGame() {
        SceneManager.LoadScene("Battle");
    }
}
