using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public void StartGameFunction()
    {
        SceneManager.LoadScene("Lvl1");
        //Cursor.visible = false;
    }
    public void ExitGameFunction() {
        Application.Quit();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        //Cursor.visible = false;
    }
}
