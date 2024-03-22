using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private Door m_Door;
    private bool entreCollition = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Door = GameObject.Find("DoorShaft").GetComponent<Door>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        entreCollition = true;
    }

    private void OnTriggerExit(Collider collider)
    {
        entreCollition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (entreCollition)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!m_Door.GetIsOpen())
                {
                    m_Door.OpenDoor();
                }
                else
                {
                    m_Door.CloseDoor();
                }
            }
        }
    }
}
