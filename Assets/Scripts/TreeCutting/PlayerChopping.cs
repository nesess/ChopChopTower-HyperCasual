using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChopping : MonoBehaviour
{
    [SerializeField]
    private GameObject axe;

    
    public GameObject trees;
    private Animator myAnim;


    private PlayerMovement playerMovement;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

   
    public void ChoppingEvent()
    {
        trees.GetComponent<TreeCutArea>().TreeChopped();
    }

    public void ShowAxe()
    {
        axe.SetActive(true);
        transform.LookAt(trees.transform.position);
        playerMovement.isCutting = true;
        
    }

    public void DisableAxe()
    {
        axe.SetActive(false);
        playerMovement.isCutting = false;
    }

    public void StartChopping()
    {
        myAnim.SetBool("isChopping", true);
       
    }

    

    public void EndChopping()
    {
        myAnim.SetBool("isChopping", false);
        DisableAxe();
    }
}
