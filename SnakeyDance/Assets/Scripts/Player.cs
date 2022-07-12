using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveherex;
    [SerializeField] private float moveherey;
    [SerializeField] public Sprite damagedSprite;
    [SerializeField] public Sprite Sprite;
    private bool roomChange = false;
    public bool isBattleOver = true;
    private bool movable = false;


    public bool isAlive = true;

    public static Player Instance{
        get{
            if(instance == null) instance = GameObject.Find("Player").transform.GetComponent<Player>();
            return instance;
        }
    }
    private static Player instance;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //x movement
        #region 
        if(movable){
        if(Input.GetKeyDown(KeyCode.D)){
            moveherex = 1;
        }
        if(Input.GetKeyDown(KeyCode.A)){
            moveherex = -1;
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)){
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(moveherex * 2.25f, this.transform.position.y, this.transform.position.z), 0.4f);
        }
        if(Input.GetKeyUp(KeyCode.D) && this.transform.position.x > -1 && !Input.GetKey(KeyCode.A)){
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3((moveherex - 1) * 2.25f, this.transform.position.y, this.transform.position.z), 2f);
            if(this.transform.position.x < 1 && this.transform.position.x > -1){
                this.transform.position = new Vector3(0, this.transform.position.y, this.transform.position.z);
                moveherex = 0;
            }
        } else if(Input.GetKeyUp(KeyCode.D) && this.transform.position.x > -1 && Input.GetKey(KeyCode.A)){
            moveherex = -1;
        }
        if(Input.GetKeyUp(KeyCode.A) && this.transform.position.x < 1 && !Input.GetKey(KeyCode.D)){  
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3((moveherex + 1) * 2.25f, this.transform.position.y, this.transform.position.z), 2f);
            if(this.transform.position.x < 1 && this.transform.position.x > -1){
                this.transform.position = new Vector3(0, this.transform.position.y, this.transform.position.z);
                moveherex = 0;
            }
        } else if(Input.GetKeyUp(KeyCode.A) && this.transform.position.x < 1 && Input.GetKey(KeyCode.D)){
            moveherex = 1;
        }
        #endregion

        //y movement
        #region 
        if(Input.GetKeyDown(KeyCode.W)){
            moveherey = 1;
        } 
        if(Input.GetKeyDown(KeyCode.S)){
            moveherey = -1;
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)){
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x , moveherey * 2.25f, this.transform.position.z), 0.4f);
        }
        if(Input.GetKeyUp(KeyCode.W) && this.transform.position.y > -1 && !Input.GetKey(KeyCode.S)){
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x , (moveherey - 1) * 2.25f, this.transform.position.z), 2f);
            if(this.transform.position.y < 1 && this.transform.position.y > -1){
                this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
                moveherey = 0;
            }
        } else if(Input.GetKeyUp(KeyCode.W) && this.transform.position.y > -1 && Input.GetKey(KeyCode.S)){
            moveherey = -1;
        }
        if(Input.GetKeyUp(KeyCode.S) && this.transform.position.y < 1 && !Input.GetKey(KeyCode.W)){  
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x ,(moveherey + 1) * 2.25f, this.transform.position.z), 2f);
            if(this.transform.position.y < 1 && this.transform.position.y > -1){
                this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
                moveherey = 0;
            }
        } else if(Input.GetKeyUp(KeyCode.S) && this.transform.position.y < 1 && Input.GetKey(KeyCode.W)){
            moveherey = 1;
        }
        }
        #endregion

        if(roomChange){
            StartCoroutine("ChangedRooms");
            roomChange = false;
        }

        if(isBattleOver && Input.GetKeyDown(KeyCode.Space)){
            movable = false;
            StartCoroutine("BattleOver");
            isBattleOver = false;
        }
    }

    private IEnumerator ChangedRooms(){
        while(this.transform.position != new Vector3(0, 0, 0)){
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(0, 0, 0), 0.36f);
            yield return new WaitForSeconds(0.01f);
        } 
        movable = true;
    }

    private IEnumerator BattleOver(){
        while(true){
            if(this.transform.position != new Vector3(18, 0, 0)){
                this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(18, 0, 0), 0.36f);
                yield return new WaitForSeconds(0.02f);
            }else{
                Floor.roomNumber += 1;
                this.transform.position = new Vector3(-8, 0, 0);
                roomChange = true;
                if(Floor.roomNumber == 1){
                    SoundManager.Instance.StartCoroutine("Music");
                }
                StopCoroutine("BattleOver");
            }
        }
    }
}
