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

    
    private float hAxis;
    private bool jumpPressed;
    private KinematicCharacterMotor Motor;
    private Vector3 velocity;
    private IBrain brain;

    private HashSet<Thought> thoughtsThisFrame;

    void Awake()
    {
        brain = GetComponent<IBrain>();
    }
    void Start()
    {
        if (!TryGetComponent(out Motor))
        {
            Motor = gameObject.AddComponent<KinematicCharacterMotor>();
        }
        
        Motor.CharacterController = this;
    }

    void Update()
    {
        
    }

    public void BeforeCharacterUpdate(float deltaTime)
    {
        thoughtsThisFrame = brain.Think();
    }

    public void AfterCharacterUpdate(float deltaTime)
    {
        brain.ClearThoughts();
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
        velocity.x = hAxis * speed;
        if (Motor.GroundingStatus.IsStableOnGround)
        {
            velocity.y = -0.1f;
        } else
        {
            velocity.y += gravity * -1 * deltaTime;
        }

        if (jumpPressed)
        {
            velocity.y = jump;
            jumpPressed = false;
            Motor.ForceUnground();
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
        Debug.Log("Landed");
    }

    protected void OnLeaveStableGround()
    {
        Debug.Log("Left ground");
    }
}
