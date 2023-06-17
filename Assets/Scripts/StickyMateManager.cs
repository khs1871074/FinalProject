using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyMateManager : MonoBehaviour
{
    private GameObject[,] board;
    private Vector3[,] boardPos;
    private int score;
    private bool isClicked;
    
    public int BOARD_SIZE = 5;

    public GameObject[] playerPieces;
    public GameObject[] enemyPieces;
    public GameObject movablePoint;
    private void Awake()
    {
        board = new GameObject[BOARD_SIZE, BOARD_SIZE];
        boardPos = new Vector3[BOARD_SIZE, BOARD_SIZE];

        for (int i = 0; i < BOARD_SIZE; i++)
        {
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                boardPos[i, j] = new Vector3((float)i, 0.0f, (float)j);
            }
        }
    }
    
    public void AddPiece(int x, int y, GameObject nowpiece)
    {
        board[x, y] = nowpiece;
    }
    
    public void DeletePiece(int x, int y)
    {
        board[x, y] = null;
    }
    
    public void DestroyPiece(int x, int y)
    {
        if (board[x, y] != null)
        {
            if (!board[x, y].gameObject.GetComponent<Piece>().isPlayer)
            {
                Destroy(board[x, y].transform.gameObject);
                board[x, y] = null;
                score++;
            }
        }
    }

    public bool SearchPlayerPieceOnBoard(int x, int y)
    {
        if (board[x, y] != null)
        {
            if (board[x, y].gameObject.GetComponent<Piece>().isPlayer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    
    public bool SearchEnemyPieceOnBoard(int x, int y)
    {
        if (board[x, y] != null)
        {
            if (!board[x, y].gameObject.GetComponent<Piece>().isPlayer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public Vector3 BoardToPosition(int x, int y)
    {
        return boardPos[x, y];
    }

    public bool GetIsClicked()
    {
        return isClicked;
    }

    public void SetIsClicked(bool click)
    {
        isClicked = click;
    }
}
