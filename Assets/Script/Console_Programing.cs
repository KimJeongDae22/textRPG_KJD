using System;
using UnityEngine;

public class Console_Programing : MonoBehaviour
{
    string input = Console.ReadLine();
    int num;
    void OnEnable()
    {
        
        Console.WriteLine("입력받은 데이터는 " + input + " 입니다.");
        bool isint = int.TryParse(input, out num);
        if (isint )
        {
            Console.WriteLine("숫자입니다.");
        }
        else
        {
            Console.WriteLine("문자열입니다.");
        }
    }
}
