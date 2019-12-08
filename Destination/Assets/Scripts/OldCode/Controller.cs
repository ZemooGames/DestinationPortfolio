using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

    private static Controller controller;

	public static Controller Instance()
    {
        if (!controller)
        {
            controller = FindObjectOfType(typeof(Controller)) as Controller;
            if (!controller)
                Debug.Log("There needs to be at least one controller");
        }
        return controller;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Foo()
    {
        Debug.Log("FOO");
        Vector3 f = new Vector3(5, -4, 0);
        AppleScript.current.CreateShot(f);
    }
}
