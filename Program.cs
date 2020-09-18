using System;
namespace Лаб_раб_Чуйков_ПрИ_102
{
 class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте!\n\nПожалуйста введите ваше имя:");
            string name = Console.ReadLine();
            Console.WriteLine("\nВведите вашу дату рождения (Пример: 07.06.2002)");
            string birth = Console.ReadLine();
            int[] months31 = { 1,3,5,7,8,10,12 };
            int[] months30 = {2,4,6,9,11};
            string numbers = "0123456789";
            int checkfev = 1;
            int checkdays = 0;
            int checkmonths = 0;
            int old = 0;
            int[] year = new int[4];
            int[] day = new int[2];
            int[] month = new int[2];
            for (int i = 0; i <= 9; i++) { if (birth[6] == numbers[i]) year[0]=i; }    //Преобразование строки года в число
            for (int i = 0; i <= 9; i++) { if (birth[7] == numbers[i]) year[1] = i; }
            for (int i = 0; i <= 9; i++) { if (birth[8] == numbers[i]) year[2] = i; }
            for (int i = 0; i <= 9; i++) { if (birth[9] == numbers[i]) year[3] = i; }

            for (int i = 0; i <= 9; i++) { if (birth[0] == numbers[i]) day[0] = i; }   //Преобразование строки дня в число
            for (int i = 0; i <= 9; i++) { if (birth[1] == numbers[i]) day[1] = i; }

            for (int i = 0; i <= 9; i++) { if (birth[3] == numbers[i]) month[0] = i; } //Преобразование строки месяца в число
            for (int i = 0; i <= 9; i++) { if (birth[4] == numbers[i]) month[1] = i; }


            int check31 = 0;
            int check30 = 0;
            for (int i = 0; i <= 6; i++) { if (month[0] * 10 + month[1] == months31[i]) check31 = 1; } // Проверка сколько в введенном месяце дней
            for (int i = 0; i <= 4; i++) { if (month[0] * 10 + month[1] == months30[i]) check30 = 1; }
            if (month[0] * 10 + month[1] == 2) {                       //Если февраль
                if ((year[0] * 1000 + year[1] * 100 + year[2] * 10 + year[3]) % 4 == 0 &&
                (year[0] * 1000 + year[1] * 100 + year[2] * 10 + year[3]) != 1900)
                { if (day[0] * 10 + day[1] >= 30 || day[0] * 10 + day[1] <= 0) checkfev = 0; }  //Если год вискосный
                else if (day[0] * 10 + day[1] >= 29 || day[0] * 10 + day[1] <= 0) checkfev = 0; //Если невисокосный
            }  

            if (check30 == 1 && day[0] * 10 + day[1] <= 30 && day[0] * 10 + day[1] >= 1) checkdays = 1; //Проверка входят ли дни 30-31 в [1;31||30]
            else if (check31 == 1 && day[0] * 10 + day[1] <= 31 && day[0] * 10 + day[1] >= 1) checkdays=1;

            if (month[0] * 10 + month[1] <= 12 && month[0] * 10 + month[1] >= 1) checkmonths = 1;

            if (month[0] * 10 + month[1] < 9) old = 2020 - (year[0] * 1000 + year[1] * 100 + year[2] * 10 + year[3]);
            else if (day[0] * 10 + day[1] <= 13 && month[0] * 10 + month[1] == 9) old = 2020 - (year[0] * 1000 + year[1] * 100 + year[2] * 10 + year[3]);
            else old = 2019 - (year[0] * 1000 + year[1] * 100 + year[2] * 10 + year[3]);

            if (checkfev == 1 && checkdays == 1 && checkmonths == 1) Console.WriteLine("\nПривет, " + name + ".\nВам " + old + " лет.\nПриятно познакомится!");
            else Console.WriteLine("Вы неправильно ввели дату рождения");




           //Console.WriteLine(checkfev+" "+ checkdays+" "+ checkmonths+" "+ check31+" "+ check30+" "+months30[0]+" "+ month[0] * 10 + month[1]);
            Console.ReadKey();
        }
    }
}
