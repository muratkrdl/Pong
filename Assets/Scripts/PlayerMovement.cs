using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float moveRange;

    [SerializeField] bool isLeftPlayer;

    bool isPressW => Input.GetKey(KeyCode.W);
    bool isPressS => Input.GetKey(KeyCode.S);

    bool isPressUpArrow => Input.GetKey(KeyCode.UpArrow);
    bool isPressDownArrow=> Input.GetKey(KeyCode.DownArrow);

    Vector2 newPos;

    void Update() 
    {
        Move();
    }

    void Move()
    {
        if(isLeftPlayer)
        {
            newPos = transform.position;

            if(isPressW)
            {
                newPos.y += Vector2.up.y * moveSpeed * Time.deltaTime;
                newPos.y = Mathf.Clamp(newPos.y, -moveRange, moveRange);

                transform.position = newPos;
            }
            else if(isPressS)
            {
                newPos.y += Vector2.down.y * moveSpeed * Time.deltaTime;
                newPos.y = Mathf.Clamp(newPos.y, -moveRange, moveRange);

                transform.position = newPos;
            }
        }
        else if(!isLeftPlayer)
        {
            newPos = transform.position;

            if(isPressUpArrow)
            {
                newPos.y += Vector2.up.y * moveSpeed * Time.deltaTime;
                newPos.y = Mathf.Clamp(newPos.y, -moveRange, moveRange);

                transform.position = newPos;
            }
            else if(isPressDownArrow)
            {
                newPos.y += Vector2.down.y * moveSpeed * Time.deltaTime;
                newPos.y = Mathf.Clamp(newPos.y, -moveRange, moveRange);

                transform.position = newPos;
            }
        }
    }

}
