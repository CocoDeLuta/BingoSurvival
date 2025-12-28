using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Microsoft.VisualBasic;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMovement playerMovement;
    private PlayerLook playerLook;

    public InteractionDetector interactionDetector;
    public Weapon weapon;
    public bool IsFiring { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        playerMovement = GetComponent<PlayerMovement>();
        playerLook = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx => playerMovement.Jump();
        onFoot.Interact.started += ctx => interactionDetector.TryInteract();

        onFoot.Fire.started += ctx => IsFiring = true;
        onFoot.Fire.canceled += ctx => IsFiring = false;

        onFoot.Reload.started += ctx => weapon.TryReload();

        onFoot.Sprint.started += ctx => playerMovement.IsSprinting = true;
        onFoot.Sprint.canceled += ctx => playerMovement.IsSprinting = false;
    }

    private void FixedUpdate()
    {
        playerMovement.ProcessMove(onFoot.Move.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        playerLook.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
