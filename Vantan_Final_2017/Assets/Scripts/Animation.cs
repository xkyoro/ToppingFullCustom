using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Animation : MonoBehaviour
{
    
    [SerializeField]
    private GameObject DirUp = null;
    [SerializeField]
    private GameObject DirDown = null;
    [SerializeField]
    private GameObject DirLeft = null;
    [SerializeField]
    private GameObject DirRight = null;

    [SerializeField]
    private GameObject ActUp = null;
    [SerializeField]
    private GameObject ActDown = null;
    [SerializeField]
    private GameObject ActLeft = null;
    [SerializeField]
    private GameObject ActRight = null;

    [SerializeField]
    private List<bool> check;
    [SerializeField]
    private List<bool> checkButton;

    private int index = 0;

    void Update()
    {
        if (check == null)
        {
            Debug.Log("null");
        }

        if (check != null)
        {
            Debug.Log(check.Count);
           
            if (!check[index] && !checkButton[0] && PressCircle())
            {
                check[index] = true;
                checkButton[0] = true;
                if (index < check.Count - 1)
                {
                    index++;
                }
            }
            if (!check[index] && !checkButton[1] && PressCross())
            {
                check[index] = true;
                checkButton[1] = true;
                if (index < check.Count - 1)
                {
                    index++;
                }
            }
            if (!check[index] && !checkButton[2] && PressSpuare())
            {
                check[index] = true;
                checkButton[2] = true;
                if (index < check.Count - 1)
                {
                    index++;
                }
            }
            if (!check[index] && !checkButton[3] && PressTriangle())
            {
                check[index] = true;
                checkButton[3] = true;
                if (index < check.Count - 1)
                {
                    index++;
                }
            }

            if (checkButton[0] && checkButton[1] && checkButton[2] && checkButton[3])
            {
                for (int i = 0; i < 4; i++)
                {
                    checkButton[i] = false;
                }
            }
        }

        //if ()
        {
            //this.transform.Translate(0, 0.5f, 0);
        }
    }

    public void isNextIndex()
    {

    }

    public bool PressSpuare()
    {
        if (Input.GetAxis("PS4Square") == 1.0f)
        {
            Debug.Log("Square");
            return true;
        }
        return false;
    }

    public bool PressCircle()
    {
        if (Input.GetAxis("PS4Circle") == 1.0f)
        {
            Debug.Log("Circle");
            return true;
        }
        return false;
    }

    public bool PressTriangle()
    {
        if (Input.GetAxis("PS4Triangle") == 1.0f)
        {
            Debug.Log("Triangle");
            return true;
        }
        return false;
    }

    public bool PressCross()
    {
        if (Input.GetAxis("PS4Cross") == 1.0f)
        {
            Debug.Log("cross");
            return true;
        }
        return false;
    }
}
