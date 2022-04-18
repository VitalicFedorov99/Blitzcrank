using UnityEngine;
using UnityEngine.Events;

public class MissionObserver : MonoBehaviour
{
    // public static  MissionObserver instance {get; private set;}
    [SerializeField] private WinOrLose winOrLose;
    public static UnityAction<EnumObservedType> GetObservedTypeAction;
    [SerializeField] private int CountEnemyKills=0;
    [SerializeField]private int CountEnemyStuns=0;
    [SerializeField] private int CountStarFind=0;



    // private void Awake() 
    // {
    //     if(instance==null)
    //     {
    //         instance=this;
    //         DontDestroyOnLoad(this.gameObject);
    //         return;
    //     }
    // }

    private void Awake(){
        GetObservedTypeAction += GetObservedType;
    
        CountEnemyKills=0;
        CountEnemyStuns=0;
        CountStarFind=0;
        Debug.Log("Сетап");
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
            case(EnumObservedType.RobotDead):
                    RobotDead();
                break;
        }
    }

    private void EnemyKill() => CountEnemyKills ++;
    private void EnemyStun() => CountEnemyStuns ++;
    private void StarFind() => CountStarFind ++;

    private void TimeUsDone(){

    }

    private void Finished() {
        Debug.Log("Победа");
        Debug.Log("Stars:" +CountStarFind);
        winOrLose.Win(CountStarFind);
    }

    private void RobotDead()
    {
        Debug.Log("Поражение");
        winOrLose.Lose();
    }
    
    private void OnDisable() 
    {
         GetObservedTypeAction-=GetObservedType;
    }
}
