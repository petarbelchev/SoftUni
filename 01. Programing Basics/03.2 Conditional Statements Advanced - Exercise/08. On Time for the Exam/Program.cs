using System;

namespace _08._On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minExam = int.Parse(Console.ReadLine());
            int hourArrive = int.Parse(Console.ReadLine());
            int minArrive = int.Parse(Console.ReadLine());

            int examInMin = (hourExam * 60) + minExam;
            int arriveInMin = (hourArrive * 60) + minArrive;

            bool onTime = examInMin - arriveInMin <= 30 && examInMin - arriveInMin >= 0;
            bool early = examInMin - arriveInMin > 30;
            bool late = examInMin - arriveInMin < 0;

            int difference = Math.Abs(examInMin - arriveInMin);

            if (onTime)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{difference} minutes before the start");
            }
            else if (early)
            {
                Console.WriteLine("Early");
                
                if (difference >= 1 && difference < 60)
                {
                    Console.WriteLine($"{difference} minutes before the start");
                }
                else if (difference >= 60)
                {
                    int hourLate = difference / 60;
                    int minLate = difference % 60;
                    if (minLate < 10)
                    {
                        Console.WriteLine($"{hourLate}:0{minLate} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hourLate}:{minLate} hours before the start");
                    }

                }
            }
            else if (late)
            {
                Console.WriteLine("Late");

                if (difference >= 1 && difference < 60)
                {
                    Console.WriteLine($"{difference} minutes after the start");
                }
                else if (difference >= 60)
                {
                    int hourLate = difference / 60;
                    int minLate = difference % 60;
                    if (minLate < 10)
                    {
                        Console.WriteLine($"{hourLate}:0{minLate} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hourLate}:{minLate} hours after the start");
                    }

                }
            }

        }
    }
}
