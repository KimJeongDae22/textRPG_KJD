Player player1;

Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");

StartNaming();
StartScene();
void StartNaming()
{
    Console.WriteLine("당신의 이름을 설정해주세요 (3~10자): ");
    string inputName = Console.ReadLine();
    if (inputName.Length >= 3 && inputName.Length <= 10)
    {
        player1.name = inputName;
    }
    else
    {
        Console.WriteLine("잘못된 입력입니다.\n");
        StartNaming();
    }
}
void StartScene()
{
    int num = 0;
    Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
    Console.WriteLine("1. 상태보기 \n2. 인벤토리 \n3. 상점 \n");
    Console.WriteLine("원하시는 행동을 입력해주세요");
    string input = Console.ReadLine();
    num = int.Parse(input);
    if (num >= 1 && num <= 3)
    {
        if (num == 1)   // 상태보기
        {

        }
        if (num == 2)   // 인벤토리
        {

        }
        if (num == 3)   // 상점
        {

        }
    }
    else
    {
        Console.WriteLine("잘못된 입력입니다.\n");
        StartScene();
    }
}
struct Player()
{
    public int level = 1;
    public string name = "char";
    public string jop = "전사";
    public int atkPower = 10;
    public int armPower = 5;
    public int hp = 100;
    public int gold = 1500;
}




