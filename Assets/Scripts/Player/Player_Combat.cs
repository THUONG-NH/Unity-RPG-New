using Unity.VisualScripting;
using UnityEngine;

public class Player_Combat : Entity_Combat
{
    [Header("Counter Acttack Details")]
    [SerializeField] private float counterDuration;

    public bool CounterAttackPerformed()
    {
        bool hasCounteredSomebody = false;

        foreach (var col in GetDetectedColliders())
        {
            var ct = GetTargetInterface<ICounterable>(col);
            if (ct != null)
            {
                ct.HandleCounter();
                hasCounteredSomebody = true;
            }
        }

        return hasCounteredSomebody;
    }

    public float GetCounterDuration() => counterDuration;
}
