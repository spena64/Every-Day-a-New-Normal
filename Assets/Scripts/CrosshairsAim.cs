using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairsAim : MonoBehaviour
{
    private bool isAiming; 
    private bool shouldKill;
    private int scoreCount;
    public float clickCooldown = 0.5f; 
    float clickTimer; 
    public int scoreNeed;
    SceneSwitcher sw;

    // Start is called before the first frame update
    void Start()
    {
        sw = GetComponent<SceneSwitcher>();
        clickTimer = 0.0f; 
    }

    void Update()
    {
        if (clickTimer > 0.0f)
        {
            clickTimer -= Time.deltaTime; 
            if (clickTimer < 0)
            {
                shouldKill = false; 
            }
        }
    }

    void OnTriggerStay2D (Collider2D other)
    {
        GhostController g = other.GetComponent<GhostController>(); 
        if (g != null && shouldKill)
        {
            g.Kill();
            Counter(); 
            shouldKill = false;  
            return; 
        }
        else if (g != null)
        {
            isAiming = true; 
            return; 
        }

        Smile s = other.GetComponent<Smile>(); 
        if (s != null && shouldKill)
        {
            s.TakePic();  
            if (s.IsWin())
            {
                Counter(); 
            }
            return; 
        }
        else if (s != null)
        {
            isAiming = true; 
            return; 
        }

        if (other.tag == "flame" && shouldKill)
        {
            Destroy(other.gameObject); 
        }

        isAiming = false; 
    }

    void OnTriggerExit2D (Collider2D other)
    {
        GhostController g = other.GetComponent<GhostController>(); 
        if (g != null)
        {
            isAiming = false; 
        }

        Smile s = other.GetComponent<Smile>(); 
        if (s != null)
        {
            isAiming = false;
        }
    }


    public bool IsAiming ()
    {
        return isAiming; 
    }

    public void SetKill (bool b)
    {
        shouldKill = b;
        clickTimer = clickCooldown; 
    }

    public void Counter()
    {
        scoreCount++;
        if (scoreCount == scoreNeed)
        {
            Cursor.visible = true; 
            sw.setWinState(true);
        }
    }
}
