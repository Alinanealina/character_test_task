using System;
using System.Collections;
using UnityEngine;

public class charControl : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 0.1f;
    private interactMod inter_mod = null;
    public event Action on_dead;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        controller.Move(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed);
        controller.Move(new Vector3(0, 0, Input.GetAxis("Vertical")) * speed);
    }

    private IEnumerator interaction()
    {
        while (inter_mod != null)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                inter_mod.interact();
                inter_mod = null;
            }
            yield return null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerStay(other);
    }
    private void OnTriggerStay(Collider other)
    {
        if ((inter_mod == null) && ((inter_mod = other.gameObject.GetComponent<interactMod>()) != null))
        {
            on_dead += inter_mod.show_dead_msg;
            StartCoroutine(interaction());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<interactMod>() == inter_mod)
        {
            on_dead -= inter_mod.show_dead_msg;
            inter_mod = null;
        }
    }

    public void dead()
    {
        on_dead?.Invoke();
        inter_mod = null;
    }
}
