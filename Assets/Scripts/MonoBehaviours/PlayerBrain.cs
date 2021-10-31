using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

/// <summary>
/// The PlayerBrain is an implementation of IBrain that reads input for a player and generates Thoughts from them
/// </summary>
public class PlayerBrain : MonoBehaviour, IBrain
{
    public HashSet<Thought> thoughtsThisFrame = new HashSet<Thought>();
    public int playerId;

    private Player player;

    void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);

    }
    // Update is called once per frame
    void Update()
    {

        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        
    }


    public HashSet<Thought> Think()
    {
        return thoughtsThisFrame;
    }

    public void ClearThoughts()
    {
        thoughtsThisFrame.Clear();
    }
}
