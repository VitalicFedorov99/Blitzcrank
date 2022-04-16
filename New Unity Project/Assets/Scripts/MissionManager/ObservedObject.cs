using UnityEngine;
using UnityEngine.Events;

public abstract class ObservedObject : MonoBehaviour
{
    protected UnityEvent<EnumObservedType> observedEvent;    
    private void Start() {
        observedEvent?.AddListener(MissionObserver.GetObservedTypeAction);
    }

}
