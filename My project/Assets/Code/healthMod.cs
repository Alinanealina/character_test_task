using UnityEngine;

public class healthMod : interactMod
{
    public override void interact()
    {
        chp.add_hp(3);
        OnTriggerExit(cc.GetComponent<Collider>());
        gameObject.SetActive(false);
    }
}
