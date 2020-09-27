using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoresController : MonoBehaviour
{
    SpriteRenderer spriteRenderer; 
    Rigidbody2D rigidbody2d; 
    public Sprite[] sprites = new Sprite[6]; 
    public GameObject[] flames = new GameObject[3]; 
    float[] flameTimeout = new float[3]; 
    public float flameTimer = 2; 
    public float timeToBurn = 2; // seconds before moving to next burning phase 
    float burningTimer; 
    bool isBurning = false; 
    int burnLevel = 0;
    private Vector3 target; 
    Camera camera;
    SceneSwitcher sw;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        rigidbody2d = GetComponent<Rigidbody2D>(); 
        burningTimer = timeToBurn; 
        camera = Camera.main; 
        Cursor.visible = false;
        sw = GetComponent<SceneSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        // move stick 
        target = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        gameObject.transform.position = new Vector2(target.x, target.y); 

        // spawn/despawn flames 
        for (int i = 0; i < 3; i++)
        {
            if (flameTimeout[i] > 0)
            {
                flameTimeout[i] -= Time.deltaTime; 
                continue; 
            }
            else if(RandomBool()) 
            {
                flames[i].SetActive(true);  
            }
            else
            {
                flames[i].SetActive(false); 
            }
            flameTimeout[i] = flameTimer;
        }

        // check if marshmellow is over fire
        if (isBurning) 
        {
            burningTimer -= Time.deltaTime; 
            if (burningTimer < 0) 
            { 
                Burn(); 
            }
        }
    }

    void OnTriggerStay2D (Collider2D other) 
    {
        isBurning = true; 
    } 
    
    void OnTriggerExit2D (Collider2D other)
    {
        isBurning = false; 
    }

    void Burn() 
    {
        burnLevel++; 
        isBurning = false; 
        if (burnLevel < 6) 
        {
            spriteRenderer.sprite = sprites[burnLevel]; 
        }
        burningTimer = timeToBurn; 

        if(burnLevel > 6 )
        {
            Cursor.visible = true;
            sw.setWinState(true);
        }
    }

    bool RandomBool()
    {
        return (Random.Range(0,2) == 1);
    }


}
