using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenBag : MyButton
{
 
    protected override void OnButtonUp()
    {
        SceneManager.LoadScene(4);
    }
}
