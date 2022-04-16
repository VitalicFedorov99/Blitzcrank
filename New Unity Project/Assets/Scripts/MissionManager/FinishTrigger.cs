using UnityEngine;

public class FinishTrigger : ObservedObject
{
    [SerializeField] private LayerMask PlayerLayer;
    void OnTriggerEnter2D(Collider2D other)
    {
        if((PlayerLayer & other.gameObject.layer) != 0) {
            observedEvent?.Invoke(EnumObservedType.Finished);
        }
    }
}
