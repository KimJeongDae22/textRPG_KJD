using UnityEngine;

public class Operator : MonoBehaviour
{
    public int ten = 10;

    string name = "chad";
    int year = 2025;
    void OnEnable ()
    {
        float ten_Divide = ten / 6;
        Debug.Log(ten_Divide);
    }
    void SaChickYeonSan()
    {
        int ten_Plus = ten + 7;
        int ten_Minus = ten - 3;
        int ten_Multiply_int = ten * 2;
        float ten_Multiply_float = ten * 1.5f;
        float ten_Divide = ten / 3;
        int ten_Rest = ten % 4;

        Debug.Log("int ten = " + ten);
        Debug.Log("7 더하기 : " + ten_Plus);
        Debug.Log("3 빼기 : " + ten_Minus);
        Debug.Log("2 곱하기 : " + ten_Multiply_int);
        Debug.Log("1.5 곱하기 : " + ten_Multiply_float);
        Debug.Log("3 나누기 : " + ten_Divide);
        Debug.Log("4 로 나누고 나머지 : " + ten_Rest);
    }
    void StringCalculation()
    {
        string introduce = "안녕하세요. 제 이름은 \"" + name + "\" 입니다."; // 문자열에 큰따옴표(")를 넣기 위해서는 \를 앞에 붙여줘야 한다.
        string thisyear = "올해는 '" + year + "년' 입니다.";

        Debug.Log(introduce);
        Debug.Log(thisyear);
    }
    void LogicCalculation()
    {
        bool result_1 = ten == 10;  // ten 이 10 이랑 같다
        bool result_2 = ten != 11;  // ten 이 10 이랑 같지 않다
        bool result_3 = ten < 20;   // ten 이 20보다 작다
        bool result_4 = ten > 5;    // ten 이 5보다 크다

        Debug.Log(result_1);
        Debug.Log(result_2);
        Debug.Log(result_3);
        Debug.Log(result_4);
    }
}
