using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public bool dontMove;
    [SerializeField]
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

    public float horseSpeed;
    public bool onHorse;

    public AudioSource audios;
    public AudioClip halt;

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
        if(cooldown && gameObject.GetComponent<jump>().isSwinging == false)
        {
            currentCooldown += Time.deltaTime;
            if(currentCooldown >= cooldownDuration)
            {
                ready = true;
                cooldown = false;
            }
        }

        if (isHalt)
            currentSpeed = haltSpeed; 
        if (onHorse && !isHalt)
            currentSpeed = horseSpeed;
        if (!isHalt && !onHorse)
            currentSpeed = speed;

        if (!dontMove)
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

            audios.clip = halt;
            audios.Play();

            isHalt = true;
            if (gameObject.GetComponent<jump>().isSwinging == true) 
            {
                gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<SwingType>().SlowDown();
            } 
        }
    }
}
