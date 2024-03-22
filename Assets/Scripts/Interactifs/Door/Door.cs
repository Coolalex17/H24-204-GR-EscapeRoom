using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

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
    { /*
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            if (!GetIsOpen())
            {
                OpenDoor();
            }
            else
            {
                CloseDoor();
            }

        }
        */
    }

    public bool GetIsOpen()
    {
        return isOpen;
    }

    public void OpenDoor()
    {
        anim.SetTrigger("Open");
        isOpen = !isOpen;
    }

    public void CloseDoor()
    {
        anim.SetTrigger("Close");
        isOpen = !isOpen;
    }
}
