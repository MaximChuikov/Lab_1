using System;
namespace Лаб1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте!\n\nПожалуйста, введите ваше имя:");
            string name = Console.ReadLine();

            bool a;
            DateTime today = DateTime.Today;  // Сегодняшняя дата


            do
            {
                Console.WriteLine("\nВведите вашу дату рождения (Пример: 07.06.2002)");
                string birth = Console.ReadLine();

                int[] months31 = { 1, 3, 5, 7, 8, 10, 12 }; // Месяца с 31 днем 
                int[] months30 = { 2, 4, 6, 9, 11 }; // Месяца с 30 днями
                string numbers = "0123456789"; //Алфавит для чисел

                bool checkfev = true;
                bool checkdays = false;   // Ввод переменных чеков для дня, месяца, года
                bool checkmonths = false;
                int old = 0;  // Ввод значения возраста

                int[] year = new int[4];
                int[] day = new int[2];     // Массивы отведенные для ввода дня, месяца и года
                int[] month = new int[2];

                int counterofnum = 0; // обнуление счетчика чисел

                if (birth.Length == 10)  // Если длина даты рождения соответствует стандарту

                {
                    for (int i = 0; i <= 9; i++) { if (birth[6] == numbers[i]) year[0] = i; else counterofnum++; }    //Преобразование строки года в число
                    for (int i = 0; i <= 9; i++) { if (birth[7] == numbers[i]) year[1] = i; else counterofnum++; }
                    for (int i = 0; i <= 9; i++) { if (birth[8] == numbers[i]) year[2] = i; else counterofnum++; } // counternum++ счетчик цифр, которые не соответствуют введенному
                    for (int i = 0; i <= 9; i++) { if (birth[9] == numbers[i]) year[3] = i; else counterofnum++; } // числу, если введена буква или иной символ, то в данной строке
                                                                                                                   // к каунту прибавится 10 и условие ниже не выполнится


                    for (int i = 0; i <= 9; i++) { if (birth[0] == numbers[i]) day[0] = i; else counterofnum++; }   //Преобразование строки дня в число
                    for (int i = 0; i <= 9; i++) { if (birth[1] == numbers[i]) day[1] = i; else counterofnum++; }



                    for (int i = 0; i <= 9; i++) { if (birth[3] == numbers[i]) month[0] = i; else counterofnum++; } //Преобразование строки месяца в число
                    for (int i = 0; i <= 9; i++) { if (birth[4] == numbers[i]) month[1] = i; else counterofnum++; }
                }


                int theday = day[0] * 10 + day[1];  // Число для дня
                int themonth = month[0] * 10 + month[1];  // Число для месяца
                int theyear = year[0] * 1000 + year[1] * 100 + year[2] * 10 + year[3]; // Число для года

                bool check31 = false;  // ввод переменных чеков для 30 или 31 дня в месяце
                bool check30 = false;


                for (int i = 0; i <= 6; i++) { if (themonth == months31[i]) check31 = true; } // Проверка сколько в введенном месяце дней
                for (int i = 0; i <= 4; i++) { if (themonth == months30[i]) check30 = true; }
                if (themonth == 2)
                {                       //Если февраль
                    if (theyear % 4 == 0 &&
                    theyear != 1900)
                    { if (theday >= 30 || theday <= 0) checkfev = false; }  //Если год вискосный
                    else if (theday >= 29 || theday <= 0) checkfev = false; //Если невисокосный
                }

                if (check30 == true && theday <= 30 && theday >= 1) checkdays = true; //Проверка входят ли дни 30-31 в [1;31||30]
                else if (check31 == true && theday <= 31 && theday >= 1) checkdays = true;

                if (themonth <= 12 && themonth >= 1) checkmonths = true;  // Проверка принадлежит ли месяц [1;12]

                bool checkyear = false;
                if (theyear <= today.Year) checkyear = true;   // Проверка < ли введенный год, чем текущий

                if (themonth < today.Month) old = today.Year - theyear;
                else if (theday <= today.Day && themonth == 9) old = today.Year - theyear; // Сравнение с текущей датой
                else old = today.Year - 1 - theyear;

                string let = "лет";                 // Заголовок для определения склонения
                string god = "год";
                string goda = "года";
                string sklon = "лет";

                if (old % 10 >= 5 || old % 10 == 0) sklon = let; // Если десяток равен 0 или больше 5
                else if ((old / 10) % 10 == 1 && old % 10 >= 1 && old % 10 <= 4) sklon = let; //Если второй десяток равен 1 и первый 1-4
                else if ((old / 10) % 10 >= 2 && old % 10 >= 2) sklon = goda;   //Если второй десяток >2 и первый больше 2
                else if ((old / 10) % 10 == 0 && old % 10 >= 2) sklon = goda; // случаи 102-104 или 2-4
                else if (old % 10 == 1) sklon = god;

                a = false; // Обнуление переменной для защиты от "дурака"

                if (checkfev == true && checkdays == true && checkmonths == true && checkyear == true && old >= 0 && counterofnum == 72)   // Проверка всех чеков
                { Console.WriteLine("\nПривет, " + name + ".\nВам " + old + " " + sklon + ".\nПриятно познакомиться!"); a = true; }  // Вывод возраста
                else { Console.WriteLine("Вы неправильно ввели дату рождения"); a = false; } // если ДР неправильная, то A ложно и цикл повторяется

            } while (a == false);


            Console.ReadKey();
        }
    }
}
