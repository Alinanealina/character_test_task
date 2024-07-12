using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class interactMod : MonoBehaviour
{
    [NonSerialized] protected charControl cc = null;
    protected charHP chp;
    private Text obj_e_text;
    private void Start()
    {
        obj_e_text = GameObject.Find("text_E").GetComponent<Text>();
    }
    public void show_dead_msg()
    {
        obj_e_text.text = "Dead.";
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if ((cc = other.gameObject.GetComponent<charControl>()) != null)
        {
            obj_e_text.text = "Press \"E\"\nto interact";
            chp = cc.GetComponent<charHP>();
        }
    }
    protected void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<charControl>() == cc)
        {
            cc = null;
            obj_e_text.text = "";
            too_far();
        }
    }

    public virtual void interact() {}
    protected virtual void too_far() {}
}