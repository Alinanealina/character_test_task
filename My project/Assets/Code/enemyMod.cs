public class enemyMod : interactMod
{
    public override void interact()
    {
        cc.hp = change_hp(--cc.hp);
    }
}
