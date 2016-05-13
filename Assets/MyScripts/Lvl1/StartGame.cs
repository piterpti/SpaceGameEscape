using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public void StartGameFunction()
    {
        SceneManager.LoadScene("Lvl1");
        //Cursor.visible = false;
    }
}
