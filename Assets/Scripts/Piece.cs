using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : Movements
{
    private bool isAttached;
    private int isType = 0;
    private Vector2Int[] movement;
    
    public bool isPlayer;

    void OnMouseDown()
    {
        
    }

    private void SetBoardPos()
    {
        
    }

    private void GetBoardPos()
    {
        
    }
    
    private void SetMovement(int type)
    {
        movement = GetMovement(type);
    }
    
    public void SetIsType(int type)
    {
        isType = type;
    }

    public void IsAttached()
    {
        
    }

}
