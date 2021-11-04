using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAnimationStateNames : MonoBehaviour
{
    [SerializeField] private AnimationNameDictionary animationNames = new AnimationNameDictionary();

    private Dictionary<AnimationName, int> animations = new Dictionary<AnimationName, int>();
    private void Start()
    {
        foreach(KeyValuePair<AnimationName,string> entry in animationNames)
        {
            animations[entry.Key] = Animator.StringToHash(entry.Value);
        }
    }

    public int Get(AnimationName anim) => animations.GetValueOrDefault(anim,animations[AnimationName.IDLE]);
}

[System.Serializable]
public class AnimationNameDictionary : SerializableDictionary<AnimationName, string> { }

public enum AnimationName
{
    IDLE,
    JUMPSQUAT,
    JUMP,
    FALL,
    LAND
}
