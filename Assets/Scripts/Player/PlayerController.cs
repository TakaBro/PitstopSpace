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
    Animator m_Animator;

    void Start()
    {
        //This gets the Animator, which should be attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponentInChildren<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Move();
        Interact();
    }

    void Move()
    {      
        if (Input.GetKeyDown(keys.upKey) && transform.position.y < 1.5f)
        {
            transform.position += new Vector3(0.0f, upDist);
        }else if(Input.GetKeyDown(keys.upKey) && transform.position.y == 1.5f){
            spriteR.sprite = null;
            carrying = false;
            m_Animator.SetBool("Carrying", false);
            m_Animator.SetTrigger("Trash");
        }else if(Input.GetKeyDown(keys.downKey) && transform.position.y > -3.5f){
            transform.position += new Vector3(0.0f, downDist);
        }
    }

    // Update is called once per frame
    void Interact()
    {      
        if (Input.GetKeyDown(keys.pickKey) && !carrying)
        {
            Collider2D colider = Physics2D.Linecast(transform.position, transform.position + Vector3.right * right * 3, 
                1 << LayerMask.NameToLayer("Item")).collider;
            Debug.DrawLine(transform.position, transform.position + Vector3.right * right * 3, Color.green);
            itemData = colider.GetComponent<ItemComponent>()?.ConsumeItem();
            
            if(itemData)
            {
                spriteR.sprite = itemData?.sprite;
                carrying = true;
                m_Animator.SetBool("Carrying", carrying);
            }
        }

        if (Input.GetKeyDown(keys.dropKey) && carrying)
        {
            Collider2D colider = Physics2D.Linecast(transform.position, transform.position + Vector3.right * -right * 3,
                1 << LayerMask.NameToLayer("Slot")).collider;
            Debug.DrawLine(transform.position, transform.position + Vector3.right * -right * 3,Color.green);
            HangarSlotComponent slot = colider.GetComponent<HangarSlotComponent>();
            if (slot)
            {
                bool isFixed = slot.FixPart(itemData);
                itemData = null;
                carrying = false;
                spriteR.sprite = null;
                m_Animator.SetBool("Carrying", carrying);
                if (isFixed)
                    m_Animator.SetTrigger("FixedPart");
                else
                    m_Animator.SetTrigger("MissedPart");
            }
            
        }
    }
}
