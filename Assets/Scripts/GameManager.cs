using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public bool canShoot; 
    public float powerUpDuration = 5;
    public float powerUpTimer = 0;

    void ShootPowerUp()
    {
        if(canShoot)
        {
            if(powerUpTimer <= powerUpDuration)
            {
                powerUpTimer += Time.deltaTime;
            }
            else 
            {
                canShoot = false;
                powerUpTimer = 0;
            }
        }
    }
}
