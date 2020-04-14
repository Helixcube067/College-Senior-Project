using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Interaction : MonoBehaviour
{
    /* This class goes on the player and it requires a PlayerMovement script
     * Checks to see if the leftmouse button has been pressed and if it was casts a ray to that position and moves to that position
     * Also checks if the right mouse button is pressed and if so it makes the player attack the monster
     */
    PlayerMovement motor;
    Camera cam;
    public LayerMask movementMask;
    Monster monster;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMovement>();
    }

    void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100, movementMask))
                {
                    motor.MoveToPoint(hit.point);
                    UnsetMonster();
                }
            }
        
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.collider.tag == "Monster")
                    {
                        Monster monster = hit.collider.GetComponent<Monster>();
                        if (monster != null)
                        {
                        if (Vector3.Distance(this.gameObject.transform.position, hit.collider.gameObject.transform.position) <= 4.0f)
                            motor.AttackMonster(monster);
                        else
                            motor.MoveToPoint(hit.point * monster.radius);
                        }   
                    }
                }
            }
    }


    void UnsetMonster()
    {
        if (monster != null)
            monster = null;
        motor.StopFollowingTarget();
    }

    void SetMonster(Monster newMonster)
    {
        if (newMonster != monster)
        {
            if (monster != null)
                monster.OnDefocused();

            monster = newMonster;
            motor.AttackMonster(newMonster);
        }
        monster.OnFocused(transform);
    }
}
