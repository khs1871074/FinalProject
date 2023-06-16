using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movements : MonoBehaviour
{
    private Vector2Int[] pawnMovement = new Vector2Int[]
    {
        new Vector2Int(0, 1),
    };
    
    private Vector2Int[] rookMovement = new Vector2Int[]
    {
        Vector2Int.left, 
        Vector2Int.up, 
        Vector2Int.right, 
        Vector2Int.down,
    };

    private Vector2Int[] bishopMovement = new Vector2Int[]
    {
        new Vector2Int(1, 1),
        new Vector2Int(1, -1),
        new Vector2Int(-1, 1),
        new Vector2Int(-1,- 1),
    };

    private Vector2Int[] knightMovement = new Vector2Int[]
    {
        new Vector2Int(2, 1),
        new Vector2Int(2, -1),
        new Vector2Int(1, 2),
        new Vector2Int(1, -2),
        new Vector2Int(-2, 1),
        new Vector2Int(-2, -1),
        new Vector2Int(-1, 2),
        new Vector2Int(-1, -2),
    };
    
    private Vector2Int[] queenMovement = new Vector2Int[]
    {
        Vector2Int.left,
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        new Vector2Int(1, 1),
        new Vector2Int(1, -1),
        new Vector2Int(-1, 1),
        new Vector2Int(-1,- 1),
    };
    
    private Vector2Int[] kingMovement = new Vector2Int[]
    {
        new Vector2Int(-1, 1),
        new Vector2Int(0, 1),
        new Vector2Int(1, 1),
        new Vector2Int(-1, 0),
        new Vector2Int(1, 0),
        new Vector2Int(-1, -1),
        new Vector2Int(0, -1),
        new Vector2Int(1, -1),
    };


    public Vector2Int[] GetMovement(int type)
    {
        switch (type)
        {
            case 0:
                return pawnMovement;
            case 1:
                return rookMovement;
            case 2:
                return bishopMovement;
            case 3:
                return knightMovement;
            case 4:
                return queenMovement;
            case 5:
                return kingMovement;
            default:
                return pawnMovement;
        }
    }
}