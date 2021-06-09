using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitePiece : Chessman
{
    public MovePlate Mp;
    protected virtual void Awake()
    {
        player = "white";
    }
}
