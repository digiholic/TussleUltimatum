using KinematicCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class FighterCharacterController : MonoBehaviour, ICharacterController
{
    public int playerId = 0;

    public float gravity;
    public float jump;
    public float speed;

    public KinematicCharacterMotor Motor;
    public Animator animator;
    public Vector3 velocity;
    private IBrain brain;

    public InputPackage inputs;

    public AbstractFighterState CurrentState;

    private Dictionary<string, AbstractFighterState> states = new Dictionary<string, AbstractFighterState>();
    void Awake()
    {
        brain = GetComponent<IBrain>();
        animator = GetComponentInChildren<Animator>();

        states["Error"] = new ErrorFighterState(this);
        states["Idle"] = new IdleFighterState(this);
        states["Jump"] = new JumpFighterState(this);
    }

    void Start()
    {
        if (!TryGetComponent(out Motor))
        {
            Motor = gameObject.AddComponent<KinematicCharacterMotor>();
        }
        
        Motor.CharacterController = this;

        CurrentState = states["Idle"];
        CurrentState.OnStateEnter();
    }

    public void ChangeState(string newStateName)
    {
        CurrentState.OnStateExit();
        CurrentState = states.GetValueOrDefault(newStateName, states["Error"]);
        CurrentState.OnStateEnter();
    }

    public void BeforeCharacterUpdate(float deltaTime)
    {
        brain.Think(out inputs);
        CurrentState.BeforeCharacterUpdate(deltaTime);

        CurrentState.OnStateUpdate();
    }

    public void AfterCharacterUpdate(float deltaTime)
    {
        CurrentState.AfterCharacterUpdate(deltaTime);
    }

    public bool IsColliderValidForCollisions(Collider coll)
    {
        return true;
    }

    public void OnDiscreteCollisionDetected(Collider hitCollider)
    {
        
    }

    public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
        
    }

    public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
        
    }

    public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
    {
        
    }

    public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
    
    }

    public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        CurrentState.UpdateVelocity(ref currentVelocity, deltaTime);

        velocity.x = inputs.hAxis * speed;
        if (Motor.GroundingStatus.IsStableOnGround)
        {
            velocity.y = -0.1f;
        } else
        {
            velocity.y += gravity * -1 * deltaTime;
        }

        currentVelocity = velocity;
    }

    public void PostGroundingUpdate(float deltaTime)
    {
        // Handle landing and leaving ground
        if (Motor.GroundingStatus.IsStableOnGround && !Motor.LastGroundingStatus.IsStableOnGround)
        {
            OnLanded();
        }
        else if (!Motor.GroundingStatus.IsStableOnGround && Motor.LastGroundingStatus.IsStableOnGround)
        {
            OnLeaveStableGround();
        }
    }

    protected void OnLanded()
    {
        CurrentState.OnLanded();
    }

    protected void OnLeaveStableGround()
    {
        CurrentState.OnLeaveStableGround();
    }
}
