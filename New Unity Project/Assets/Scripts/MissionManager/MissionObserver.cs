using UnityEngine;
using UnityEngine.Events;

public class MissionObserver : MonoBehaviour
{
    // public static  MissionObserver instance {get; private set;}

    public static UnityAction<EnumObservedType> GetObservedTypeAction;
    private int CountEnemyKills;
    private int CountEnemyStuns;
    private int CountStarFind;



    // private void Awake() 
    // {
    //     if(instance==null)
    //     {
    //         instance=this;
    //         DontDestroyOnLoad(this.gameObject);
    //         return;
    //     }
    // }

    private void Start(){
        GetObservedTypeAction += GetObservedType;
    }

    public  void GetObservedType(EnumObservedType observedType){
        switch(observedType){
            case(EnumObservedType.EnemyKill):
                    Debug.Log("Enemy KILLLLLED");
                    EnemyKill();
                break;            
            case(EnumObservedType.EnemyStun):
                    EnemyStun();
                break;            
            case(EnumObservedType.StarFind):
                    StarFind();
                break;        
            case(EnumObservedType.TimeIsDone):
                    TimeUsDone();
                break;
            case(EnumObservedType.Finished):
                    Finished();
                break;
        }
    }

    private void EnemyKill() => CountEnemyKills ++;
    private void EnemyStun() => CountEnemyStuns ++;
    private void StarFind() => CountStarFind ++;

    private void TimeUsDone(){

    }

    private void Finished() {

    }
}
