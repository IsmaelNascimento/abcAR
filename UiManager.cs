using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public void LoadScene(string value)
    {
        SceneManager.LoadScene(value);
    }
    
}
