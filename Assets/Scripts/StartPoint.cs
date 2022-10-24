using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string uuid; // uuid = universal unique identifier
    
    [SerializeField] private Vector2 facingDirection;
    private PlayerController player;
    
    private void Start(){
        player = FindObjectOfType<PlayerController>();
        if (!player.nextUuid.Equals(uuid))
        {
            return;
        }
        player.transform.position = transform.position;
        player.lastDirection = facingDirection;

        GameObject confiner = GameObject.Find("Camera Confiner");
        if (confiner != null)
        {
            FindObjectOfType<CinemachineConfiner2D>().
                m_BoundingShape2D = confiner.GetComponent<PolygonCollider2D>();
        }
    }
}

