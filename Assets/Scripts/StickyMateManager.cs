using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PuzzleState
{
    Checkmate,
    AllCatch,
}

public class StickyMateManager : MonoBehaviour
{
    private SaveData saveData;
    private GameObject[,] board;
    private Vector3[,] boardPos;
    private int score;
    private int enemyCount = 0;
    private bool isClicked = false;
    private bool isEnd = false;
    
    [Header("보드크기")]
    public int BOARD_SIZE = 8;
    
    [Header("턴 수")]
    public int movableTurn;
    public TextMeshProUGUI turnText;
    
    [Header("제한 시간")]
    public float movableTime;
    public TextMeshProUGUI timeText;
    
    [Header("위치 포인트")]
    public GameObject movablePoint;
    
    [Header("퍼즐 종류")]
    public PuzzleState puzzleState;
    public Vector2Int checkmatePos;
    public int checkmatePieceType;
    public int stageNum;

    [Header("클리어 화면")] public GameObject clearPanel;
    [Header("실패 화면")] public GameObject failedPanel;
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

    private void Start()
    {
        saveData = GameObject.Find("SaveData").GetComponent<SaveData>();
        if ((int)puzzleState == 1)
        {
            SetTurnText();
        }
        else
        {
            turnText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!isEnd)
        {
            movableTime -= Time.deltaTime;
            UpdateUITime();
            if (movableTime < 0.0f)
            {
                FailedGame();
            }
        }
    }

    private void UpdateUITime()
    {
        int minutes = Mathf.FloorToInt(movableTime / 60f);
        int seconds = Mathf.FloorToInt(movableTime % 60f);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeText.text = timeString;
    }

    private void FailedGame()
    {
        if (!isEnd)
        {
            isEnd = true;
            failedPanel.SetActive(true);
        }
    }

    private void ClearGame()
    {
        if (!isEnd)
        {
            isEnd = true;
            saveData.StageClear(stageNum);
            clearPanel.SetActive(true);
        }
    }

    public void Checkmate(int x, int y, int type)
    {
        if (x == checkmatePos.x && y == checkmatePos.y && type == checkmatePieceType)
        {
            ClearGame();
        }
        else
        {
            FailedGame();
        }
    }

    public void UsedTurn()
    {
        movableTurn--;
        SetTurnText();
        if (movableTurn == 0)
        {
            FailedGame();
        }
    }

    private void SetTurnText()
    {
        turnText.text = "Turn : " + movableTurn;
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
                if (score == enemyCount)
                {
                    ClearGame();
                }
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

    public void EnemyCounting()
    {
        enemyCount++;
    }
}
