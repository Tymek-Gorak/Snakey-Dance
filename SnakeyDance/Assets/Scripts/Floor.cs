using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public static int roomNumber = 0;

    [SerializeField] private GameObject Flake; 
    [SerializeField] private GameObject Text1; 
    [SerializeField] private GameObject Text2; 
    [SerializeField] private GameObject potat; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(roomNumber == 0) {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Text1.SetActive(true);
            Text2.SetActive(true);
            potat.SetActive(true);
        }
        else this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if(roomNumber == 1) {
            Text1.SetActive(false);
            Text2.SetActive(false);
            Flake.SetActive(true);
            potat.SetActive(false);
        }else Flake.SetActive(false);
    }
}
