using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Scene scene;
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    // Start is called before the first frame update
    public void ReloadScene()
    {
        SceneManager.LoadScene(scene.name);
        Debug.Log("Recargando Escena");
    }
}
