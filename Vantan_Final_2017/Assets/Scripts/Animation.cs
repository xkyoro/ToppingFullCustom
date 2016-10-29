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

    [SerializeField]
    private List<string> _Name;

    public enum ButtonName
    {
        Square,
        Circle,
        Triangle,
        Cross,
        MaxButton,
    }

    void start()
    {
        check = new List<bool>();
        checkButton = new List<bool>();

        for (int i = 0; i < 100; i++)
        {
            check.Add(false);
        }


        for (int i = 0; i < (int)ButtonName.MaxButton; i++)
        {
            checkButton.Add(false);
        }
    }

    public string getButtonName()
    {
        for (int i = 0; i < (int)ButtonName.MaxButton; i++)
        {
            if (isPressButton())
            {
                return _Name[i];
            }
        }
        return null;
    }

    void Update()
    {
        if (check.Count == 0)
        {
            check.Add(false);
        }

        if (check.Count != 0)
        {

        }

        //if ()
        {
            //this.transform.Translate(0, 0.5f, 0);
        }
    }

    public bool isPressButton()
    {
        for(int i = 0;i< (int)ButtonName.MaxButton; i++)
        {
            if (Input.GetAxis(_Name[i]) == 1.0f)
            {
                Debug.Log(_Name[i]);
                return true;
            }
        }
        return false;
    }
}
