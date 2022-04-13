using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
  [SerializeField] private List<GameObject> _invetory;

private void Start() {
     _invetory=new List<GameObject>();
}
   public void AddItem(GameObject item)
   {
       _invetory.Add(item);
   }
}
