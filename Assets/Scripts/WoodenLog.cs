using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenLog : MonoBehaviour
{
    private NightCounter m_nightCounter = NightCounter.Instance;

    public static WoodenLog Instance;

    private int hp;
    public int HP
    {
        get => hp;
        set
        {
            if (value < 1)
            {
                value = 3;
                BackPack.Instance.woodAmount += 1;
            }
            hp = value;
        }
    }
    private void Start()
    {
        HP = 3;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
