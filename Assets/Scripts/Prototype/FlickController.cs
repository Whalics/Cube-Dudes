using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite flick;
    public Sprite flicked;
    public Vector3 flickoffset;
    public Quaternion flickrot;

    TurnManager turnmanager;
    ShootController shootcontroller;
    // Start is called before the first frame update
    void Start()
    {
        turnmanager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        shootcontroller = GameObject.Find("ShootController").GetComponent<ShootController>();
    }

    // Update is called once per frame
    public IEnumerator Flicked(){
        flickrot = transform.localRotation;
        spriteRenderer.sprite = flicked;
        transform.parent = null;
        yield return new WaitForSeconds(2f);
        spriteRenderer.sprite = flick;
    }
    public IEnumerator NextFlick(){
        spriteRenderer.sprite = flick;
        transform.parent = Camera.main.transform;
        transform.localPosition = flickoffset;
        transform.localRotation = flickrot;
        yield break;
    }
}
