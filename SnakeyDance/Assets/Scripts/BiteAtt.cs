using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteAtt : MonoBehaviour
{
    public int startingPoint;
    public int changeBy;

    [SerializeField] private GameObject bite1;
    [SerializeField] private GameObject bite2;
    [SerializeField] private GameObject bite3;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = bite3.GetComponent<SpriteRenderer>();
        for (int i = 0; i < 3; i ++){
            SpawnMenager.SpawnMenagerInstance.CreateWarning(startingPoint + changeBy * i);
        }
        StartCoroutine("attack");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator attack(){
        yield return new WaitForSeconds(0.7f);
        bite1.SetActive(false);
        bite2.SetActive(true);
        SoundManager.Instance.Play("Bite", 0.5f);
        yield return new WaitForSeconds(0.04f);
        bite2.SetActive(false);
        bite3.SetActive(true);
        StartCoroutine("Dissapear");
        StopCoroutine("attack");
    }

    private IEnumerator Dissapear(){
        for(int i = 0; i < 10; i++){
            yield return new WaitForSeconds(0.06f);
            spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, spriteRenderer.color.a - 0.1f);
        } Points.points += 5;
        Destroy(this.gameObject);
    }
}
