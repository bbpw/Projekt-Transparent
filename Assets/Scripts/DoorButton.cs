using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Camera m_Camera;
    bool radius;
    public GameObject textPopup;
    MeshRenderer text;
    public GameObject door;

    private void Start()
    {
        text = textPopup.GetComponent<MeshRenderer>();
        text.enabled = false;
    }
    void OnTriggerStay(Collider hitBox)
    {
        CharacterController playerCol = hitBox.GetComponent<CharacterController>();
        if (playerCol != null)
        {
            radius = true;
            text.enabled = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        CharacterController playerCol = other.GetComponent<CharacterController>();
        if (playerCol != null)
        {
            radius = false;
            text.enabled = false;

        }
    }
    private void Update()
    {
        if (radius == true)
        {
            transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);

            if (Input.GetKeyDown(KeyCode.E))
            {
                textPopup.SetActive(false);
                door.SetActive(false);
            }
        }
    }
}
