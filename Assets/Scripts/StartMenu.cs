using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    void Update()
    {
        if ( Input.GetKeyDown( "space" ) )
        {
            EnemyController.Singelton.started = true;
            gameObject.SetActive(false);
        }
    }
}
