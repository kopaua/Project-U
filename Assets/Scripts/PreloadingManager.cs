using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreloadingManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }  
}
