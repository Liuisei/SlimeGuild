using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MyButton 
{
    public int sceneIndexToLoad = 0; // The index of the scene to load when the button is released

    protected override void OnButtonUp()
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }
}