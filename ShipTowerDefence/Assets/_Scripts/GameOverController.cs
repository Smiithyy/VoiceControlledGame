using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void OnTriggerEnter(Collider hitInfo)
    {
        Debug.Log(hitInfo.name);
        EnemyController enemy = hitInfo.GetComponent<EnemyController>();

        if (enemy != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}