using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteKing : WhitePiece
{
    protected override void Awake()
    {
        base.Awake();
        PieceName = "whitek_king";
        this.name = PieceName;
        yBoard = 0;
        Mp.namePiece = PieceName;
    }

    protected override void InitiateMovePlates()
    {
        SurroundMovePlate();
    }

    public void SurroundMovePlate()
    {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 0);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard + 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 0);
        PointMovePlate(xBoard + 1, yBoard + 1);
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
