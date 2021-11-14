using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    private int m_tryCount;

    private UIManager m_UIManager = UIManager.Instance;

    [SerializeField]
    float maxSpeed, speedRate, speedIncrease, currentValue;
    [SerializeField]
    public float Speed
    {
        get => speed;
        set
        {
            if (value > maxSpeed)
            {
                value = maxSpeed;
            }
            speed = value;
        }
    }
    private float speed;
    bool moveForwards;
    private float redMin, redMax, yellowMin, yellowMax, greenMin, greenMax;
    public float scaling = 1;
    public float ScalingDecrease;
    public int HitStrength;
    private int counter;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    Image red, yellow, green;

    private void Start()
    {
        switch (NightCounter.Instance.NightCount)
        {
            case 0:
                {
                    m_tryCount = 8;
                    scaling = 1;
                    speedRate = 0.2f;
                    maxSpeed = 0.01f;
                    break;
                }
            case 1:
                {
                    m_tryCount = 7;
                    scaling = 0.8f;
                    speedRate = 0.3f;
                    maxSpeed = 0.03f;
                    break;
                }
            case 2:
                {
                    m_tryCount = 6;
                    scaling = 0.7f;
                    speedRate = 0.5f;
                    maxSpeed = 0.04f;
                    break;
                }
            case 3:
                {
                    m_tryCount = 5;
                    scaling = 0.6f;
                    speedRate = 0.8f;
                    maxSpeed = 0.04f;
                    break;
                }
        }
        redMin = 0.5f - 0.5f * scaling;
        redMax = 0.5f + 0.5f * scaling;
        yellowMin = 0.5f - 0.15f * scaling;
        yellowMax = 0.5f + 0.15f * scaling;
        greenMin = 0.5f - 0.05f * scaling;
        greenMax = 0.5f + 0.05f * scaling;
        red.transform.localScale = new Vector3(scaling, red.transform.localScale.y, red.transform.localScale.z);
        yellow.transform.localScale = new Vector3(scaling, yellow.transform.localScale.y, yellow.transform.localScale.z);
        green.transform.localScale = new Vector3(scaling, green.transform.localScale.y, green.transform.localScale.z);      
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            m_tryCount--;
            InputNumber();
            counter++;
            Debug.Log(counter);
            if(m_tryCount == 0)
            {
                m_UIManager.m_WoodCount = counter;
                m_UIManager.UnloadMinigame();
            }
        }
        else
        {
            MoveCursor();
        }
    }
    private void InputNumber()
    {

        if (currentValue >= redMin && currentValue <= redMax)
        {
            HitStrength += 1;
            if (currentValue >= yellowMin && currentValue <= yellowMax)
            {
                HitStrength += 1;
                if (currentValue >= greenMin && currentValue <= greenMax)
                {
                    HitStrength += 1;
                }
            }
            barReset(true);
        }
        else
        {
            barReset(false);
        }
        WoodenLog.Instance.HP -= HitStrength;
        //Debug.Log("HitStrength: " + HitStrength);
        //Debug.Log("HP :" + WoodenLog.Instance.HP);
        HitStrength = 0;
    }
    private void MoveCursor()
    {
        Speed = Time.deltaTime * speedRate;
        speedRate += speedIncrease * Time.deltaTime;
        if (moveForwards)
        {
            currentValue += Speed;
        }
        else
        {
            currentValue -= Speed;
        }
        if (currentValue > 1)
        {
            currentValue = 1;
            moveForwards = false;
        }
        if (currentValue < 0)
        {
            currentValue = 0;
            moveForwards = true;
        }
        slider.value = currentValue;
    }
    private void barReset(bool hit)
    {
        currentValue = 0;
        moveForwards = true;
        Speed = 0;
        if (hit)
        {
            scaling *= ScalingDecrease;
            redMin = 0.5f - 0.5f * scaling;
            redMax = 0.5f + 0.5f * scaling;
            yellowMin = 0.5f - 0.15f * scaling;
            yellowMax = 0.5f + 0.15f * scaling;
            greenMin = 0.5f - 0.05f * scaling;
            greenMax = 0.5f + 0.05f * scaling;
            red.transform.localScale = new Vector3(scaling, red.transform.localScale.y, red.transform.localScale.z);
            yellow.transform.localScale = new Vector3(scaling, yellow.transform.localScale.y, yellow.transform.localScale.z);
            green.transform.localScale = new Vector3(scaling, green.transform.localScale.y, green.transform.localScale.z);
        }
    }
}