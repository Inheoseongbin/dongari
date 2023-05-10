
using UnityEngine;
using UnityEngine.Events;

public interface IAgentInput
{
    public UnityEvent<Vector2> OnPointerPositionChanged { get; set; }
}
