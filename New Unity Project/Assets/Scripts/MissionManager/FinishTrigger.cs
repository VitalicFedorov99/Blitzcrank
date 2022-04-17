using UnityEngine;

public class FinishTrigger : ObservedObject
{
    [SerializeField] private LayerMask PlayerLayer;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out CharacterRobot robot)) 
        {
            if(robot.GetEndGame()==false)
            {
                MissionObserver.GetObservedTypeAction(EnumObservedType.Finished);
                Debug.Log("ИвентЗасчитан");
                robot.SetEndGame(true);
            }
            //observedEvent?.Invoke(EnumObservedType.Finished);
        }
    }
}
