using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightCounter : MonoBehaviour
{
    public static NightCounter Instance;

    public int NightCount = 1;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
