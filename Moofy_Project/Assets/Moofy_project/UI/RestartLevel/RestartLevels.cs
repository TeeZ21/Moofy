using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevels : MonoBehaviour {

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }
}
