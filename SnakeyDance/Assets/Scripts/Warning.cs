using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    [SerializeField]private bool isPlayerHere = false;
    private float sizeChange;
    void Start()
    {
        StartCoroutine("deathTimer");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.localScale.x > 1){
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        if(this.transform.localScale.x < 1){
            sizeChange = Mathf.Lerp(this.transform.localScale.x, 1, 0.1f);    
            this.transform.localScale = new Vector3(1, 1, 1) * sizeChange;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        isPlayerHere = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        isPlayerHere = false;
    }

    private IEnumerator deathTimer(){
        yield return new WaitForSeconds(0.9f);
        if(isPlayerHere) {
            Player.Instance.transform.GetComponent<SpriteRenderer>().sprite = Player.Instance.damagedSprite;
            Player.Instance.transform.localScale *= 10;
            yield return new WaitForSeconds(0.24f);
            Player.Instance.transform.localScale /= 10;
            Player.Instance.transform.GetComponent<SpriteRenderer>().sprite = Player.Instance.Sprite;
            Player.Instance.isAlive = false;
            if(Points.points > Points.highscore) Points.highscore = Points.points;
            Points.points = 0;

        }       
        Destroy(this.gameObject);
    }
}
