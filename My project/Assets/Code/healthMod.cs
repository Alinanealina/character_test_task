using UnityEngine;

public class healthMod : interactMod
{
    public override void interact()
    {
        cc.hp = change_hp(cc.hp + 3);
        gameObject.SetActive(false);
        OnTriggerExit(cc.GetComponent<Collider>());
    }
}
