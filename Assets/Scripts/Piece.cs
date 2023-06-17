using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : Movements
{
    [SerializeField]
    private bool isAttached = false;
    [SerializeField]
    private int isType = 0;
    private Vector2Int[] movement;

    public StickyMateManager smManager;
    public bool isPlayer;
    

    void OnMouseDown()
    {
        SetMovement(isType);
        GetMovableBoardPos();
    }

    private void SetMovableBoardPos()
    {
        
    }

    private void GetMovableBoardPos()
    {
        Vector2Int nowpos =
            new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
        if (isType == 1 || isType == 2 || isType == 4)
        {
            
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
                
                if (!smManager.SearchNowOnBoard(x, y))
                {
                    smManager.CreateMovablePoint(x, y);
                }
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
