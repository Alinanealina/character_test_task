using System;
using UnityEngine;

public class charHP : MonoBehaviour
{
    private const int hp_min = 0, hp_max = 10;
    private int hp = 5;
    [SerializeField] private charControl cc;
    public void add_hp(int hp)
    {
        this.hp = Math.Clamp(this.hp + hp, hp_min, hp_max);
        check_dead();
    }
    public int get_hp()
    {
        return hp;
    }
    public void check_dead()
    {
        if (hp == hp_min)
        {
            cc.dead();
            cc.enabled = false;
        }
    }
}
