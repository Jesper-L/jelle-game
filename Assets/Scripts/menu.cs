using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public void playAgain()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
