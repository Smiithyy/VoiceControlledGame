using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void Update()
    {
        transform.position += transform.forward * 0.075f;
    }

    public void Destroy()
    {        
        Destroy(gameObject);
    }
}
