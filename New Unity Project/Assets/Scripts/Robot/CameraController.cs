using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float XBorderOffset = 10f;
    [SerializeField] private float YBorderOffset = 10f;
    

    private float viewAreaHalfHeight;
    private float halfDistanceBetweenStates;

    private Vector3 playerPos;
    private Vector3 lastPlayerPos;
    private Vector3 camPos;
    private Vector3 camDisplacementVector;
    
    private void Setup(Transform player){
        this.player = player;      
        CalculationValues();            
        transform.position = new Vector3(player.position.x - 2 * halfDistanceBetweenStates, player.position.y, transform.position.z);    
    }
    private void Start() {
        Setup(player);
    }

    private void Update()
    {
        playerPos = player.position;
        camPos = transform.position;
        camDisplacementVector = Vector3.zero;

        if(Mathf.Abs(playerPos.y - camPos.y) >= viewAreaHalfHeight) 
            camDisplacementVector.y = playerPos.y - lastPlayerPos.y;
        
        if(Mathf.Abs(playerPos.x - camPos.x) <  halfDistanceBetweenStates) 
            camDisplacementVector.x = playerPos.x - lastPlayerPos.x;

        if(Mathf.Abs(playerPos.x - camPos.x) >=  3*halfDistanceBetweenStates) 
            camDisplacementVector.x = Mathf.Sign(playerPos.x - camPos.x) * 4.5f * halfDistanceBetweenStates; 
        transform.position += camDisplacementVector;
        lastPlayerPos = playerPos;
    }

    private void CalculationValues(){
        viewAreaHalfHeight = (Camera.main.pixelHeight/108 - 2 * YBorderOffset) / 2;
        halfDistanceBetweenStates = (Camera.main.pixelWidth/108 - 2 * XBorderOffset) / 6;
    }
}
