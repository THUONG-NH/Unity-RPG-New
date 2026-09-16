using UnityEngine;

public class Player_Combat : Entity_Combat
{
    [Header("Counter Acttack Details")]
    [SerializeField] private float counterRecovery = .1f;

    public bool CounterAttackPerformed()
    {
        bool hasPerformedCounter = false;

        foreach (var col in GetDetectedColliders())
        {
            if (!col.TryGetComponent<ICounterable>(out var counterable)) continue;

            if (counterable.CanBeCountered)
            {
                counterable.HandleCounter();
                hasPerformedCounter = true;
            }
        }

        return hasPerformedCounter;
    }

    public float GetCounterRecoveryDuration() => counterRecovery;
}
