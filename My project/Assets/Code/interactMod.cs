using UnityEngine;

public abstract class interactMod : MonoBehaviour
{
    protected charControl cc = null;
    public virtual void interact() {}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            cc = other.gameObject.GetComponent<charControl>();
    }
    protected void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<charControl>() == cc)
            cc = null;
    }
    protected int change_hp(int hp)
    {
        if (hp < charControl.hp_min)
            return charControl.hp_min;
        else if (hp > charControl.hp_max)
            return charControl.hp_max;
        return hp;
    }

    public virtual void too_far() {}
}