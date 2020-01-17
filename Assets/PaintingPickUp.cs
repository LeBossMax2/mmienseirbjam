using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPickUp : MonoBehaviour
{
    float TimeSpent = 0;
    public Thief Thief;
    public int PaintingScore;
    bool ispushed = false;
    bool isin = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        ispushed = Input.GetKey(KeyCode.Space);
        if (isin)
        {
            if (ispushed)
            {
                TimeSpent += Time.deltaTime;
                if (TimeSpent >= 3)
                {
                    Destroy(gameObject);
                    Thief.score += PaintingScore;
                }

            }
            else
                TimeSpent = 0;
        }
        else TimeSpent = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isin = true;  
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isin = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
    }
}
