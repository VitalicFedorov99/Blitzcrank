using UnityEngine;

public class FinishTrigger : ObservedObject
{
    [SerializeField] private LayerMask PlayerLayer;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out CharacterRobot robot)) 
        {
            MissionObserver.GetObservedTypeAction(EnumObservedType.Finished);
            //observedEvent?.Invoke(EnumObservedType.Finished);
        }
    }
}
