using System;

Player player1 = new Player();
int num = 0;
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
        Console.Clear();
    }
    else
    {
        Console.Clear();
        Console.WriteLine("잘못된 입력입니다.\n");
        StartNaming();
    }
}
void StartScene()
{
    Console.WriteLine("환영합니다! {0} 님. 이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n", player1.name);
    Console.WriteLine("1. 상태보기 \n2. 인벤토리 \n3. 상점 \n");
    Console.WriteLine("원하시는 행동을 입력해주세요.");
    string input = Console.ReadLine();
    num = int.Parse(input);
    if (num >= 1 && num <= 3)
    {
        switch (num)
        {
            case 1:
                Console.Clear();
                Information();
                // 상태보기
                break;
            case 2:
                // 인벤토리
                break;
            case 3:
                // 상점
                break;
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("잘못된 입력입니다.\n");
        StartScene();
    }
}
void Information()
{
    Console.WriteLine("-상태보기-\n캐릭터의 정보가 표시됩니다.\n");

    Console.WriteLine("Lv.{0}", player1.level.ToString("D2"));
    Console.WriteLine("이름 : {0} ( {1} )", player1.name, player1.jop);
    Console.WriteLine("공격력 : {0}", player1.atkPower);
    Console.WriteLine("방어력 : {0}", player1.armPower);
    Console.WriteLine("체력 : {0}", player1.hp);
    Console.WriteLine("골드 : {0}", player1.gold);

    Console.WriteLine("\n0. 나가기");
    Console.WriteLine("\n원하시는 행동을 입력해주세요.");
    string input = Console.ReadLine();
    int num = 1;
    num = int.Parse(input);
    if (num == 0)
    {
        Console.Clear();
        StartScene();
    }
    else
    {
        Console.Clear();
        Console.WriteLine("잘못된 입력입니다.\n");
        Information();
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






