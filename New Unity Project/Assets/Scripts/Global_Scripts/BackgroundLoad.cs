using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackgroundLoad : MonoBehaviour
{
    [SerializeField] private Image _img;
    [SerializeField] private float amb=255;
    void Start()
    {
        StartCoroutine(OffBackground());
    }

    IEnumerator OffBackground()
    {  
        for(int i=0;i<24;i++)
        {
           
            _img.color=new Color(255,255,255,amb);
            amb=amb-10;
            yield return new WaitForSeconds(0.5f);
        }
        
        
    }
}
