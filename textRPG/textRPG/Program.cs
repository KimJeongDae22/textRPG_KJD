struct Player()
{
    public int level = 1;
    public string name = "char";
    public string jop = "전사";
    public int atkPower = 10;
    public int addAtkPower = 0;
    public int armPower = 5;
    public int addArmPower = 0;
    public int hp = 100;
    public int gold = 150000;
}
struct Item()
{
    public string name;
    public bool isEquip;    // 장착여부
    public bool armor;      // 무기여부
    public bool weapon;     // 방어구여부
    public int addPower;    // (무기면 공격력, 방어구면 방어력) 추가 상승치
    public string itemInfo; // 장비 설명
    public int price;       // 가격
}
class TextRPG
{
    static void Main(string[] args)
    {
        Player player1 = new Player();
        Item[] invenTory = new Item[20];
        bool[] shop_Soldout = new bool[6];
        bool get_BalMoong = false; // 히든 아이템 획득 여부
        int num = 0;
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");

        //AddItem(7, 6);      // 발뭉 획득!  //테스트용 장비 지급
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
            Console.WriteLine("1. 상태보기 \n2. 인벤토리 \n3. 상점 \n4. 던전가기 \n5. 휴식하기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            string input = Console.ReadLine();
            bool isnum = int.TryParse(input, out num);
            if (isnum)
            {
                if (num >= 1 && num <= 5)
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
                            Console.Clear();
                            Shop();
                            // 상점
                            break;
                        case 4:
                            Console.Clear();
                            Dungeon();
                            // 던전
                            break;
                        case 5:
                            Console.Clear();
                            Rest();
                            // 휴식
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
            Console.Write("공격력 : {0}", player1.atkPower + player1.addAtkPower);
            Console.WriteLine("  +[{0}]", player1.addAtkPower);
            Console.Write("방어력 : {0}", player1.armPower + player1.addArmPower);
            Console.WriteLine("  +[{0}]", player1.addArmPower);
            Console.WriteLine("체력 : {0}", player1.hp);
            Console.WriteLine("골드 : {0}", player1.gold);

            Console.WriteLine("\n0. 나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            string input = Console.ReadLine();
            bool isnum = int.TryParse(input, out num);
            if (isnum)
            {
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
            bool isnum = int.TryParse(input, out num);
            if (isnum)
            {
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
                    Console.Write("- {0}. ", i + 1);
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
            bool isnum = int.TryParse(input, out num);
            if (isnum)
            {
                if (num >= 1 && invenTory[num - 1].name != null)
                {
                    Console.Clear();
                    invenTory[num - 1].isEquip = !invenTory[num - 1].isEquip;
                    if (invenTory[num - 1].isEquip == true)
                    {
                        if (invenTory[num - 1].weapon == true)
                            player1.addAtkPower += invenTory[num - 1].addPower;
                        if (invenTory[num - 1].armor == true)
                            player1.addArmPower += invenTory[num - 1].addPower;
                    }
                    else
                    {
                        if (invenTory[num - 1].weapon == true)
                            player1.addAtkPower -= invenTory[num - 1].addPower;
                        if (invenTory[num - 1].armor == true)
                            player1.addArmPower -= invenTory[num - 1].addPower;
                    }
                    Console.WriteLine("{0} 장비를 {1}했습니다.\n", invenTory[num - 1].name, invenTory[num - 1].isEquip ? "장착" : "해제");
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
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.\n");
                EquipManage();
            }
        }
        void Shop()
        {
            Console.WriteLine("-상점-\n필요한 아이템을 구매할 수 있는 상점입니다.\n");
            Console.WriteLine("\n[보유 골드]\n{0} G\n", player1.gold);
            Console.WriteLine("\n[아이템 목록]\n");
            int[] price = new int[6];
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.Write("- 수련자 갑옷       | 방어력 +5   | 수련에 도움을 주는 갑옷입니다.                             ");
                        price[i] = 1000;
                        break;
                    case 1:
                        Console.Write("- 무쇠 갑옷         | 방어력 +9   | 무쇠로 만들어져 튼튼한 갑옷입니다.                         ");
                        price[i] = 2000;
                        break;
                    case 2:
                        Console.Write("- 스파르타의 갑옷   | 방어력 +15  | 스파르타의 전사들이 사용했다고 전해지는 전설의 갑옷입니다. ");
                        price[i] = 3500;
                        break;
                    case 3:
                        Console.Write("- 낡은 검           | 공격력 +2   | 쉽게 찾을 수 있는 낡은 검입니다.                           ");
                        price[i] = 600;
                        break;
                    case 4:
                        Console.Write("- 청동 도끼         | 공격력 +5   | 옛날부터 전해내려오는 사용감있는 도끼입니다.               ");
                        price[i] = 1500;
                        break;
                    case 5:
                        Console.Write("- 스파르타의 창     | 공격력 +9   | 스파르타의 전사들이 사용했다고 전해지는 전설의 창입니다.   ");
                        price[i] = 3000;
                        break;
                }

                if (shop_Soldout[i] == false)
                    Console.WriteLine("{0} G", price[i]);
                else
                    Console.WriteLine("구매 완료");
            }
            Console.WriteLine("\n1. 아이템 구매\n0. 나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            string input = Console.ReadLine();
            bool isnum = int.TryParse(input, out num);
            if (isnum)
            {
                if (num == 1)
                {
                    Console.Clear();
                    BuyItem();
                    // 아이템 구매창 이동
                }
                else if (num == 0)
                {
                    Console.Clear();
                    StartScene();
                    // 시작 화면
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.\n");
                    Shop();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.\n");
                Shop();
            }
        }
        void BuyItem()
        {
            Console.WriteLine("-상점_아이템 구매-\n필요한 아이템을 구매할 수 있는 상점입니다.\n");
            Console.WriteLine("\n[보유 골드]\n{0} G\n", player1.gold);
            Console.WriteLine("\n[아이템 목록]\n");
            int[] price = new int[6];
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.Write("- {0} 수련자 갑옷       | 방어력 +5   | 수련에 도움을 주는 갑옷입니다.                             ", i + 1);
                        price[i] = 1000;
                        break;
                    case 1:
                        Console.Write("- {0} 무쇠 갑옷         | 방어력 +9   | 무쇠로 만들어져 튼튼한 갑옷입니다.                         ", i + 1);
                        price[i] = 2000;
                        break;
                    case 2:
                        Console.Write("- {0} 스파르타의 갑옷   | 방어력 +15  | 스파르타의 전사들이 사용했다고 전해지는 전설의 갑옷입니다. ", i + 1);
                        price[i] = 3500;
                        break;
                    case 3:
                        Console.Write("- {0} 낡은 검           | 공격력 +2   | 쉽게 찾을 수 있는 낡은 검입니다.                           ", i + 1);
                        price[i] = 600;
                        break;
                    case 4:
                        Console.Write("- {0} 청동 도끼         | 공격력 +5   | 옛날부터 전해내려오는 사용감있는 도끼입니다.               ", i + 1);
                        price[i] = 1500;
                        break;
                    case 5:
                        Console.Write("- {0} 스파르타의 창     | 공격력 +9   | 스파르타의 전사들이 사용했다고 전해지는 전설의 창입니다.   ", i + 1);
                        price[i] = 3000;
                        break;
                }
                if (shop_Soldout[i] == false)
                    Console.WriteLine("{0} G", price[i]);
                else
                    Console.WriteLine("구매 완료");
            }
            Console.WriteLine("\n0. 나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            string input = Console.ReadLine();
            bool isnum = int.TryParse(input, out num);
            if (isnum)
            {
                if (num >= 1 && num <= 6)
                {
                    if (shop_Soldout[num - 1] == true)
                    {
                        Console.Clear();
                        Console.WriteLine("이미 구매한 아이템입니다.\n");
                        BuyItem();
                    }
                    else if (player1.gold < price[num - 1])
                    {
                        Console.Clear();
                        Console.WriteLine("골드가 부족합니다.\n");
                        BuyItem();
                    }
                    else
                    {
                        int emptyInvenNum = 0;
                        for (int i = 0; i < invenTory.Length; i++)
                        {
                            if (invenTory[i].name == null)
                            {
                                emptyInvenNum = i;
                                break;
                            }
                        }
                        AddItem(num, emptyInvenNum);
                        player1.gold -= price[num - 1];
                        shop_Soldout[num - 1] = true;
                        Console.Clear();
                        Console.WriteLine("{0} 구매를 완료했습니다.\n", invenTory[emptyInvenNum].name);
                        BuyItem();
                    }

                }
                else if (num == 0)
                {
                    Console.Clear();
                    Shop();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.\n");
                    BuyItem();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.\n");
                BuyItem();
            }
        }
        void Dungeon()
        {
            Console.WriteLine("-던전 입장-\n이곳에서 들어갈 수 있는 던전이 표시됩니다.  [현재 방어력 : {0}]\n", player1.armPower + player1.addArmPower);
            int[] dungeonArmPower = new int[3];
            string[] dungeonName = new string[3];
            for (int i = 1; i <= 3; i++)
            {
                switch (i)
                {
                    case 1:
                        Console.WriteLine("{0}. 꼬마 슬라임 둥지       | 방어력 +5 이상 권장", i);
                        dungeonArmPower[i - 1] = 5;
                        dungeonName[i - 1] = "꼬마 슬라임 둥지";
                        break;
                    case 2:
                        Console.WriteLine("{0}. 미확인생명체 발견지역  | 방어력 +12 이상 권장", i);
                        dungeonArmPower[i - 1] = 12;
                        dungeonName[i - 1] = "미확인생명체 발견지역";
                        break;
                    case 3:
                        Console.WriteLine("{0}. 용이 점령한 황무지     | 방어력 +20 이상 권장", i);
                        dungeonArmPower[i - 1] = 20;
                        dungeonName[i - 1] = "용이 점령한 황무지";
                        break;
                }
            }
            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            string input = Console.ReadLine();
            bool isnum = int.TryParse(input, out num);
            if (isnum)
            {
                if (num >= 1 && num <= 3)
                {
                    if (player1.hp > 0)
                    {
                        bool dungeonClear;
                        Random random = new Random();
                        int clearPercent = random.Next(99);
                        if (player1.armPower + player1.addArmPower >= dungeonArmPower[num - 1])
                        {
                            dungeonClear = true;
                        }
                        else
                        {
                            if (clearPercent < 40)
                                dungeonClear = true;
                            else
                                dungeonClear = false;
                        }
                        Console.Clear();
                        ResultDungeon(dungeonClear, dungeonName[num - 1], dungeonArmPower[num - 1]);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("체력이 부족합니다.\n");
                        Dungeon();
                    }
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
                    Dungeon();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.\n");
                Dungeon();
            }
        }
        void ResultDungeon(bool dungeonClear, string dungeonName, int dungeonArmPower)
        {
            // Dungeon 메서드에서 받은 던전 클리어 여부, 던전 이름, 던전 권장 방어력이 매개 변수로써 존재한다.

            Console.WriteLine("- {0} -\n", dungeonClear ? "던전 클리어 성공!" : "던전 클리어 실패...");
            Console.WriteLine("{0}", dungeonClear ? $"축하합니다!!\n{dungeonName} 던전을 클리어 하였습니다.\n"
                : $"아쉽습니다...\n{dungeonName} 던전을 클리어하지 못했습니다.\n");
            Console.WriteLine("[탐험 결과]");
            Random random = new Random();
            int downHp = 0;
            int addGold = 0;
            downHp = random.Next(20, 36) - (player1.armPower + player1.addArmPower - dungeonArmPower);
            if (downHp < 0)
                downHp = 0;
            // 기본 체력 감소량 계산 완료
            if (dungeonClear == true)
            {

                if (dungeonName == "꼬마 슬라임 둥지")
                    addGold = 1000;
                if (dungeonName == "미확인생명체 발견지역")
                    addGold = 1700;
                if (dungeonName == "용이 점령한 황무지")
                {
                    addGold = 2500;
                    if (get_BalMoong == false)
                    {
                        int hiddenWeapon = random.Next(99);
                        if (hiddenWeapon < 10)
                        {
                            for (int i = 0; i < invenTory.Length; i++)
                            {
                                if (invenTory[i].name == null)
                                {
                                    AddItem(7, i);      // 발뭉 획득!
                                    get_BalMoong = true;
                                    Console.WriteLine("\n히든 무기 \"멸룡검 발뭉\" 을 획득하였습니다!!\n");
                                    break;
                                }
                            }
                        }
                    }
                }
                addGold += addGold * (random.Next(player1.atkPower, player1.atkPower * 2 + 1)) / 100;
            }
            else
            {
                downHp /= 2;    // 실패 시 체력 감소량 절반
                addGold = 0;

            }
            Console.WriteLine("체력 {0} -> {1}", player1.hp, player1.hp - downHp);
            Console.WriteLine("골드 {0} -> {1}", player1.gold, player1.gold + addGold);
            player1.hp -= downHp;
            player1.gold += addGold;
            Console.WriteLine("\n0. 나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            string input = Console.ReadLine();
            bool isnum = int.TryParse(input, out num);
            if (isnum)
            {
                if (num == 0)
                {
                    Console.Clear();
                    Dungeon();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.\n");
                    ResultDungeon(dungeonClear, dungeonName, dungeonArmPower);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.\n");
                ResultDungeon(dungeonClear, dungeonName, dungeonArmPower);
            }
        }
        void AddItem(int itemCode, int invenNum)
        {
            switch (itemCode)
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
                case 7:
                    invenTory[invenNum].name = "멸룡검 발뭉";
                    invenTory[invenNum].weapon = true;
                    invenTory[invenNum].addPower = 30;
                    invenTory[invenNum].itemInfo = "단 하나, 용을 멸하는 것만 생각한다.";
                    break;
            }
        }
        void Rest()
        {
            Console.WriteLine("-휴식하기-\n500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {0} G)\n", player1.gold);
            Console.WriteLine("\n1. 휴식하기 \n0. 나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            string input = Console.ReadLine();
            bool isnum = int.TryParse(input, out num);
            if (isnum)
            {
                if (num >= 0 && num <= 1)
                {
                    switch (num)
                    {
                        case 0:
                            Console.Clear();
                            StartScene();
                            // 시작 화면
                            break;
                        case 1:
                            if (player1.gold >= 500)
                            {
                                if (player1.hp < 100)
                                {
                                    Console.Clear();
                                    Console.WriteLine("휴식을 완료하였습니다.\n");
                                    player1.hp = 100;
                                    player1.gold -= 500;
                                    Rest();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("이미 체력이 가득찬 상태입니다.\n");
                                    Rest();
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("골드가 부족합니다.\n");
                                Rest();
                            }
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.\n");
                    Rest();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.\n");
                Rest();
            }
        }
    }
}






