using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTrigger : ObservedObject
{
    [SerializeField] private LayerMask PlayerLayer;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Hand _hand))
        {
            //observedEvent?.Invoke(EnumObservedType.StarFind);
            MissionObserver.GetObservedTypeAction(EnumObservedType.StarFind);
        }
    }
}
