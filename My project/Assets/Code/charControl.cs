using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class charControl : MonoBehaviour
{
    private CharacterController cc;
    private interactMod inter_mod;
    [SerializeField] private GameObject e_text;
    [SerializeField] private Text text_health;
    private float speed = 0.1f;
    [NonSerialized] public const int hp_min = 0, hp_max = 10;
    [NonSerialized] public int hp = 5;
    private bool dead = false;
    private interactMod int_mod = null;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        text_health.text = "Health: " + hp;
    }

    void FixedUpdate()
    {
        if (dead)
            return;
        hp_check();
        text_health.text = "Health: " + hp;
        cc.Move(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed);
        cc.Move(new Vector3(0, 0, Input.GetAxis("Vertical")) * speed);
    }
    private void hp_check()
    {
        if (hp == 0)
        {
            dead = true;
            e_text.SetActive(true);
            e_text.GetComponent<Text>().text = "Dead"; 
        }
    }
    private void int_reset()
    {
        int_mod = null;
        e_text.SetActive(false);
    }
    
    private IEnumerator interuction()
    {
        while (int_mod != null)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                int_mod.interact();
                int_reset();
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
        if ((int_mod == null) && other.gameObject.CompareTag("Interactable"))
        {
            int_mod = other.gameObject.GetComponent<interactMod>();
            e_text.SetActive(true);
            StartCoroutine(interuction());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            int_mod.too_far();
            int_reset();
        }
    }
}
