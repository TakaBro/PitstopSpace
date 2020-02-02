using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerControllerKeys keys;
    public int right;

    public float upDist;
    public float downDist;

    private ItemData itemData; 
    bool carrying = false;

    public SpriteRenderer spriteR;

    // Update is called once per frame
    void Update()
    {
        Move();
        GetItem();
    }

    void Move()
    {      
        if (Input.GetKeyDown(keys.upKey) && transform.position.y < 1.5f)
        {
            transform.position += new Vector3(0.0f, upDist);
        }else if(Input.GetKeyDown(keys.upKey) && transform.position.y == 1.5f){
            spriteR.sprite = null;
            carrying = false;
        }else if(Input.GetKeyDown(keys.downKey) && transform.position.y > -3.5f){
            transform.position += new Vector3(0.0f, downDist);
        }
    }

    // Update is called once per frame
    void GetItem()
    {      
        if (Input.GetKeyDown(keys.pickKey) && !carrying)
        {
            Collider2D colider = Physics2D.Linecast(transform.position, transform.position + Vector3.right * right * 5, 
                1 << LayerMask.NameToLayer("Item")).collider;
            
            itemData = colider.GetComponent<ItemComponent>()?.ConsumeItem();
            spriteR.sprite = itemData?.sprite;

            carrying = true;

        }/*else if(Input.GetKeyDown(dropBtn) && ){
            TODO DROP ITEM
        }*/
    }
}
