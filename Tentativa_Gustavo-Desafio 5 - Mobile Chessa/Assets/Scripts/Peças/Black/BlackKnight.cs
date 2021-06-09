using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKnight : BlackPiece
{
    protected override void Awake()
    {
        base.Awake();
        PieceName = "black_knight";
        this.name = PieceName;
        yBoard = 7;
    }

    protected override void InitiateMovePlates()
    {
        LMovePlate();
    }

    public void LMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard - 1);
    }

    protected override void OnMouseUp()
    {
        if (!controller.GetComponent<GameController>().IsGameOver() &&
            controller.GetComponent<GameController>().GetCurrentPlayer() == player)
        {
            //Remove todos os MovePlates relacionados à peça previamente selecionada
            DestroyMovePlates();

            //Cria novos MovePlates
            InitiateMovePlates();
        }
    }

    public void Activate()
    {
        //Obter o controlador de jogo (GameController)
        controller = GameObject.FindGameObjectWithTag("GameController");

        //Para pegar a localização instanciada e ajustar a transformação/transform
        SetCoords();

        this.GetComponent<SpriteRenderer>().sprite = pieceSprite;
    }

}
