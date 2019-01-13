using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour {

    public void PlayButton()
    {
       
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        StartCoroutine(LoadYourAsyncScene());
    }
    public void QuitButton(){
        Debug.Log("QUIT!");
        Application.Quit();
    }
    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        // Wait until the asynchronous scene fully loads
        while (asyncLoad.progress <0.5f)
        {
            yield return null;
        }
    }

}
