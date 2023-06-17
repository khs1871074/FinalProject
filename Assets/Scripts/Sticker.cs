using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IsType
{
    Pawn,
    Rook,
    Bishop,
    Knight,
    Queen,
    King,
}

public class Sticker : MonoBehaviour
{
    [SerializeField]
    private bool isAttach;
    private Vector3 basePos;
    
    private bool isHit;
    private string HitTag;
    private GameObject scanObject;
    
    public RaycastHit hit;
    public float RayMaxDistance = 4.00f;
    public IsType isType;

    private void Start()
    {
        basePos.x = transform.position.x;
        basePos.y = transform.position.y;
        basePos.z = transform.position.z;
    }

    private void OnMouseDrag()
    {
        if (!isAttach)
        {
            float distance = Camera.main.WorldToScreenPoint(transform.position).z;

            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = objPos;

            isHit = Physics.Raycast(transform.position, transform.forward, out hit, RayMaxDistance);
            if (isHit) //히트가 되면
            {
                var o = hit.collider.gameObject;
                scanObject = o;
                HitTag = o.tag;
            }
            else
            {
                scanObject = null;
                HitTag = null;
            }
        }
    }

    private void OnMouseUp()
    {
        if (HitTag == "Piece")
        {
            Piece piece = scanObject.GetComponent<Piece>();
            if (!piece.GetIsAttached() && piece.isPlayer)
            {
                isAttach = true;
                transform.position = scanObject.transform.GetChild(0).position;
                transform.parent = scanObject.transform;

                Vector3 scale = new Vector3(0.05f, 0.05f, 0.05f);
                transform.localScale = scale;
                
                piece.SetIsType((int)isType);
                piece.Attach();

                BoxCollider bc = GetComponent<BoxCollider>();
                bc.enabled = false;
            }
            else
            {
                isAttach = false;
                transform.position = basePos;  
            }
        }
        else
        {
            isAttach = false;
            transform.position = basePos;    
        }
    }
    
}
