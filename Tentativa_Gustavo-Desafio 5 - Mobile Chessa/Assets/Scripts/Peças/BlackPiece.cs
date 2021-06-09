using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPiece : Chessman
{
    public MovePlate Mp;
    protected virtual void Awake()
    {
        player = "black";
    }
}
