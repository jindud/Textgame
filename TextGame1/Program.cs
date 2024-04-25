using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace TextGame1
{
    public class Player
    {
        public int Level { get; set; }
        public string Name { get; }
        public string Class { get; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }
        public Player()
        {
            Level = 1;
            Class = "전사";
            Attack = 10;
            Defence = 5;
            Health = 100;
            Gold = 1500;
        }
    }
    public class Item
    {
        public string Name;
        public int Price;
        public int Attack;
        public int Defence;
        public int ItemType;
        public bool PurchaseItem = false;
        public bool EquipmentItem = false;

        public string Text;

        public Item()
        {

        }
        public Item(string newName, int newPrice, int weaponAttack, int armorDefence, int itemType, string newText)
        {
            Name = newName;
            Price = newPrice;
            Attack = weaponAttack;
            Defence = armorDefence;
            ItemType = itemType;
            Text = newText;
        }
    }


    internal class Program
    {
        static List<Item> inventory = new List<Item>();        

        static List<Item> shopInventory = new List<Item>();

        static Player player;

        static void Main(string[] args)
        {
            GameStart();
        }
        static void GameStart()
        {
            player = new Player();

            shopInventory.Add(new Item("낡은 검", 600, 2, 0, 1, "쉽게 볼 수 있는 낡은 검 입니다."));
            shopInventory.Add(new Item("청동 도끼", 1500, 5, 0, 1, "어디선가 사용됐던거 같은 도끼입니다."));
            shopInventory.Add(new Item("스파르타의 창", 3000, 7, 0, 1, "스파르타의 전사들이 사용했다는 전설의 창입니다."));
            shopInventory.Add(new Item("수련자의 갑옷", 1000, 0, 5, 0, "수련에 도움을 주는 갑옷입니다."));
            shopInventory.Add(new Item("무쇠갑옷", 2000, 0, 7, 0, "무쇠로 만들어져 튼튼한 갑옷입니다."));
            shopInventory.Add(new Item("스파르타의 갑옷", 3500, 0, 15, 0, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다."));

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("\n");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string input = Console.ReadLine();

            while (true)
            {
                if (input == "1" || input == "2" || input == "3")
                {
                    switch (input)
                    {
                        case "1":
                            Status();
                            break;

                        case "2":
                            Inventory();
                            break;

                        case "3":
                            Store();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    Console.Write(">> ");
                    input = Console.ReadLine();
                }
            }
        }
        static void Status()
        {
            Console.Clear();
            Player player = new Player();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine($"lv. {player.Level} ");
            Console.WriteLine($"chad ({player.Class})");
            Console.WriteLine($"공격력 : {player.Attack} +");
            Console.WriteLine($"방어력 : {player.Defence}");
            Console.WriteLine($"체력 : {player.Health}");
            Console.WriteLine($"gold : {player.Gold}\n");
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string input = Console.ReadLine();

            while (true)
            {
                if (input == "0")
                {
                    Console.Clear();
                    GameStart();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                    Console.Write(">> ");
                    input = Console.ReadLine();
                }
            }
        }
        static void Inventory()
        {
            Console.Clear();
            
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]\n");
            Console.WriteLine("1. 장착 관리");
            
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string input = Console.ReadLine();

            while (true)
            {
                if (input == "1")
                {
                    Console.Clear();
                    InventoryManagement();
                }
                else if (input == "0")
                {
                    Console.Clear();
                    GameStart();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                    Console.Write(">> ");
                    input = Console.ReadLine();
                }
            }
        }
        static void InventoryManagement()
        {
            Console.WriteLine("인벤토리 - 장착관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]");
            foreach(Item item in inventory)
            {
                Console.WriteLine($"{item.Name}      | 공격력 +{item.Attack}  | 방어력 +{item.Defence}  | {item.Text}\n");
            }
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하는 행동을 입력해주세요.");
            Console.Write(">> ");
            string input = Console.ReadLine();

            while (true)
            {
                if(input == "0")
                {
                    Console.Clear();
                    Inventory();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                    Console.Write(">> ");
                    input = Console.ReadLine();
                }
            }
        }
        static void Store()
        {
            Console.Clear();

            string s = "";

            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold}\n");
            Console.WriteLine("[아이템 목록");

            foreach (Item item in shopInventory)
            {
                if (item.PurchaseItem)
                {
                    s = "구매 완료";
                }
                else
                {
                    s= item.Price.ToString();
                }
                Console.WriteLine($"{item.Name}      | 공격력 +{item.Attack}  | 방어력 +{item.Defence}  | {item.Text} | {s}");
            }

            Console.WriteLine("\n1. 아이템 구매");
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string input = Console.ReadLine();

            

            while (true)
            {
                if(input == "1")
                {
                    Console.Clear();
                    StoreShop();
                }
                else if (input == "0")
                {
                    Console.Clear();
                    GameStart();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                    Console.Write(">> ");
                    input = Console.ReadLine();
                }
            }
        }
        static void StoreShop()
        {
            Item items = new Item();
            string s = "";
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold}\n");
            Console.WriteLine("[아이템 목록]");

            foreach (Item item in shopInventory)
            {
                if (item.PurchaseItem)
                {
                    s = "구매 완료";
                }
                else
                {
                    s = item.Price.ToString();
                }
                Console.WriteLine($"{item.Name}      | 공격력 +{item.Attack}  | 방어력 +{item.Defence}  | {item.Text} | {s}");
            }

            Console.WriteLine("\n");
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string input = Console.ReadLine();

            bool outRoof = true;

            while(outRoof)
            {
                if (input == "0")
                {
                    Console.Clear();
                    Store();
                }
                else if (input == "1")
                {
                    if (player.Gold >= shopInventory[0].Price)
                    {
                        player.Gold -= shopInventory[0].Price;
                        inventory.Add(shopInventory[0]);
                        shopInventory[0].PurchaseItem = true;
                        Console.WriteLine("구매를 완료했습니다.");

                        outRoof = false;
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다.");
                        Console.ReadLine();
                        outRoof = false;
                    }
                }
                else if (input == "2")
                {
                    if (player.Gold >= shopInventory[1].Price)
                    {
                        player.Gold -= shopInventory[1].Price;
                        inventory.Add(shopInventory[1]);
                        Console.WriteLine("구매를 완료했습니다.");
                        outRoof = false;
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다.");
                        Console.ReadLine();
                        outRoof = false;
                    }
                }
                else if (input == "3")
                {
                    if (player.Gold >= shopInventory[2].Price)
                    {
                        player.Gold -= shopInventory[2].Price;
                        inventory.Add(shopInventory[2]);
                        Console.WriteLine("구매를 완료했습니다.");
                        outRoof = false;
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다.");
                        Console.ReadLine();
                        outRoof = false;
                    }
                }
                else if (input == "4")
                {
                    if (player.Gold >= shopInventory[3].Price)
                    {
                        player.Gold -= shopInventory[3].Price;
                        inventory.Add(shopInventory[3]);
                        Console.WriteLine("구매를 완료했습니다.");
                        outRoof = false;
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다.");
                        Console.ReadLine();
                        outRoof = false;
                    }
                }
                else if (input == "5")
                {
                    if (player.Gold >= shopInventory[4].Price)
                    {
                        player.Gold -= shopInventory[4].Price;
                        inventory.Add(shopInventory[4]);
                        Console.WriteLine("구매를 완료했습니다.");
                        outRoof = false;
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다.");
                        Console.ReadLine();
                        outRoof = false;
                    }
                }
                else if (input == "6")
                {
                    if (player.Gold >= shopInventory[5].Price)
                    {
                        player.Gold -= shopInventory[5].Price;
                        inventory.Add(shopInventory[5]);
                        Console.WriteLine("구매를 완료했습니다.");
                        outRoof = false;
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다.");
                        Console.ReadLine();
                        outRoof = false;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                    Console.Write(">> ");
                    input = Console.ReadLine();
                }
            }

        }
    }
}
