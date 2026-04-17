using System;
using Myproject;

namespace Myproject
{
    enum E_QqType
    {
        online,
        mobile,
        business
    }
    enum E_ZhiYe
    {
        zhanshi,
        fashi,
        tanke
    }
    enum E_Skil
    {
        火球术,
        传送,

    }
    struct XueYuan
    {
        public string name;
        public string sex;
        public int age;
        public int banji;
        public string zhuanye;

        public XueYuan(string name, string sex, int age, int banji, string zhuanye)
        {
            this.name = name;
            this.sex = sex;
            this.age = age;
            this.banji = banji;
            this.zhuanye = zhuanye;
        }
        public void Speak(string name, string sex, int age, int banji, string zhuanye)
        {
            Console.WriteLine("我的名字是{0}，我性{1}，我今年{2}岁，我在{3}班级，我是{4}专业", name, sex, age, banji, zhuanye);
        }


    }
    struct JvXing
    {
        public float a;
        public float b;
        public float area;
        public float pr;
        public JvXing(float a, float b)
        {
            this.a = a;
            this.b = b;
            area = a * b;
            pr = 2 * (a + b);

        }
        public void WriteInfo()
        {
            Console.WriteLine("矩形的面积为{0}，矩形的周长为{1}", area, pr);
        }
    }

    struct Gamer
    {
        public E_Skil jineng;
        public E_ZhiYe zhiye;
        public string name;

        public Gamer(string name)
        {

            this.name = name;
            this.jineng = E_Skil.火球术;
            this.zhiye = E_ZhiYe.zhanshi;
        }
        public void Write()
        {
            //Console.WriteLine("请输入姓名");

            Console.WriteLine("请选择职业：1.战士2.法师3.坦克");
            int a = int.Parse(Console.ReadLine() ?? string.Empty);
            E_ZhiYe zhiYe = (E_ZhiYe)(a - 1);

            switch (zhiYe)
            {
                case E_ZhiYe.zhanshi:
                    Console.WriteLine("{0}选择了战士职业释放了{1}技能。", name, E_Skil.传送);
                    break;
                case E_ZhiYe.fashi:
                    Console.WriteLine("{0}选择了法师职业释放了{1}技能。", name, E_Skil.火球术);
                    break;
            }
        }


    }

    struct Monster
    {
        public string name;
        public int atk;
        public Monster(string name)
        {

            this.name = name;
            Random r = new Random();
            atk = r.Next(10, 30);
        }
        public void Atk()
        {
            Console.WriteLine("{0}的攻击力是{1}", name, atk);
        }

    }

}
class Program
{
    #region HanShu
    static int CheMax(int a, int b)
    {
        // if (a > b)
        // {
        //     return a;
        // }
        // else
        // {
        //     return b;
        // }
        return a > b ? a : b;
    }



    static float[] Yuan(float r)
    {

        float[] f = new float[2];
        f[0] = 3.14f * r * r;
        f[1] = 2 * 3.14f * r;
        return f;
    }



    static void Sum(int[] arr)
    {
        if (arr.Length == 0)
        {
            Console.WriteLine("shuzu bueng wei 0");
            return;
        }
        int sum = 0;
        int max = arr[0];
        int min = arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
            if (max < arr[i])
            {
                max = arr[i];
            }
            if (min > arr[i])
            {
                min = arr[i];
            }

        }
        float avg = (float)sum / arr.Length;

