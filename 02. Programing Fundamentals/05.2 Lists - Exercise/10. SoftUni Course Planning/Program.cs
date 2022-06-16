using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "course start")
            {
                string[] comArgs = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string mainCommand = comArgs[0];
                string lessonTitle = comArgs[1];

                if (mainCommand == "Add" || mainCommand == "Exercise")
                {
                    if (!schedule.Contains(lessonTitle))
                    {
                        schedule.Add(lessonTitle);
                    }

                    if (mainCommand == "Exercise"
                        && !schedule.Contains($"{lessonTitle}-Exercise"))
                    {
                        AddExercise(schedule, lessonTitle);
                    }
                }
                else if (mainCommand == "Insert")
                {
                    int index = int.Parse(comArgs[2]);

                    if (!schedule.Contains(lessonTitle))
                    {
                        schedule.Insert(index, lessonTitle);
                    }
                }
                else if (mainCommand == "Remove")
                {
                    RemoveLesson(schedule, lessonTitle);
                }
                else if (mainCommand == "Swap")
                {
                    string secondLesson = comArgs[2];
                    if (schedule.Contains(lessonTitle) && schedule.Contains(secondLesson))
                    {
                        SwapLessons(schedule, lessonTitle, secondLesson);
                    }
                }

                input = Console.ReadLine();
            }

            int number = 1;

            foreach (var item in schedule)
            {
                Console.WriteLine($"{number}.{item}");
                number++;
            }
        }

        static List<string> AddExercise(List<string> schedule, string lessonTitle)
        {
            string exerciseName = lessonTitle + "-Exercise";
            int indexLesson = schedule.IndexOf(lessonTitle);
            schedule.Insert(indexLesson + 1, exerciseName);
            return schedule;
        }

        static List<string> SwapLessons(List<string> schedule, string firstLesson, string secondLesson)
        {
            int indexFirstLesson = schedule.IndexOf(firstLesson);
            int indexSecondLesson = schedule.IndexOf(secondLesson);

            schedule.Remove(firstLesson);
            schedule.Insert(indexSecondLesson, firstLesson);
            schedule.Remove(secondLesson);
            schedule.Insert(indexFirstLesson, secondLesson);

            string firstExercise = firstLesson + "-Exercise";

            if (schedule.Contains(firstExercise))
            {
                int indexFirstExercise = schedule.IndexOf(firstExercise);
                schedule.Remove(firstExercise);
                schedule.Insert(indexSecondLesson + 1, firstExercise);
            }

            string secondExercise = secondLesson + "-Exercise";

            if (schedule.Contains(secondExercise))
            {
                int indexSecondExercise = schedule.IndexOf(secondExercise);
                schedule.Remove(secondExercise);
                schedule.Insert(indexFirstLesson + 1, secondExercise);
            }

            return schedule;
        }

        static List<string> RemoveLesson(List<string> schedule, string lessonTitle)
        {
            string exercise = lessonTitle + "-Exercise";
            
            if (schedule.Contains(lessonTitle))
            {
                schedule.Remove(lessonTitle);
            }
            
            if (schedule.Contains(exercise))
            {
                schedule.Remove(exercise);
            }

            return schedule;
        }
    }
}
