using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smile : MonoBehaviour
{
    bool smiling; 
    public Sprite smileSprite;
    public Sprite frownSprite;  
    public float smileTime = 1.0f; 
    float smileTimer;
    public float cooldown = 2.0f; 
    float cooldownTimer; 
    bool win; 
    SpriteRenderer sr; 

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); 
        cooldownTimer = 0; 
        smileTimer = 0; 
        win = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else if (smileTimer > 0)
        {
            smileTimer -= Time.deltaTime; 
            if (smileTimer < 0)
            {
                smiling = false; 
                sr.sprite = frownSprite; 
                cooldownTimer = cooldown; 
            }
        }

        if(RandomBool() && cooldownTimer <= 0 && smileTimer <= 0)
        {
            sr.sprite = smileSprite; 
            smiling = true; 
            smileTimer = smileTime; 
        }
    }

    public void TakePic()
    {
        if(smiling)
        {
            win = true; 
        }
    }

    bool RandomBool()
    {
        return (Random.Range(0,2) == 1);
    }

    public bool IsWin()
    {
        return win;
    }
}
