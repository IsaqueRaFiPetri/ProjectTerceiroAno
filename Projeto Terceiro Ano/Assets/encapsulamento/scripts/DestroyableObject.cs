using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    [SerializeField] float destroyTime;
    public void FixedUpdate()
    {
        Destroy(gameObject, destroyTime);
    }
}