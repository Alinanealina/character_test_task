using UnityEngine;

public class instrMod : interactMod
{
    private bool shown = false;
    [SerializeField] private GameObject instr_panel;
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 1, 0) * 1.5f);
    }
    public override void interact()
    {
        shown = !shown;
        instr_panel.SetActive(shown);
    }
    public override void too_far()
    {
        if (shown)
            interact();
    }
}