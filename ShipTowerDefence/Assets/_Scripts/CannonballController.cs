using UnityEngine;

public class CannonballController : MonoBehaviour
{
    public void OnTriggerEnter(Collider hitInfo)
    {
        Debug.Log(hitInfo.name);
        EnemyController enemy = hitInfo.GetComponent<EnemyController>();

        if (enemy != null)
        {
            enemy.Destroy();
            ScoreController.AddScore();
        }

        Destroy(gameObject);
    }
}
