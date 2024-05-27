using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public bool allowMove;

    private void Start()
    {
        allowMove = false;
    }

}
