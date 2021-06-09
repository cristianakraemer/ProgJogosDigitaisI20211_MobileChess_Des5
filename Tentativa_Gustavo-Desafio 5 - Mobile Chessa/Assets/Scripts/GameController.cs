using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Referência do Unity IDE
    public GameObject chesspiece;
    public GameObject Black_Paw;
    public GameObject Black_Bishop;
    public GameObject Black_Knight;
    public GameObject Black_King;
    public GameObject Black_Queen;
    public GameObject Black_Rook;
    public GameObject White_Paw;
    public GameObject White_Bishop;
    public GameObject White_Knight;
    public GameObject White_King;
    public GameObject White_Queen;
    public GameObject White_Rook;


    //Cria a matriz. Posições e equipe de cada peça de xadrez
    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];

    //De quem é a vez
    private string currentPlayer = "white";

    //Fim de jogo
    private bool gameOver = false;

    void Start()
    {
        playerWhite = new GameObject[]
        {
            CreateWtR(0), CreateWtKnt(1),
            CreateWtB(2), CreateWtQ(3), CreateWtKing(4),
            CreateWtB(5), CreateWtKnt(6), CreateWtR(7),
            CreateWtP(0), CreateWtP(1), CreateWtP(2),
            CreateWtP(3), CreateWtP(4), CreateWtP(5),
            CreateWtP(6), CreateWtP(7) };

        playerBlack = new GameObject[] 
        {   CreateBkR(0), CreateBkKnt(1),
            CreateBkB(2), CreateBkQ(3), CreateBkKing(4),
            CreateBkB(5), CreateBkKnt(6), CreateBkR(7),
            CreateBkP(0), CreateBkP(1), CreateBkP(2),
            CreateBkP(3), CreateBkP(4), CreateBkP(5),
            CreateBkP(6), CreateBkP(7) };

        //Define a posição de todas as peças no quadro
        for (int i = 0; i < playerWhite.Length; i++)
        {
            if (i == 0)
            {
                WhiteRook BkR = playerWhite[i].GetComponent<WhiteRook>();

                //Sobrescreve o espaço vazio ou o que quer que esteja lá
                positions[BkR.GetXBoard(), BkR.GetYBoard()] = playerWhite[i];

            }
            else if (i == 1)
            {
                WhiteKnight BkKnt = playerWhite[i].GetComponent<WhiteKnight>();

                //Sobrescreve o espaço vazio ou o que quer que esteja lá
                positions[BkKnt.GetXBoard(), BkKnt.GetYBoard()] = playerWhite[i];
            }
            else if (i == 2)
            {
                WhiteBishop BkB = playerWhite[i].GetComponent<WhiteBishop>();

                //Sobrescreve o espaço vazio ou o que quer que esteja lá
                positions[BkB.GetXBoard(), BkB.GetYBoard()] = playerWhite[i];
            }
            else if (i == 3)
            {
                WhiteQueen BkQ = playerWhite[i].GetComponent<WhiteQueen>();

                //Sobrescreve o espaço vazio ou o que quer que esteja lá
                positions[BkQ.GetXBoard(), BkQ.GetYBoard()] = playerWhite[i];

            }
            else if (i == 4)
            {
                WhiteKing BkKing = playerWhite[i].GetComponent<WhiteKing>();

                //Sobrescreve o espaço vazio ou o que quer que esteja lá
                positions[BkKing.GetXBoard(), BkKing.GetYBoard()] = playerWhite[i];
            }
            else if (i == 5)
            {
                WhiteKnight BkKnt = playerWhite[i].GetComponent<WhiteKnight>();

                //Sobrescreve o espaço vazio ou o que quer que esteja lá
                positions[BkKnt.GetXBoard(), BkKnt.GetYBoard()] = playerWhite[i];
            }
            else if (i == 6)
            {
                WhiteBishop BkB = playerWhite[i].GetComponent<WhiteBishop>();

                //Sobrescreve o espaço vazio ou o que quer que esteja lá
                positions[BkB.GetXBoard(), BkB.GetYBoard()] = playerWhite[i];
            }
            else if (i == 7)
            {

                WhiteRook BkR = playerWhite[i].GetComponent<WhiteRook>();

                //Sobrescreve o espaço vazio ou o que quer que esteja lá
                positions[BkR.GetXBoard(), BkR.GetYBoard()] = playerWhite[i];

            }
            else if (i >= 8)
            {
                SetPositionWtP(playerWhite[i]);
            }
        }
        for (int i = 0; i < playerBlack.Length; i++)
        {
            if (i == 0)
            {
                BlackRook BkR = playerBlack[i].GetComponent<BlackRook>();

                //Sobrescreve o espaço vazio ou o que quer que esteja lá
                positions[BkR.GetXBoard(), BkR.GetYBoard()] = playerBlack[i];

            }
            else if (i == 1)
            {
                BlackKnight BkKnt = playerBlack[i].GetComponent<BlackKnight>();

                //Sobrescreve o espaço vazio ou o que quer que esteja lá
                positions[BkKnt.GetXBoard(), BkKnt.GetYBoard()] = playerBlack[i];
            }
            else if (i == 2)
            {
                BlackBishop BkB = playerBlack[i].GetComponent<BlackBishop>();

                //Sobrescreve o espaço vazio ou o que quer que esteja lá
                positions[BkB.GetXBoard(), BkB.GetYBoard()] = playerBlack[i];
            }
            else if (i == 3)
            {
                BlackQueen BkQ = playerBlack[i].GetComponent<BlackQueen>();

                //Sobrescreve o espaço vazio ou o que quer que esteja lá
                positions[BkQ.GetXBoard(), BkQ.GetYBoard()] = playerBlack[i];

            }
            else if (i == 4)
            {
                BlackKing BkKing = playerBlack[i].GetComponent<BlackKing>();

                //Sobrescreve o espaço vazio ou o que quer que esteja lá
                positions[BkKing.GetXBoard(), BkKing.GetYBoard()] = playerBlack[i];
            }
            else if (i == 5)
            {
                BlackKnight BkKnt = playerBlack[i].GetComponent<BlackKnight>();

                //Sobrescreve o espaço vazio ou o que quer que esteja lá
                positions[BkKnt.GetXBoard(), BkKnt.GetYBoard()] = playerBlack[i];
            }
            else if (i == 6)
            {
                BlackBishop BkB = playerBlack[i].GetComponent<BlackBishop>();

                //Sobrescreve o espaço vazio ou o que quer que esteja lá
                positions[BkB.GetXBoard(), BkB.GetYBoard()] = playerBlack[i];
            }
            else if (i == 7)
            {

                BlackRook BkR = playerBlack[i].GetComponent<BlackRook>();

                //Sobrescreve o espaço vazio ou o que quer que esteja lá
                positions[BkR.GetXBoard(), BkR.GetYBoard()] = playerBlack[i];

            }
            else if (i >= 8)
            {
                SetPositionBkP(playerBlack[i]);
            }
        }
    }
    
    /*public GameObject Create(string name, int x, int y) //Cria as peças nos lugares especificados acima e instancia
    {
        GameObject obj = Instantiate(Black_Paw, new Vector3(0, 0, -1), Quaternion.identity);
        Chessman cm = obj.GetComponent<BlackPawn>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }*/

    public GameObject CreateBkP(int x) //Cria as peças nos lugares especificados acima e instancia
    {
        GameObject obj = Instantiate(Black_Paw, new Vector3(0, 0, -1), Quaternion.identity);

        BlackPawn BkP = obj.GetComponent<BlackPawn>();
    
        BkP.SetXBoard(x);
        BkP.Activate();

        return obj;
    }
    public GameObject CreateBkB(int x) //Cria as peças nos lugares especificados acima e instancia
    {
        GameObject obj1 = Instantiate(Black_Bishop, new Vector3(0, 0, -1), Quaternion.identity);

        BlackBishop BkB = obj1.GetComponent<BlackBishop>();

        BkB.SetXBoard(x);
        BkB.Activate();

        return obj1;
    }
    public GameObject CreateBkKing(int x) //Cria as peças nos lugares especificados acima e instancia
    {
        GameObject obj2 = Instantiate(Black_King, new Vector3(0, 0, -1), Quaternion.identity);

        BlackKing BkKing = obj2.GetComponent<BlackKing>();

        BkKing.SetXBoard(x);
        BkKing.Activate();

        return obj2;
    }
    public GameObject CreateBkKnt(int x) //Cria as peças nos lugares especificados acima e instancia
    {
        GameObject obj2 = Instantiate(Black_Knight, new Vector3(0, 0, -1), Quaternion.identity);

        BlackKnight BkKnt = obj2.GetComponent<BlackKnight>();

        BkKnt.SetXBoard(x);
        BkKnt.Activate();

        return obj2;
    }
    public GameObject CreateBkQ(int x) //Cria as peças nos lugares especificados acima e instancia
    {
        GameObject obj2 = Instantiate(Black_Queen, new Vector3(0, 0, -1), Quaternion.identity);

        BlackQueen BkQ = obj2.GetComponent<BlackQueen>();

        BkQ.SetXBoard(x);
        BkQ.Activate();

        return obj2;
    }
    public GameObject CreateBkR(int x) //Cria as peças nos lugares especificados acima e instancia
    {
        GameObject obj2 = Instantiate(Black_Rook, new Vector3(0, 0, -1), Quaternion.identity);

        BlackRook BkKnt = obj2.GetComponent<BlackRook>();

        BkKnt.SetXBoard(x);
        BkKnt.Activate();

        return obj2;
    }

    public GameObject CreateWtP(int x) //Cria as peças nos lugares especificados acima e instancia
    {
        GameObject obj = Instantiate(White_Paw, new Vector3(0, 0, -1), Quaternion.identity);

        WhitePawn WtP = obj.GetComponent<WhitePawn>();

        WtP.SetXBoard(x);
        WtP.Activate();

        return obj;
    }
    public GameObject CreateWtB(int x) //Cria as peças nos lugares especificados acima e instancia
    {
        GameObject obj1 = Instantiate(White_Bishop, new Vector3(0, 0, -1), Quaternion.identity);

        WhiteBishop WtB = obj1.GetComponent<WhiteBishop>();

        WtB.SetXBoard(x);
        WtB.Activate();

        return obj1;
    }
    public GameObject CreateWtKing(int x) //Cria as peças nos lugares especificados acima e instancia
    {
        GameObject obj2 = Instantiate(White_King, new Vector3(0, 0, -1), Quaternion.identity);

        WhiteKing WtKing = obj2.GetComponent<WhiteKing>();

        WtKing.SetXBoard(x);
        WtKing.Activate();

        return obj2;
    }
    public GameObject CreateWtKnt(int x) //Cria as peças nos lugares especificados acima e instancia
    {
        GameObject obj2 = Instantiate(White_Knight, new Vector3(0, 0, -1), Quaternion.identity);

        WhiteKnight WtKnt = obj2.GetComponent<WhiteKnight>();

        WtKnt.SetXBoard(x);
        WtKnt.Activate();

        return obj2;
    }
    public GameObject CreateWtQ(int x) //Cria as peças nos lugares especificados acima e instancia
    {
        GameObject obj2 = Instantiate(White_Queen, new Vector3(0, 0, -1), Quaternion.identity);

        WhiteQueen WtQ = obj2.GetComponent<WhiteQueen>();

        WtQ.SetXBoard(x);
        WtQ.Activate();

        return obj2;
    }
    public GameObject CreateWtR(int x) //Cria as peças nos lugares especificados acima e instancia
    {
        GameObject obj2 = Instantiate(Black_Rook, new Vector3(0, 0, -1), Quaternion.identity);

        WhiteRook WtKnt = obj2.GetComponent<WhiteRook>();

        WtKnt.SetXBoard(x);
        WtKnt.Activate();

        return obj2;
    }

    public void SetPositionBkP(GameObject obj) //Pega a posição de cada peça
    {
        BlackPawn BkP = obj.GetComponent<BlackPawn>();

        //Sobrescreve o espaço vazio ou o que quer que esteja lá
        positions[BkP.GetXBoard(), BkP.GetYBoard()] = obj;
    }

    public void SetPositionWtP(GameObject obj) //Pega a posição de cada peça
    {
        WhitePawn WtP = obj.GetComponent<WhitePawn>();

        //Sobrescreve o espaço vazio ou o que quer que esteja lá
        positions[WtP.GetXBoard(), WtP.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y)
    {
        //Define a posição nula
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }

    public string GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void NextTurn()
    {
        if (currentPlayer == "white")
        {
            currentPlayer = "black";
        }
        else
        {
            currentPlayer = "white";
        }
    }

    private void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            gameOver = false;

            //Usar o UnityEngine.SceneManagement - Reinicia o jogo carregando a cena novamente
            SceneManager.LoadScene("MobileChess");
        }
    }

    public void Winner(string playerWinner)
    {
        gameOver = true;

        //Aqui é necessário o UnityEngine.UI (Interface)
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().enabled = true;
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().text = playerWinner + " is the winner";

        GameObject.FindGameObjectWithTag("RestartText").GetComponent<Text>().enabled = true;
    }
}