        Console.WriteLine("数组总和为{0}，平均数为{1}，最大值为{2}，最小值为{3}.", sum, avg, max, min);


    }



    static bool IsPrimeNumer(int n)
    {
        if (n <= 1)
        {
            return false;
        }

        if (n == 2)
        {
            return true;
        }
        if (n % 2 == 0)
            return false;

        for (int i = 3; i < n; i += 2)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }


    static bool RunNian(int year)
    {
        bool isrunian = false;
        if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
        {
            isrunian = true;
        }
        return isrunian;
    }



    static bool DengLu(string name, string password, ref string info)
    {
        if (name == "lvhongxin")
        {

            if (password == "ayanami0")
            {
                info = "登录成功";
                return true;
            }
            else
            {
                info = "密码错误";
                return false;
            }
        }

        else
        {
            info = "用户名错误";
            return false;
        }
    }


    static void SumAndAvg(params int[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        float avg = (float)sum / arr.Length;
        Console.WriteLine("最大值是{0}，平均数是{1}", sum, avg);
    }



    static void JiOuHe(params int[] arr)
    {
        int jSum = 0;
        int oSum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 0)
            {
                oSum += arr[i];
            }
            else
            {
                jSum += arr[i];
            }
        }
        Console.WriteLine("偶数和为{0}，奇数和为{1}", oSum, jSum);
    }


    static int GetMax(int a, int b)
    {
        // int max = a;
        // if (a > b)
        // {
        //     max = a;
        // }
        // else
        // {
        //     max = b;
        // }
        // return max;
        return a > b ? a : b;
    }

    static float GetMax(float a, float b)
    {
        // float max = a;
        // if (a > b)
        // {
        //     max = a;
        // }
        // else
        // {
        //     max = b;
        // }
        // return max;
        return a > b ? a : b;
    }


    static void ArrMax(params int[] arr)
    {
        if (arr.Length == 0)
        {
            Console.WriteLine("请输入一个数字");
            return;
        }
        int max = arr[0];
        int min = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (max < arr[i])
            {
                max = arr[i];
            }
            if (min > arr[i])
            {
                min = arr[i];
            }
        }
        Console.WriteLine("最大值为{0}，最小值为{1}", max, min);
    }

    static void ArrMax(params float[] arr)
    {
        if (arr.Length == 0)
        {
            Console.WriteLine("请输入一个数字");
            return;
        }
        float max = arr[0];
        float min = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (max < arr[i])
            {
                max = arr[i];
            }
            if (min > arr[i])
            {
                min = arr[i];
            }
            Console.WriteLine("最大值为{0}，最小值为{1}", max, min);
        }
    }


    static void ArrMax(params double[] arr)
    {
        if (arr.Length == 0)
        {
            Console.WriteLine("请输入一个数字");
            return;
        }
        double max = arr[0];
        double min = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (max < arr[i])
            {
                max = arr[i];
            }
            if (min > arr[i])
            {
                min = arr[i];
            }
            Console.WriteLine("最大值为{0}，最小值为{1}", max, min);
        }
    }



    static void DaYin(int a)
    {
        if (a > 10)
        {
            return;
        }
        Console.WriteLine(a);
        ++a;
        DaYin(a);
    }

    static int JieCheng(int a)
    {
        if (a == 1)
        {
            a = 1;
            Console.WriteLine(a);
            return 1;
        }
        if (a > 1)
        {
            return a * JieCheng(a - 1);
        }
        return 1;
    }


    static int Fun3(int num)
    {
        if (num == 1)
        {
            return JieCheng(1);
        }

        return JieCheng(num) + Fun3(num - 1);
    }

    static int ZhuGan(int m, int day)
    {
        if (day == 0)
        {
            return m;
        }

        return ZhuGan(m / 2, day - 1);


    }

    static bool Fun4(int num)
    {
        bool result = (num <= 200) && Fun4(num + 1);
        Console.WriteLine(num);
        return true;
    }


    #endregion


    static void Main(string[] args)
    {
        // Monster[] monsters = new Monster[10];
        // for (int i = 0; i < monsters.Length; i++)
        // {
        //     string name = "小怪兽" + i;
        //     monsters[i] = new Monster(name);
        // }
        // for (int i = 0; i < monsters.Length; i++)
        // {
        //     monsters[i].Atk();
        // }


        // Gamer wanjia1 = new Gamer("张三");
        // wanjia1.Write();



        // XueYuan X1 = new XueYuan();
        // XueYuan X2 = new XueYuan();
        // X1.Speak("路士明", "男", 18, 2, "数字媒体技术");
        // X2.Speak("房东", "男", 18, 2, "数字媒体技术");

        // JvXing J1 = new JvXing(4, 5);
        // J1.WriteInfo();


        // Console.WriteLine("请输入用户名");
        // string name = Console.ReadLine() ?? string.Empty;
        // Console.WriteLine("请输入密码");
        // string password = Console.ReadLine() ?? string.Empty;
        // string info = "";
        // bool isLogin = DengLu(name, password, ref info);
        // Console.WriteLine(info);





        //int[] arr = { 2, 3, 1, 5, 4, 7, 8, 6, 9, 10 };

        // for (int m = 0; m < arr.Length; m++)
        // {
        //     //第一步 申明一个中间商 来记录索引
        //     //每一轮开始 默认第一个都是极值
        //     int index = 0;
        //     //第二步
        //     //依次比较
        //     // -m的目的 是排除上一轮 已经放好位置的数
        //     for (int n = 1; n < arr.Length - m; n++)
        //     {
        //         //第三步
        //         //找出极值（最大值）
        //         if (arr[index] < arr[n])
        //         {
        //             index = n;
        //         }
        //     }

        //     //第四步 放入目标位置
        //     //Length - 1 - 轮数
        //     //如果当前极值所在位置 就是目标位置 那就没必要交换了
        //     if (index != arr.Length - 1 - m)
        //     {
        //         int temp = arr[index];
        //         arr[index] = arr[arr.Length - 1 - m];
        //         arr[arr.Length - 1 - m] = temp;
        //     }
        // }

        // for (int i = 0; i < arr.Length; i++)
        // {
        //     Console.Write(arr[i] + " ");
        // }


        // for (int m = 0; m < arr.Length - 1; m++)
        // {

        //     int index = 0;
        //     for (int i = 1; i < arr.Length - m; i++)
        //     {
        //         if (arr[index] < arr[i])
        //         {
        //             index = i;
        //         }
        //         if (arr[index] != arr[arr.Length - 1 - m])
        //         {
        //             int temp = arr[index];
        //             arr[index] = arr[arr.Length - 1 - m];
        //             arr[arr.Length - 1 - m] = temp;
        //         }
        //     }
        // }






        // for (int i = 0; i < arr.Length; i++)
        // {
        //     Console.Write(arr[i] + " ");
        // }





        // try
        // {
        //     Console.WriteLine("请分别输入两个数比较大小");
        //     string str = Console.ReadLine();
        //     int a = int.Parse(str);
        //     str = Console.ReadLine();
        //     int b = int.Parse(str);
        //     str = a >= b ? "较大的数是" + a : "较大的数是" + b;
        //     Console.WriteLine(str);
        // }
        // catch
        // {
        //     Console.WriteLine("请输入数字");
        // }





        // int str = '吕';
        // int str2 = '宏';
        // int str3 = '新';

        // Console.WriteLine(str);
        // Console.WriteLine(str2);
        // Console.WriteLine(str3);
        // Console.WriteLine("{0}, {1}, {2}", str, str2, str3);
        // Console.WriteLine("****************************************");




        // float a = (int)1.23f;
        // Console.WriteLine(a);
        // int b = int.Parse("123");
        // Console.WriteLine(b);
        // string c = 123.ToString();
        // Console.WriteLine(c);
        // string str = Convert.ToString("123");
        // Console.WriteLine(str);
        // Console.WriteLine("****************************************");





        // char c1 = (char)24069;
        // Console.WriteLine(c1);
        // char c2 = Convert.ToChar(24069);
        // Console.WriteLine(c2);
        // Console.WriteLine("请输入姓名");
        // string str = Console.ReadLine();
        // Console.WriteLine("请输入语文数学英语成绩");
        // string str2 = Console.ReadLine();
        // int a = int.Parse(str2);
        // Console.WriteLine(a);
        // Console.WriteLine(str);





        // Console.WriteLine("****************************************");





        // string name = "吕宏新";
        // Console.WriteLine("我的名字是" + name);
        // Console.WriteLine("我的名字是{0}", name);

        // string name = "吕宏新";
        // string age = Convert.ToString("18");
        // Console.WriteLine("我的名字是{0}，年龄是{1}", name, age);

        // Console.WriteLine(35 << 4);
        // Console.WriteLine("请输入qq在线状态，（online1，mobile2，business3）");
        // int a = int.Parse(Console.ReadLine());
        // E_QqType type = (E_QqType)a - 1;
        // switch (type)
        // {
        //     case E_QqType.online:
        //         Console.WriteLine("在线");
        //         break;
        //     case E_QqType.mobile:
        //         Console.WriteLine("手机");
        //         break;
        //     case E_QqType.business:
        //         Console.WriteLine("商务");
        //         break;
        // }\
        // Console.WriteLine("请输入职业，战士1，法师2，坦克3");
        // int b = int.Parse(Console.ReadLine());
        // E_ZhiYe E_ZhiYe = (E_ZhiYe)b - 1;
        // switch (E_ZhiYe)
        // {
        //     case
        //     E_ZhiYe.zhanshi:
        //         Console.WriteLine("你选择的职业是战士(HP高，攻击高，防御低)");
        //         break;
        //     case
        //         E_ZhiYe.fashi:
        //         Console.WriteLine("你选择的职业是法师(HP低，攻击高，防御低)");
        //         break;
        //     case
        //         E_ZhiYe.tanke:
        //         Console.WriteLine("你选择的职业是坦克(HP高，攻击低，防御高)");
        //         break;
        // }






        // int[] arr = new int[100];
        // for (int i = 0; i < arr.Length; i++)
        // {
        //     arr[i] = i;
        //     Console.WriteLine(arr[i]);
        // }
        // int[] arr2 = new int[100];
        // for (int i = 0; i < arr2.Length; i++)
        // {
        //     arr2[i] = arr[i] * 2;
        //     Console.WriteLine(arr2[i]);

        // }
        // Console.WriteLine("****************************************");
        // int[] arr3 = new int[10];
        // Random r = new Random();
        // for (int i = 0; i < arr3.Length; i++)
        // {
        //     arr3[i] = r.Next(0, 100);
        //     Console.WriteLine(arr3[i]);

        // }






        // int[] arr4 = { 5, 2, 1, 6, 3, 8, 9, 7 };
        // int max = arr4[0];  // 假设第一个是最大值
        // int min = arr4[0];  // 假设第一个是最小值

        // for (int j = 1; j < arr4.Length; j++)
        // {
        //     if (arr4[j] > max)  // 如果当前元素比max大
        //     {
        //         max = arr4[j];   // 更新max
        //     }
        // }
        // for (int j = 1; j < arr4.Length; j++)
        // {
        //     if (arr4[j] < min)  // 如果当前元素比min小
        //     {
        //         min = arr4[j];   // 更新min
        //     }
        // }
        // Console.WriteLine("最大值是{0},最小值是{1}", max, min);






        // int[] arr5 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        // int temp = arr5[0];
        // for (int i = 0; i < arr5.Length / 2; i++)
        // {
        //     arr5[i] = arr5[arr5.Length - 1 - i];
        //     arr5[arr5.Length - 1 - i] = temp;
        //     temp = arr5[i + 1];

        // }
        // for (int i = 0; i < arr5.Length; i++)
        // {
        //     Console.WriteLine(arr5[i]);
        // }






        // int[] arr6 = { -5, 3, -8, 0, 7 }; //new int[10];
        // //Random r = new Random();
        // for (int i = 0; i < arr6.Length; i++)
        // {
        //     // arr6[i] = r.Next(-10, 10);
        //     if (arr6[i] < 0)
        //     {
        //         arr6[i]--;
        //     }
        //     else if (arr6[i] == 0)
        //     {
        //         break;
        //     }
        //     else if (arr6[i] > 0)
        //     {
        //         arr6[i]++;
        //     }
        // }
        // for (int i = 0; i < arr6.Length; i++)
        // {
        //     Console.WriteLine(arr6[i]);
        // }
        // int[] arr7 = new int[10];






        // try
        // {


        //     int sum = 0;
        //     float avg = 00.0f;
        //     Console.WriteLine("请输入数学成绩");
        //     for (int i = 0; i < arr7.Length; i++)
        //     {
        //         string? input = Console.ReadLine();
        //         arr7[i] = int.Parse(input ?? "0");
        //         sum += arr7[i];
        //     }
        //     avg = (float)sum / arr7.Length;
        //     int max = arr7[0];  // 假设第一个是最大值
        //     int min = arr7[0];  // 假设第一个是最小值
        //     for (int j = 1; j < arr7.Length; j++)
        //     {
        //         if (arr7[j] > max)  // 如果当前元素比max大
        //         {
        //             max = arr7[j];   // 更新max
        //         }
        //     }
        //     for (int j = 1; j < arr7.Length; j++)
        //     {
        //         if (arr7[j] < min)  // 如果当前元素比min小
        //         {
        //             min = arr7[j];   // 更新min
        //         }
        //     }
        //     Console.WriteLine("最大值是{0},最小值是{1},平均值是{2}", max, min, avg);

        // }
        // catch
        // {
        //     Console.WriteLine("请输入数字");
        // }
        // string[] arr8 = new string[25];
        // for (int i = 0; i < arr8.Length; i++)
        // {
        //     arr8[i] = i % 2 == 0 ? "■" : "☐";
        // }
        // for (int i = 0; i < arr8.Length; i++)
        // {
        //     if (i % 5 == 0 && i != 0)
        //     {
        //         Console.WriteLine();
        //     }
        //     Console.Write(arr8[i]);
        // }
        // {





        // }
        // int[,] array = new int[10, 10];
        // int count = 1;
        // for (int i = 0; i < array.GetLength(0); i++)
        // {
        //     for (int j = 0; j < array.GetLength(1); j++)
        //     {
        //         array[i, j] = count;
        //         count++;
        //         Console.WriteLine(array[i, j]);
        //     }
        // }





        // int[,] array2 = new int[4, 4];
        // Random r = new Random();
        // for (int i = 0; i < array2.GetLength(0); i++)
        // {
        //     for (int j = 0; j < array2.GetLength(1); j++)
        //     {
        //         array2[i, j] = r.Next(0, 100);

        //     }
        // }
        // for (int i = 0; i < array2.GetLength(0); i++)
        // {
        //     for (int j = 0; j < array2.GetLength(1); j++)
        //     {
        //         if (j > i)
        //         {
        //             array2[i, j] = 0;

        //         }
        //         Console.WriteLine(array2[i, j]);

        //     }
        // }






        // int[,] array3 = new int[3, 3];
        // int sum = 0;
        // Random r = new Random();
        // for (int i = 0; i < array3.GetLength(0); i++)
        // {
        //     for (int j = 0; j < array3.GetLength(1); j++)
        //     {
        //         array3[i, j] = r.Next(0, 100);
        //         Console.WriteLine(array3[i, j]);
        //     }
        // }
        // for (int i = 0; i < array3.GetLength(0); i++)
        // {
        //     for (int j = 0; j < array3.GetLength(1); j++)
        //     {
        //         if (i == j)
        //         {
        //             sum += array3[i, j];
        //         }
        //     }
        // }
        // Console.WriteLine("主对角线元素的和是{0}", sum);








        // int[,] array4 = new int[5, 5];
        // Random r = new Random();
        // for (int i = 0; i < array4.GetLength(0); i++)
        // {
        //     for (int j = 0; j < array4.GetLength(1); j++)
        //     {
        //         array4[i, j] = r.Next(0, 500);

        //     }
        // }
        // int max = array4[0, 0];  // 假设第一个元素是最大值
        // int maxrow = 0; // 记录最大值所在的行索引
        // int maxcol = 0; // 记录最大值所在的列索引
        // for (int i = 0; i < array4.GetLength(0); i++)
        // {
        //     for (int j = 0; j < array4.GetLength(1); j++)
        //     {
        //         if (array4[i, j] > max)
        //         {
        //             max = array4[i, j];
        //             maxrow = i; // 更新最大值所在的行索引
        //             maxcol = j; // 更新最大值所在的列索引
        //         }
        //     }
        // }
        // Console.WriteLine("数组中的最大值是{0}，位于第{1}行第{2}列", max, maxrow, maxcol);


        // int[,] array5 = new int[,]{
        //                           {0,0,0,0,0},
        //                           {0,0,0,0,0},
        //                           {0,1,0,0,0},
        //                           {0,0,1,0,0},
        //                           {0,0,0,0,0},
        //                                      };
        // bool[] row = new bool[5];
        // bool[] col = new bool[5];
        // for (int i = 0; i < array5.GetLength(0); i++)
        // {
        //     for (int j = 0; j < array5.GetLength(1); j++)
        //     {
        //         if (array5[i, j] == 1)
        //         {
        //             row[i] = true;
        //             col[j] = true;

        //         }
        //     }
        // }
        // for (int i = 0; i < array5.GetLength(0); i++)
        // {
        //     for (int j = 0; j < array5.GetLength(1); j++)
        //     {
        //         if (row[i] || col[j])
        //         {
        //             array5[i, j] = 1;

        //         }
        //         Console.Write(array5[i, j] + "");
        //     }
        //     Console.WriteLine();

        // }


        int[] a = new int[20];
        Random r = new Random();
        for (int i = 0; i < a.Length; i++)
        {
            a[i] = r.Next(0, 101);
        }
        // 冒泡排序（降序）
        for (int j = 0; j < a.Length - 1; j++)
        {
            for (int i = 0; i < a.Length - 1 - j; i++)
            {
                // 降序：前面的数要更大，必要时交换相邻元素
                if (a[i] < a[i + 1])
                {
                    int temp = a[i];
                    a[i] = a[i + 1];
                    a[i + 1] = temp;
                }
            }
        }
        int[] b = new int[20];
        for (int i = 0; i < b.Length; i++)
        {
            b[i] = r.Next(0, 101);
        }

        // 选择排序（降序）
        for (int i = 0; i < b.Length - 1; i++)
        {
            int maxIndex = i; // 当前位置要放“最大的数”
            for (int j = i + 1; j < b.Length; j++)
            {
                if (b[j] > b[maxIndex])
                {
                    maxIndex = j;
                }
            }

            if (maxIndex != i)
            {
                int temp = b[i];
                b[i] = b[maxIndex];
                b[maxIndex] = temp;
            }
        }

    }
}