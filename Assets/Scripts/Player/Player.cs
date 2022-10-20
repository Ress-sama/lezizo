using System;
using System.Collections.Generic;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Abilities.Move;
using StellarConquest.Presentation.Unity;
using UnityEditor.Animations;
using UnityEngine;
using AnimationState = Assets.Scripts.Player.AnimationState;

public class Player : MonoBehaviour
{
    [SerializeReference, SubclassSelector] private IJump jumpAbility;
    [SerializeReference, SubclassSelector] private IMove moveAbility;

    private InputSystem inputSystem;
    private Rigidbody2D rigidbody2D;
    private Animator animator;

    private void Awake()
    {
        inputSystem = new InputSystem();
        inputSystem.Player.Enable();
        inputSystem.Player.Jump.started += _ => jumpAbility.Jump();
        inputSystem.Player.Movement.started +=
            _ => rigidbody2D.transform.rotation =
                Quaternion.Euler(0, inputSystem.Player.Movement.ReadValue<float>() == -1 ? 180 : 0, 0);


        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

        jumpAbility.Init();
        moveAbility.Init(rigidbody2D, animator);
    }

    void Update()
    {
        moveAbility.Move(inputSystem.Player.Movement.ReadValue<float>());
    }

    public void ChangeJumpAbility(IJump jump)
    {
        jumpAbility = jump;
        jumpAbility.Init();
    }
}