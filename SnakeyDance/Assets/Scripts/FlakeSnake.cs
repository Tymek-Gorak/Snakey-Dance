using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakeSnake : MonoBehaviour
{
    private List<int> maceAttack = new List<int>{2, 1, 3, 5};
    private List<int> tailAttackS = new List<int>{2, 3, 6}; 
    private List<int> tailAttackB = new List<int>{1, 2, 3, 5, 6, 9};  

    [SerializeField] private GameObject maceAttackObject;
    [SerializeField] private GameObject tailAttackObjectS;
    [SerializeField] private GameObject tailAttackObjectB;

    [SerializeField] private Sprite[] danceMoves = new Sprite[2];

    private float attackCooldown = 2f;

    private SpawnMenager spawnMenager;

    private void Awake() {
        spawnMenager = SpawnMenager.SpawnMenagerInstance;
    }

    void Start()
    { 
        StartCoroutine("Fight");
        StartCoroutine("Dance");
    }

    private void Update() {
        if(!Player.Instance.isAlive){
            StopCoroutine("Fight");
            attackCooldown = 2f;
            StartCoroutine("Fight");
            Player.Instance.isAlive = true;
        }
    }

    // Update is called once per frame
    void MaceA()
    {
        spawnMenager.FourWayAttack(maceAttack, maceAttackObject);
        
    }
    void TailSA()
    {
        spawnMenager.FourWayAttack(tailAttackS, tailAttackObjectS);
        
    }
    void TailBA()
    {
        spawnMenager.FourWayAttack(tailAttackB, tailAttackObjectB);
        
    }

    private IEnumerator Fight(){
        yield return new WaitForSeconds(2f);
        while(true){
            int i = UnityEngine.Random.Range(1,5);
            if(i == 1) spawnMenager.BiteAttack();
            if(i == 2) MaceA();
            if(i == 3) TailBA();
            if(i == 4) TailSA();
            yield return new WaitForSeconds(attackCooldown);
            attackCooldown -= 0.1f;
            if(attackCooldown <= 0.5f){
                attackCooldown = 0.5f;
            }
        }
    }

    private IEnumerator Dance(){
        while(true){
            this.transform.GetComponent<SpriteRenderer>().sprite = danceMoves[1];
            yield return new WaitForSeconds(0.55f);
            this.transform.GetComponent<SpriteRenderer>().sprite = danceMoves[0];
            yield return new WaitForSeconds(0.55f);
        }
    }
}
