using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackQueen : BlackPiece
{
    protected override void Awake()
    {
        base.Awake();
        PieceName = "black_queen";
        this.name = PieceName;
        yBoard = 7;
        Mp.namePiece = PieceName;
    }

    protected override void InitiateMovePlates()
    {
        LineMovePlate(1, 0);
        LineMovePlate(0, 1);
        LineMovePlate(1, 1);
        LineMovePlate(-1, 0);
        LineMovePlate(0, -1);
        LineMovePlate(-1, -1);
        LineMovePlate(-1, 1);
        LineMovePlate(1, -1);
    }
    public void LineMovePlate(int xIncrement, int yIncrement)
    {
        GameController sc = controller.GetComponent<GameController>();
        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;

        while (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y) == null)
        {
            MovePlateSpawn(x, y);
            x += xIncrement;
            y += yIncrement;
        }

        if (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y).GetComponent<Chessman>().player != player)
        {
            MovePlateAttackSpawn(x, y);
        }
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
