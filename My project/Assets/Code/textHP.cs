using UnityEngine;
using UnityEngine.UI;

public class textHP : MonoBehaviour
{
    [SerializeField] private charHP chp;
    private Text text_hp;
    private void Start()
    {
        text_hp = GetComponent<Text>();
    }
    private void Update()
    {
        text_hp.text = "Health: " + chp.get_hp().ToString();
    }
}
