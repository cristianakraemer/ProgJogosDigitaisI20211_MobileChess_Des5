using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;
    GameObject reference = null;

    public string namePiece;

    int matrixX;
    int matrixY;

    public bool attack = false;

    public void Start()
    {
        if(attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //Mudar para vermelho
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        if(attack)
        {
            GameObject cp = controller.GetComponent<GameController>().GetPosition(matrixX, matrixY);
            if (cp.name == "white_king") controller.GetComponent<GameController>().Winner("black");
            if (cp.name == "black_king") controller.GetComponent<GameController>().Winner("white");
            Destroy(cp);
        }

        controller.GetComponent<GameController>().SetPositionEmpty(reference.GetComponent<ScriptableObject>().GetXBoard(), 
            reference.GetComponent<Chessman>().GetYBoard());

        //Move a peça de referência para esta posição
        reference.GetComponent<Chessman>().SetXBoard(matrixX);
        reference.GetComponent<Chessman>().SetYBoard(matrixY);
        reference.GetComponent<Chessman>().SetCoords();

        //Atualiza a matriz
        controller.GetComponent<GameController>().SetPosition(reference);

        //Alterna jogador atual
        controller.GetComponent<GameController>().NextTurn();

        //Destrói as MovePlates (placas de movimento), incluindo a si mesmo
        reference.GetComponent<Chessman>().DestroyMovePlates();
    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }
}
