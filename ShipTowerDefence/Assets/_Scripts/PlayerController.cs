using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody cannonballPrefab;
    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private GameObject cannonBall1;
    [SerializeField]
    private GameObject cannonBall2;
    [SerializeField]
    private GameObject cannonBall3;
    [SerializeField]
    private GameObject cannonBall4;
    [SerializeField]
    private GameObject cannonBall5;

    private int ammo = 5;
    
    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;


    // Start is called before the first frame update
    void Start()
    {
        keywordActions.Add("fire", Fire);

        keywordActions.Add("turn left", TurnLeft);
        keywordActions.Add("full left", FullLeft);

        keywordActions.Add("turn right", TurnRight);
        keywordActions.Add("full right", FullRight);

        keywordActions.Add("reload", Reload);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognised;
        keywordRecognizer.Start();
    }

    private void OnKeywordsRecognised(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();
    }

    private void Fire()
    {
        if (ammo > 0 )
        {
            var ball = Instantiate(cannonballPrefab, firePoint.position, firePoint.rotation) as Rigidbody;
            ball.AddForce(firePoint.transform.forward * 4500f);
            Debug.Log("FIREEEEEE");

            ammo = ammo - 1;

            if (ammo == 4)
            {
                cannonBall5.SetActive(false);
            }
            else if (ammo == 3)
            {
                cannonBall4.SetActive(false);
            }
            else if (ammo == 2)
            {
                cannonBall3.SetActive(false);
            }
            else if (ammo == 1)
            {
                cannonBall2.SetActive(false);
            }
            else if (ammo == 0)
            {
                cannonBall1.SetActive(false);
            }
        }
    }

    private void TurnLeft()
    {
        transform.Rotate(0f, -20f, 0f);
    }

    private void TurnRight()
    {
        transform.Rotate(0f, 20f, 0f);
    }

    private void FullLeft()
    {
        transform.Rotate(0f, -40f, 0f);
    }

    private void FullRight()
    {
        transform.Rotate(0f, 40f, 0f);
    }

    private void Reload()
    {
        ammo = 5;

        cannonBall1.SetActive(true);
        cannonBall2.SetActive(true);
        cannonBall3.SetActive(true);
        cannonBall4.SetActive(true);
        cannonBall5.SetActive(true);
    }
}
