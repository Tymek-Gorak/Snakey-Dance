using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenager : MonoBehaviour
{
    [SerializeField] private GameObject warningSign;
    [SerializeField] private GameObject biteAttack;

    int[] allSides = new int[4] { 0, 2, 3, 5};
    int[] doubleTailSpaces = new int[6] {2, 4, 5, 6, 7, 9};
    
    private Dictionary<int, Vector2> boardSpawnPositions = new Dictionary<int, Vector2>();
    
    public static SpawnMenager SpawnMenagerInstance{
        get{
            if(spawnMenagerInstance == null) spawnMenagerInstance = GameObject.Find("SpawnMenager").transform.GetComponent<SpawnMenager>();
            return spawnMenagerInstance;
        }
    }
    private static SpawnMenager spawnMenagerInstance;
    
    private void Start(){
    boardSpawnPositions.Add(1, new Vector2(-2.09f, 2.25f));
    boardSpawnPositions.Add(2, new Vector2(0.13f, 2.25f));
    boardSpawnPositions.Add(3, new Vector2(2.35f, 2.25f));
    boardSpawnPositions.Add(4, new Vector2(-2.09f, 0));
    boardSpawnPositions.Add(5, new Vector2(0.13f, 0));
    boardSpawnPositions.Add(6, new Vector2(2.35f,0));
    boardSpawnPositions.Add(7, new Vector2(-2.09f, -2.25f));
    boardSpawnPositions.Add(8, new Vector2(0.13f, -2.25f));
    boardSpawnPositions.Add(9, new Vector2(2.35f, -2.25f));
    }

    public void CreateWarning(int i){
        Instantiate(warningSign, boardSpawnPositions[i], Quaternion.identity);
    }

    public void BiteAttack(){
        int positionSide = allSides[Random.Range(0,allSides.Length)];
        int positionPlace = Random.Range(1,4);
        if(positionSide < 3){
            BiteAtt bite = Instantiate(biteAttack, new Vector3((positionPlace - 2) * 2.25f + 0.125f, (positionSide - 1) * 4.6f, 0), Quaternion.Euler(0f, 0f, (positionSide - 1) * 90)).GetComponent<BiteAtt>();
            bite.startingPoint = positionPlace + 3 + -3 * (positionSide - 1);
            bite.changeBy = (positionSide - 1) * 3;
        }else{
            BiteAtt bite = Instantiate(biteAttack, new Vector3( (positionSide - 4) * 4.6f, (positionPlace - 2) * 2.25f + 0.125f, 0), Quaternion.Euler(0f, 0f, (positionSide - 5) * -90)).GetComponent<BiteAtt>();
            bite.startingPoint = 8 + (positionSide - 4) - (positionPlace - 1) * 3;
            bite.changeBy = -(positionSide - 4) ;
        }
    }

    public void BiteAttackSetup(int Side, int Place){
        if(Side < 3){
            BiteAtt bite = Instantiate(biteAttack, new Vector3((Place - 2) * 2.25f + 0.125f, (Side - 1) * 4.6f, 0), Quaternion.Euler(0f, 0f, (Side - 1) * 90)).GetComponent<BiteAtt>();
            bite.startingPoint = Place + 3 + -3 * (Side - 1);
            bite.changeBy = (Side - 1) * 3;
        }else{
            BiteAtt bite = Instantiate(biteAttack, new Vector3( (Side - 4) * 4.6f, (Place - 2) * 2.25f + 0.125f, 0), Quaternion.Euler(0f, 0f, (Side - 5) * -90)).GetComponent<BiteAtt>();
            bite.startingPoint = 8 + (Side - 4) - (Place - 1) * 3;
            bite.changeBy = -(Side - 4) ;
        }
    }

    public void FourWayAttack(List<int> attackPoints, GameObject attack){
        int positionSide = allSides[Random.Range(0,allSides.Length)];
        if(positionSide < 3){
            FourWayAttack att = Instantiate(attack, new Vector3(0, (positionSide - 1) * 4.6f, 0), Quaternion.Euler(0f, 0f, (positionSide - 1) * 90)).GetComponent<FourWayAttack>();
            att.attackSpaces = attackPoints;
            if(positionSide == 0) att.rotationNumber = 2;
            else att.rotationNumber = 0;
        }else{
            FourWayAttack att = Instantiate(attack, new Vector3((positionSide - 4) * 4.6f, 0, 0), Quaternion.Euler(0f, 0f, (positionSide - 5) * -90)).GetComponent<FourWayAttack>();
            att.attackSpaces = attackPoints;
            if(positionSide == 3) att.rotationNumber = 3;
            else att.rotationNumber = 1;
        }
    }
}
