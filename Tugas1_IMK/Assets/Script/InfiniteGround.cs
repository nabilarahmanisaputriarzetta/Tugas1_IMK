using UnityEngine;

public class InfiniteGround : MonoBehaviour
{
    public Transform player;

    public float groundLength = 1000f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            transform.parent.position += new Vector3(0, 0, groundLength * 2);
        }
    }
}