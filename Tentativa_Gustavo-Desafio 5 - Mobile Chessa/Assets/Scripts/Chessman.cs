using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{
    public string PieceName { get; protected set; }
    public Sprite pieceSprite;

    //Posições das peças no tabuleiro
    public int xBoard { get; protected set; } = -1;
    public int yBoard { get; protected set; } = -1;


    //Referências aos objetos na cena
    public GameObject controller;
    public GameObject movePlate;


    //Variável para rastrear o jogador ao qual pertence: "preto" ou "branco"
    public string player { get; protected set; }

    public void SetCoords()
    {
        //Obtem valor do tabuleiro e converte para coordenadas x y
        float x = xBoard;
        float y = yBoard;

        //Ajusta deslocamento variável
        x *= 0.66f;
        y *= 0.66f;

        //Adiciona constantes (pos 0, 0)
        x += -2.3f;
        y += -2.3f;

        //Define os valores reais da unidade
        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    protected virtual void OnMouseUp()
    {
    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]); //Função de destruir assíncrona
        }
    }

    protected virtual void InitiateMovePlates()
    {
        switch (this.name)
        {
            /*case "black_queen":
            case "white_queen":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(1, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                LineMovePlate(-1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(1, -1);
                break;
            //case "black_knight":
            case "white_knight":
                LMovePlate();
                break;
            //case "black_bishop":
            case "white_bishop":
                LineMovePlate(1, 1);
                LineMovePlate(1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(-1, -1);
                break;
            //case "black_king":
            case "white_king":
                SurroundMovePlate();
                break;
            //case "black_rook":
            case "white_rook":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                break;
            case "black_pawn":
                //PawnMovePlate(xBoard, yBoard - 1);
                break;
            case "white_pawn":
                //PawnMovePlate(xBoard, yBoard + 1);
                break;*/
        }
    }

    /*public void LineMovePlate(int xIncrement, int yIncrement)
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

        if(sc.PositionOnBoard(x,y) && sc.GetPosition(x,y).GetComponent<Chessman>().player != player)
        {
            MovePlateAttackSpawn(x, y);
        }
    }*/

    /*public void LMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard - 1);
    }*/

    /*public void SurroundMovePlate()
    {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 0);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard + 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 0);
        PointMovePlate(xBoard + 1, yBoard + 1);
    }*/

    public void PointMovePlate(int x, int y)
    {
        GameController sc = controller.GetComponent<GameController>();
        if (sc.PositionOnBoard(x,y))
        {
            GameObject cp = sc.GetPosition(x, y);
            if (cp == null)
            {
                MovePlateSpawn(x, y);
            }
            else if (cp.GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }

    /*public void PawnMovePlate(int x, int y)
    {
        GameController sc = controller.GetComponent<GameController>();
        if (sc.PositionOnBoard(x, y))
        {
            if (sc.GetPosition(x,y) == null)
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
    }*/

    public void MovePlateSpawn(int matrixX, int matrixY)
    {
        //Obtem valor do tabuleiro e converte para coordenadas x y
        float x = matrixX;
        float y = matrixY;

        //Ajusta deslocamento variável
        x *= 0.66f;
        y *= 0.66f;

        //Adiciona constantes (pos 0, 0)
        x += -2.3f;
        y += -2.3f;

        //Define os valores reais da unidade
        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);
        
        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);
        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

}
