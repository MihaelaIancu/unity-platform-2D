using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public static void BackToMenuBtn() {
        SceneManager.LoadScene("Main");
    }
}
