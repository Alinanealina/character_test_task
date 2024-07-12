using UnityEngine;

public class camFollow : MonoBehaviour
{
    [SerializeField] private Transform character;
    private Vector3 start_pos;

    private void Start()
    {
        start_pos = transform.position - character.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(
            start_pos.x + character.position.x,
            transform.position.y,
            start_pos.z + character.position.z);
    }
}
