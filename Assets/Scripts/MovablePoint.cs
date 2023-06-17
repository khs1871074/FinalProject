using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePoint : MonoBehaviour
{
    private Piece piece;
    // Start is called before the first frame update
    void Start()
    {
        piece = transform.parent.gameObject.GetComponent<Piece>();
    }

    private void OnMouseDown()
    {
        Vector2Int nowpos =
            new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
        piece.SetMovableBoardPos(nowpos.x, nowpos.y);
    }
}
