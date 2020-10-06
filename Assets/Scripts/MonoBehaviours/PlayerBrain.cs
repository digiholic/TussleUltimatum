using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The PlayerBrain is an implementation of IBrain that reads input for a player and generates Thoughts from them
/// </summary>
public class PlayerBrain : MonoBehaviour, IBrain
{
    public HashSet<Thought> thoughtsThisFrame;

    // Update is called once per frame
    void Update()
    {
        thoughtsThisFrame = new HashSet<Thought>();

        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        
        
    }


    public HashSet<Thought> Think()
    {
        return thoughtsThisFrame;
    }
}
