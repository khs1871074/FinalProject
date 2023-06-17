using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : Movements
{
    [SerializeField]
    private bool isAttached = false;
    [SerializeField]
    private bool isClicked = false;
    [SerializeField]
    private int isType = 0;
    private Vector2Int[] movement;
    
    public StickyMateManager smManager;
    public bool isPlayer;

    private void Start()
    {
        Vector2Int nowpos =
            new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
        smManager.AddPiece(nowpos.x, nowpos.y, transform.gameObject);
    }

    void OnMouseDown()
    {
        if (!isClicked && !smManager.GetIsClicked())
        {
            isClicked = true;
            smManager.SetIsClicked(true);
            SetMovement(isType);
            GetMovableBoardPos();
        }
        else if (!isClicked && smManager.GetIsClicked())
        {
            
        }
        else
        {
            RemoveMovableBoardPos();
            isClicked = false;
            smManager.SetIsClicked(false);
        }
    }

    public void SetMovableBoardPos(int x, int y)
    {
        Vector2Int nowpos =
            new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
        
        transform.position = smManager.BoardToPosition(x, y);
        smManager.DestroyPiece(x, y);
        smManager.AddPiece(x, y, transform.gameObject);
        smManager.DeletePiece(nowpos.x, nowpos.y);
        RemoveMovableBoardPos();
        isClicked = false;
        smManager.SetIsClicked(false);
    }

    private void GetMovableBoardPos()
    {
        Vector2Int nowpos =
            new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
        if (isType == 1 || isType == 2 || isType == 4)
        {
            for (int i = 0; i < movement.Length; i++)
            {
                Vector2Int searchpos = nowpos;
                for (int j = 0; j < smManager.BOARD_SIZE; j++)
                {
                    searchpos += movement[i];
                    int x = searchpos.x;
                    int y = searchpos.y;
                    if (x > 4 || x < 0 || y > 4 || y < 0)
                    {
                        continue;
                    }
                    
                    if (!smManager.SearchPlayerPieceOnBoard(x, y))
                    {
                        GameObject mPoint = Instantiate(smManager.movablePoint, smManager.BoardToPosition(x, y),
                            Quaternion.identity);
                        mPoint.transform.parent = transform;
                    }

                    if (smManager.SearchEnemyPieceOnBoard(x, y) || smManager.SearchPlayerPieceOnBoard(x, y))
                    {
                        break;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < movement.Length; i++)
            {
                Vector2Int searchpos = nowpos + movement[i];
                int x = searchpos.x;
                int y = searchpos.y;
                if (x > 4 || x < 0 || y > 4 || y < 0)
                {
                    continue;
                }
                
                if (!smManager.SearchPlayerPieceOnBoard(x, y))
                {
                    GameObject mPoint = Instantiate(smManager.movablePoint, smManager.BoardToPosition(x, y),
                        Quaternion.identity);
                    mPoint.transform.parent = transform;
                }
            }
        }
    }

    private void RemoveMovableBoardPos()
    {
        if (isAttached)
        {
            for (int i = 2; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        else
        {
            for (int i = 1; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
    
    private void SetMovement(int type)
    {
        movement = GetMovement(type);
    }
    
    public void SetIsType(int type)
    {
        isType = type;
    }

    public void Attach()
    {
        isAttached = true;
    }

    public bool GetIsAttached()
    {
        return isAttached;
    }

}
