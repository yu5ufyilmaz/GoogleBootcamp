using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class menu : MonoBehaviour
{
    
    public void ButtonStr(string SceneName)
    {
            SceneManager.LoadScene(SceneName);
            PlayerPrefs.SetInt("DeathCount",0);
    }
}

