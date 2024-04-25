using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RtanTextGame
{
    internal class Program
    {
        class Player //플레이러 스텟 클래스
        {
            public int level = 1; //레벨
            public string name = "김경찬"; //이름
            public string job = "전사";
            public int atk = 10; //공격력
            public int def = 5; //방어력
            public int life = 100; //체력
            public int gold = 10000; //골드
            public string[] playerItem = new string[] { };//플레이어가 소지한 장비를 저장
        }

        class StoreItem  //상점에 파는 물건 표시
        {
            public String[] item = new string[] {
            "수련자 갑옷     | 방어력 +5     | 수련에 도움을 주는 갑옷입니다.                    ",
            "무쇠갑옷        | 방어력 +9     | 무쇠로 만들어져 튼튼한 갑옷입니다.                ", 
            "스파르타의 갑옷 | 방어력 +15    | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다. ", 
            "낡은 검         | 공격력 +2     | 쉽게 볼 수 있는 낡은 검입니다.                    ", 
            "청동 도끼       | 공격력 +5     | 어디선가 사용됐던거 같은 도끼입니다.              ", 
            "스파르타의 창   | 공격력 +7     | 스파르타의 전사들이 사용했다는 전설의 창입니다.   "};    

            public String[] itemPrice = new string[] { "1000", "2000", "3500", "600", "1500", "2500" };
        }

        
        
        static void Main(string[] args)
        {
            while (true)
            {
                Player player = new Player();
                
                Console.WriteLine("\n------------------------------------------------------\n");
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");//게임 시작 화면
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");//게임 시작 화면

                Console.WriteLine("1. 상태 보기");//마을에서 할 수 있는 행동_1
                Console.WriteLine("2. 인벤토리");//마을에서 할 수 있는 행동_2
                Console.WriteLine("3. 상점");//마을에서 할 수 있는 행동_3

                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");//어떤 행동을 할 건지 질문
                int action1 = int.Parse(Console.ReadLine());//행동 선택

                if (action1 == 1)
                {
                    CharacterStatus(); //스테이터스 메소드 호출
                }
                else if (action1 == 2)
                {
                    CharacterInventory(); //인벤토리 메소드 호출
                }
                else if (action1 == 3)
                {
                    CharacterGoToStore(); //상점 메소드 호출
                }
                else //선택지 외 행동을 했을 시 
                {
                    Console.WriteLine("\n잘못된 입력입니다.\n다시 입력해주세요.\n");
                }
            }
        }


        static void CharacterStatus() //캐릭터 능력치 메소드
        {
            Player player = new Player();
            Console.WriteLine("\n------------------------------------------------------\n");
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

            Console.WriteLine("Lv. {0}", player.level);
            Console.WriteLine("{0} ({1})", player.name, player.job);
            Console.WriteLine("공격력 : {0}", player.atk);
            Console.WriteLine("방어력 : {0}", player.def);
            Console.WriteLine("체  력 : {0}", player.life);
            Console.WriteLine("Gold : {0} G\n", player.gold);

            Console.WriteLine("0. 나가기\n");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int action2 = int.Parse(Console.ReadLine());

            if (action2 == 0)
            {
                return;
            }
            else
            {
                Console.WriteLine("\n잘못된 입력입니다.\n다시 입력해주세요.\n");
            }
        }

        static void CharacterInventory() //인벤토리 메소드
        {
            Player player = new Player();
            Console.WriteLine("\n------------------------------------------------------\n");
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

            Console.WriteLine("\n[아이템 목록]\n");

            if (player.playerItem.Length >= 1) // 장비가 1개 이상 있을 경우에만 출력
            {
                for (int i = 0; i < player.playerItem.Length; i++)
                {
                    Console.WriteLine("- {1}", player.playerItem[i]);
                }
            }

            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기\n");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int action3 = int.Parse(Console.ReadLine());

            if (action3 == 0)
            {
                return;
            }
            else if (action3 == 1)
            {
                Console.WriteLine("\n------------------------------------------------------\n");
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

                Console.WriteLine("\n[아이템 목록]\n");

                if (player.playerItem.Length >= 1) // 장비가 1개 이상 있을 경우에만 출력
                {
                    for (int i = 0; i < player.playerItem.Length; i++)
                    {
                        Console.WriteLine("- {0}, {1}", i+1, player.playerItem[i]);
                    }
                }

                Console.WriteLine("\n0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int action3_1 = int.Parse(Console.ReadLine());

                if (action3_1 == 0)
                {
                    CharacterInventory(); //나가기를 선택하면 인벤토리로 돌아간다.
                }
                else if(player.playerItem.Length >=1 && action3_1<player.playerItem.Length)
                {

                }
                else
                {
                    Console.WriteLine("\n잘못된 입력입니다.\n다시 입력해주세요.\n");
                }
            }
            else
            {
                Console.WriteLine("\n잘못된 입력입니다.\n다시 입력해주세요.\n");
            }
        }


        static void CharacterGoToStore() // 상점 메소드
        {
            Player player = new Player();
            StoreItem item = new StoreItem();
            Dictionary<string, string> store = new Dictionary<string, string>();
            for(int i=0; i<item.item.Length; i++)
            {
                store.Add(item.item[i], item.itemPrice[i]+" G");
            }

            Console.WriteLine("\n------------------------------------------------------\n");
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G", player.gold);

            Console.WriteLine("\n[아이템 목록]");
            foreach(KeyValuePair<String, String> pair in store)
            {
                Console.WriteLine(pair.Key + " | " + pair.Value);
            }

            Console.WriteLine("\n1. 아이템 구매");
            Console.WriteLine("0. 나가기\n");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int action4 = int.Parse(Console.ReadLine());

            if (action4 == 0)
            {
                return;
            }
            else if(action4 == 1) // 아이템 구매를 눌렀을 시
            {
                Console.WriteLine("\n------------------------------------------------------\n");
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.WriteLine("[보유 골드]");
                Console.WriteLine("{0} G", player.gold);

                Console.WriteLine("\n[아이템 목록]");
                foreach(KeyValuePair < String, String > pair in store)
                {
                    int i = 1;
                    i++;
                    Console.WriteLine("- {0} " + pair.Key + " | " + pair.Value, i);
                }

                Console.WriteLine("\n0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int action4_1 = int.Parse(Console.ReadLine());

                if (action4_1 == 0) // 나가기를 누르면 상점으로 돌아간다.
                {
                    CharacterGoToStore();
                }
                else if (action4_1>0 && action4_1 <= item.item.Length) // 구매할 무기를 선택했을 경우
                {
                        if (player.gold > int.Parse(item.itemPrice[action4_1 - 1])) // 플레이어의 금액이 아이템 값보다 높을 경우
                        {
                            Console.WriteLine("구매를 완료했습니다.");
                            Console.WriteLine("- {0} G", item.itemPrice[action4_1 - 1]);
                            store.Remove(item.item[action4_1 - 1]);
                            store.Add(item.item[action4_1 - 1], "구매 완료");
                            

                            CharacterGoToStore();
                        }
                        else
                        {
                            Console.WriteLine("Gold가 부족합니다. ");
                            CharacterGoToStore();
                        }
                }
                else
                {
                    Console.WriteLine("\n잘못된 입력입니다.\n다시 입력해주세요.\n");
                }
            }
            else
            {
                Console.WriteLine("\n잘못된 입력입니다.\n다시 입력해주세요.\n");
            }
        }
      
    }
}
