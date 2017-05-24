using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerMoveJoystick playerMove;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Left")
        {
            playerMove.SetMoveDirection(true);
        }
        else
        {
            playerMove.SetMoveDirection(false);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerMove.StopMoving();
    }

    void Start()
    {
        playerMove = GameObject.Find("PlayerChar").GetComponent<PlayerMoveJoystick>();
    }
}