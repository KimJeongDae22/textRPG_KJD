using UnityEditor.Rendering.Universal;
using UnityEngine;
using System;

public class Data_Manager : MonoBehaviour
{
    int level = 10;
    int count = 5;

    float percentage = 50;
    float speed = 5;

    string nickname = "킹정머";
    string description = "헬로 월드";

    int iTen = 10;
    float fTen;

    float fFive = 5.5f;
    int iFive;

    int n = 10;
    float f = 0.5f;

    string strTen = "10";
    string strSix = "6.2";
    float fSix;
    void Start()
    {
        fTen = (float)iTen;
        iFive = (int)fFive;
        //Debug.Log(fTen);
        //Debug.Log(iFive);

        string strN = n.ToString();
        string strF = f.ToString();
        Debug.Log(strN);
        Debug.Log(strF);

        iTen = Convert.ToInt32(strTen); // 이미 같은 이름의 변수가 선언되어서 재활용함
        fSix = Convert.ToSingle(strSix);
        //Debug.Log("Convert 사용 : " + fTen);
        //Debug.Log("Convert 사용 : " + fSix);

        iTen = int.Parse(strTen);
        fSix = float.Parse(strSix);
        //Debug.Log("Parse 사용 : " + fTen);
        //Debug.Log("Parse 사용 : " + fSix);
    }
}
