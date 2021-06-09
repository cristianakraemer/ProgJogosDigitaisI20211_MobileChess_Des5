using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitePawn : WhitePiece
{
    protected override void Awake()
    {
        base.Awake();
        PieceName = "white_pawn";
        this.name = PieceName;
        yBoard = 1;
        Mp.namePiece = PieceName;
    }

    protected override void InitiateMovePlates()
    {
        PawnMovePlate(xBoard, yBoard + 1);
    }

    public void PawnMovePlate(int x, int y)
    {
        GameController sc = controller.GetComponent<GameController>();
        if (sc.PositionOnBoard(x, y))
        {
            if (sc.GetPosition(x, y) == null)
            {
                MovePlateSpawn(x, y);
            }

            if (sc.PositionOnBoard(x + 1, y) && sc.GetPosition(x + 1, y) != null &&
                sc.GetPosition(x + 1, y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x + 1, y);
            }
            if (sc.PositionOnBoard(x - 1, y) && sc.GetPosition(x - 1, y) != null &&
                sc.GetPosition(x - 1, y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x - 1, y);
            }
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
