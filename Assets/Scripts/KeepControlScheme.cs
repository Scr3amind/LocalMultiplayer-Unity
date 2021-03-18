using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class KeepControlScheme : MonoBehaviour 
{
    private PlayerInput playerInput;
    private string lastScheme = null;
    private InputDevice[] lastDevices = null;

    private void Start() 
    {
        playerInput = GetComponent<PlayerInput>();
        lastScheme = playerInput.currentControlScheme;
        lastDevices = playerInput.devices.ToArray();
    }

    private void OnEnable() {
        if(lastScheme != null)
        {
            playerInput.SwitchCurrentControlScheme(lastScheme,lastDevices);
        }

    }


}