using UnityEngine;
using UnityEngine.InputSystem;

public class InpurManager : MonoBehaviour
{
    public static InpurManager instance {get; private set;}

    private void Awake() //wajib mun bikin static
    {
        instance = this;
    }
    public bool onClickRightMouse()
    {
        return Mouse.current.rightButton.wasPressedThisFrame;
    }

    public bool onRealeasedRightMouse()
    {
        return Mouse.current.rightButton.wasReleasedThisFrame;
    }

    public bool onClickLeftMouse()
    {
        return Mouse.current.leftButton.wasPressedThisFrame;
    }
    public bool onClickEkey()
    {
        return Keyboard.current.qKey.wasPressedThisFrame;
    }
}
