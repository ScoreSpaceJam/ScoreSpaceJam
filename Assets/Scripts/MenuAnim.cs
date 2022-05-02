using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnim : MonoBehaviour
{
    float timer = 0;
    float timebase = 2;

    bool isCompleted = false;

    [SerializeField] GameObject Buttons;

    private void Start()
    {
        Buttons.SetActive(false);
    }

    private void Update()
    {
        if(!isCompleted)
        {
            timer += Time.deltaTime;
            if (timer > timebase)
            {
                Buttons.SetActive(true);
                isCompleted = true;
            }
        }
    }
}
