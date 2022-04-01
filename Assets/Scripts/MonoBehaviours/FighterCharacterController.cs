using KinematicCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterCharacterController : MonoBehaviour, ICharacterController
{
    public int playerId = 0;

    public float gravity;
    public float jump;
    public float speed;

    public InputPackage inputs;

    private KinematicCharacterMotor Motor;
    private FighterState CurrentState;
    private Animator animator;
    
    private IBrain brain;

    public Vector3 velocity;
    public Vector3 targetVelocity;

    public FighterInfo info;
    private Dictionary<string, FighterState> states = new Dictionary<string, FighterState>();

    void Awake()
    {
        brain = GetComponent<IBrain>();
        animator = GetComponentInChildren<Animator>();
        foreach(FighterState state in info.states)
        {
            states[state.name] = state;
        }
    }

    void Start()
    {
        if (!TryGetComponent(out Motor))
        {
            Motor = gameObject.AddComponent<KinematicCharacterMotor>();
        }
        
        Motor.CharacterController = this;

        CurrentState = states["Idle"];
        CurrentState.OnStateEnter(this);
    }

    public void ChangeState(string newStateName)
    {
        CurrentState.OnStateExit();
        CurrentState = states.GetValueOrDefault(newStateName, states["Error"]);
        CurrentState.OnStateEnter(this);
    }

    public void PlayAnimation(string animationName) => animator.Play(animationName);
    public void ForceUnground() => Motor.ForceUnground();
    public void ReceiveAnimatorMessage(string message)=> CurrentState.ReceiveAnimatorMessage(message);
    

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

    public void OnDiscreteCollisionDetected(Collider hitCollider) { }
    public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport) { }
    public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport) { }
    public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport) { }
    public void UpdateRotation(ref Quaternion currentRotation, float deltaTime) { }

    public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        CurrentState.UpdateVelocity(ref currentVelocity, deltaTime);

        if (Motor.GroundingStatus.IsStableOnGround)
        {
            velocity.y = -0.1f;
        } else
        {
            velocity.y += gravity * -1 * deltaTime;
        }

        animator.SetFloat("hSpeed", velocity.x);
        animator.SetFloat("vSpeed", velocity.y);
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
        animator.SetBool("grounded", true);
        CurrentState.OnLanded();
    }

    protected void OnLeaveStableGround()
    {
        animator.SetBool("grounded", false);
        CurrentState.OnLeaveStableGround();
    }
}
