using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public bool dontMove;
    private float currentSpeed;

    public float haltSpeed;
    public bool isHalt;
    public float haltDuration;
    private float currentDuration;
    public bool cooldown;
    public float cooldownDuration;
    private float currentCooldown;
    public bool ready;
    public Image button;

    void Start()
    {
        dontMove = true;
        ready = true;
        currentCooldown = cooldownDuration;
    }

    void Update()
    {
        button.fillAmount = (1 / cooldownDuration) * currentCooldown;
        if (isHalt)
        {
            currentDuration -= Time.deltaTime;
            if(currentDuration <= 0)
            {
                cooldown = true;
                isHalt = false;
            }
        }
        if(cooldown)
        {
            currentCooldown += Time.deltaTime;
            if(currentCooldown >= cooldownDuration)
            {
                ready = true;
                cooldown = false;
            }
        }

        if (!isHalt) { currentSpeed = speed; }
        else { currentSpeed = haltSpeed; }

        if(!dontMove)
        transform.Translate(Vector2.right * Time.deltaTime * currentSpeed);

        if (Input.GetButtonDown("Fire2") && ready)
            Halt();
    }

    public void Halt()
    {
        if(ready)
        {
            ready = false;
            currentDuration = haltDuration;
            currentCooldown = 0;
            isHalt = true;
        }
    }
}
