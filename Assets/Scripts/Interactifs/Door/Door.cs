using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;
    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isOpen)
            {
                anim.SetTrigger("Close");
                isOpen = false;
            }
            else
            {
                anim.SetTrigger("Open");
                isOpen = true;
            }

        }

    }

    public bool GetIsOpen()
    {
        return isOpen;
    }
}
