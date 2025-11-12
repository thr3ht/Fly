using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    public void Enter()
    {
        if (enabled == false)
        {
            enabled = true;

            foreach (Transition transition in _transitions)
            {
                transition.enabled = true;
            }
        }
    }

    public State GetNextState()
    {
        foreach (Transition transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                transition.ResetTransit();
                return transition.TargetState;
            }
        }
        
        return null;
    }

    public void Exit()
    {
        if (enabled)
        {
            foreach (Transition transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }
}