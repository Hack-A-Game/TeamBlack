using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{

    public void onClick()
    {
        Controller.controller.desactiveGamePaused();
        Debug.Log("holaa");
    }
}
