using System;

Player player1 = new Player();
Item[] invenTory = new Item[20];
int num = 0;
Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");

AddItem(1, 0);  //테스트용 장비 지급
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
                Console.Clear();
                Inventory();
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
void Inventory()
{
    Console.WriteLine("-인벤토리-\n보유 중인 아이템을 확인합니다.\n");
    Console.WriteLine("\n[아이템 목록]\n");
    for (int i = 0; i < invenTory.Length; i++)
    {
        if (invenTory[i].name != null)
        {
            Console.Write("- ");
            if (invenTory[i].isEquip == true)   // 장착 시 [E] 글귀 생성
                Console.Write("[E]");
            Console.Write("{0}  ", invenTory[i].name);
            if (invenTory[i].armor == true)
                Console.Write("| 방어력 +{0} | ", invenTory[i].addPower);
            if (invenTory[i].weapon == true)
                Console.Write("| 공격력 +{0} | ", invenTory[i].addPower);
            Console.Write("{0}\n", invenTory[i].itemInfo);
        }
    }
    Console.WriteLine("\n1. 장착 관리\n2. 나가기");
    Console.WriteLine("\n원하시는 행동을 입력해주세요.");
    string input = Console.ReadLine();
    int num = 0;
    num = int.Parse(input);
    if (num >= 1 && num <= 2)
    {
        switch (num)
        {
            case 1:
                Console.Clear();
                EquipManage();
                // 장착 관리
                break;
            case 2:
                Console.Clear();
                StartScene();
                // 시작 화면
                break;
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("잘못된 입력입니다.\n");
        Inventory();
    }
}
void EquipManage()
{
    Console.WriteLine("-장착 관리-\n보유 중인 아이템을 관리할 수 있습니다.\n장착 또는 해체하고 싶은 장비에 해당하는 숫자를 입력하면 됩니다.\n");
    Console.WriteLine("\n[아이템 목록]\n");
    for (int i = 0; i < invenTory.Length; i++)
    {
        if (invenTory[i].name != null)
        {
            Console.Write("- {0}. ", i+1);
            if (invenTory[i].isEquip == true)   // 장착 시 [E] 글귀 생성
                Console.Write("[E]");
            Console.Write("{0}  ", invenTory[i].name);
            if (invenTory[i].armor == true)
                Console.Write("| 방어력 +{0} | ", invenTory[i].addPower);
            if (invenTory[i].weapon == true)
                Console.Write("| 공격력 +{0} | ", invenTory[i].addPower);
            Console.Write("{0}\n", invenTory[i].itemInfo);
        }
    }
    Console.WriteLine("\n0. 나가기");
    Console.WriteLine("\n원하시는 행동을 입력해주세요.");
    string input = Console.ReadLine();
    int num = 0;
    num = int.Parse(input);
    if (num >= 1 && invenTory[num - 1].name != null)
    {
        Console.Clear();
        invenTory[num - 1].isEquip = !invenTory[num - 1].isEquip;
        Console.WriteLine("{0} 장비를 장착 또는 해제했습니다.\n", invenTory[num - 1].name);
        EquipManage();
    }
    else if (num == 0)
    {
        Console.Clear();
        StartScene();
    }
    else
    {
        Console.Clear();
        Console.WriteLine("잘못된 입력입니다.\n");
        EquipManage();
    }
}
void AddItem(int itemCode, int invenNum)
{
    switch(itemCode)
    {
        case 1:
            invenTory[invenNum].name = "수련자 갑옷";
            invenTory[invenNum].armor = true;
            invenTory[invenNum].addPower = 5;
            invenTory[invenNum].itemInfo = "수련에 도움을 주는 갑옷입니다.";
            break;
        case 2:
            invenTory[invenNum].name = "무쇠 갑옷";
            invenTory[invenNum].armor = true;
            invenTory[invenNum].addPower = 9;
            invenTory[invenNum].itemInfo = "무쇠로 만들어진 튼튼한 갑옷입니다.";
            break;
        case 3:
            invenTory[invenNum].name = "스파르타 갑옷";
            invenTory[invenNum].armor = true;
            invenTory[invenNum].addPower = 15;
            invenTory[invenNum].itemInfo = "스파르타 전사들이 사용했다고 전해지는 전설의 갑옷입니다.";
            break;
        case 4:
            invenTory[invenNum].name = "낡은 검";
            invenTory[invenNum].weapon = true;
            invenTory[invenNum].addPower = 2;
            invenTory[invenNum].itemInfo = "쉽게 찾을 수 있는 낡은 검입니다.";
            break;
        case 5:
            invenTory[invenNum].name = "청동 도끼";
            invenTory[invenNum].weapon = true;
            invenTory[invenNum].addPower = 5;
            invenTory[invenNum].itemInfo = "옛날부터 전해내려오는 사용감있는 도끼입니다.";
            break;
        case 6:
            invenTory[invenNum].name = "스파르타의 창";
            invenTory[invenNum].weapon = true;
            invenTory[invenNum].addPower = 9;
            invenTory[invenNum].itemInfo = "스파르타의 전사들이 사용했다고 전해지는 전설의 창입니다.";
            break;
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
struct Item()
{
    public string name;
    public bool isEquip;    // 장착여부
    public bool armor;      // 무기여부
    public bool weapon;     // 방어구여부
    public int addPower;    // (무기면 공격력, 방어구면 방어력) 추가 상승치
    public string itemInfo;
}






