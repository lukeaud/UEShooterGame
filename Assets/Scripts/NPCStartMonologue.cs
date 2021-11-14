using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStartMonologue : MonoBehaviour
{
    public MonologueBrick StartText1, StartText2, StartText3, StartText4;
    public bool AlreadyTalked;
    public void SayHello()
    {
        if (!AlreadyTalked)
        {
            switch (NightCounter.Instance.NightCount)
            {
                case 0:
                    {
                        TextBox.Instance.currentText = StartText1;
                        break;
                    }
                case 1:
                    {
                        TextBox.Instance.currentText = StartText1;
                        //TextBox.Instance.currentText = StartText2;
                        break;
                    }
                case 2:
                    {
                        TextBox.Instance.currentText = StartText3;
                        break;
                    }
                case 3:
                    {
                        TextBox.Instance.currentText = StartText4;
                        break;
                    }
            }
            AlreadyTalked = true;
        }
    }
}
