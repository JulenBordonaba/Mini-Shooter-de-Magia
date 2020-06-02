using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{

    public UnityEvent animationEvent = new UnityEvent();

    public void AnimationEventInvoke()
    {
        animationEvent.Invoke();
    }
}
