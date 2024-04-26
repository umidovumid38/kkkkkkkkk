using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levelcomplite : MonoBehaviour
{
    public Button[] buttonLevel;
    public static bool[] CourLevelcomplite = new bool[2];

    private void Start()
    {
        CourLevelcomplite[0] = true;
        for (int i = 0; i < CourLevelcomplite.Length; i++)
        {

            buttonLevel[i].interactable = CourLevelcomplite[i];
        }
    }
}
