using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourWayAttack : MonoBehaviour
{

    public List<int> attackSpaces;
    private List<GameObject> Sprites = new List<GameObject>();
    private List<int> attackSpacesOut = new List<int>();
    private List<int> attackSpacesOut2 = new List<int>();
    private List<int> attackSpacesOut3 = new List<int>();
    private List<List<int>> attackLists;
    public int rotationNumber;

    private SpawnMenager spawnMenager;
    
    private void Awake() {
        
        spawnMenager = SpawnMenager.SpawnMenagerInstance;
    }

    private void Start() {


        attackLists = new List<List<int>>{attackSpaces, attackSpacesOut, attackSpacesOut2, attackSpacesOut3};
        if(rotationNumber != 0){
            for(int ii = 0; ii < 3; ii++) {
                foreach(int i in attackLists[ii]){
                    if(i == 1 || i == 6){
                        attackLists[ii + 1].Add(i + 2);
                    }
                    if(i == 2 || i == 3){
                        attackLists[ii + 1].Add(i * 3);
                    }
                    if(i == 4 || i == 8){
                        attackLists[ii + 1].Add(i / 2); 
                    }
                    if(i == 5){
                        attackLists[ii + 1].Add(i);
                    }
                    if(i == 7){
                        attackLists[ii + 1].Add(i - 6);
                    }
                    if(i == 9){
                        attackLists[ii + 1].Add(i - 2);
                    }
                }
            }
        }
        foreach (int i in attackLists[rotationNumber])
        {
            spawnMenager.CreateWarning(i);
        }
        StartCoroutine("attack");
    }

        private IEnumerator attack(){
        foreach(Transform sprite in this.transform){
            Sprites.Add(sprite.gameObject);
        }
        yield return new WaitForSeconds(0.7f);
        Sprites[0].SetActive(false);
        Sprites[1].SetActive(true);
        if(this.gameObject.tag == "mace")SoundManager.Instance.Play("Mace", 0.5f);
        else if(this.gameObject.tag == "tailS")SoundManager.Instance.Play("TailS", 0.5f);
        else if(this.gameObject.tag == "tailB")SoundManager.Instance.Play("TailB", 0.5f);
        for(int i = 1; i < Sprites.Count - 1; i++){
            yield return new WaitForSeconds(0.04f);
            Sprites[i].SetActive(false);
            Sprites[i + 1].SetActive(true);
        }
        StartCoroutine("Dissapear");
        StopCoroutine("attack");
    }

    private IEnumerator Dissapear(){
        for(int i = 0; i < 10; i++){
            yield return new WaitForSeconds(0.04f);
            Sprites[Sprites.Count- 1].GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Sprites[Sprites.Count - 1].GetComponent<SpriteRenderer>().color.a - 0.1f);
        } Points.points += 10;
        Destroy(this.gameObject);
    }
}