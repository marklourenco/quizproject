// Mark Jeremy Lourenco Rojas
// Chin Tang

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimpleQuizApp
{
    // interface for quiz items
    public interface IQuizItem
    {
        void Display();
        bool CheckAnswer(string answer);
    }

    // base class for quiz items
    public abstract class QuizItem : IQuizItem
    {
        // get the question string
        public string Question { get; set; }

        // create quiz item
        protected QuizItem(string question)
        {
            Question = question;
        }

        public abstract void Display();
        public abstract bool CheckAnswer(string answer);
    }

    // derived class for answerable quiz items
    public class AnswerableQuizItem : QuizItem
    {
        // get/set answer
        public string Answer { get; set; }

        // question, answer and set answer
        public AnswerableQuizItem(string question, string answer) : base(question)
        {
            Answer = answer;
        }
        // display the question
        public override void Display()
        {
            Console.WriteLine(Question);
        }
        // check if the given answer is correct
        public override bool CheckAnswer(string answer)
        {
            return string.Equals(Answer, answer, StringComparison.OrdinalIgnoreCase);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // create list of quiz questions and answers
            List<QuizItem> quizItems = new List<QuizItem>();
            // where questions are stored
            string filePath = "quiz_questions.txt";

            // load quiz items from file
            LoadQuizItems(filePath, quizItems);

            Console.WriteLine("Welcome to the Simple Quiz Application!");

            // keep score
            int score = 0;

            // go through each question
            foreach (var item in quizItems)
            {
                item.Display();
                Console.Write("Your answer: ");
                string userAnswer = Console.ReadLine();
                Console.Clear();

                if (item.CheckAnswer(userAnswer))
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                }
            }
            // final score
            Console.WriteLine($"Your final score is: {score}/{quizItems.Count}");
        }

        // get quiz questions/answers from file
        static void LoadQuizItems(string filePath, List<QuizItem> quizItems)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    foreach (var line in lines)
                    {
                        var parts = line.Split('|');
                        if (parts.Length == 2)
                        {
                            quizItems.Add(new AnswerableQuizItem(parts[0], parts[1]));
                        }
                        else
                        {
                            Console.WriteLine("Invalid line format in quiz file.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Quiz file not found. Creating a new file with sample questions.");
                    // create a new file with sample questions if file empty or not there
                    CreateSampleQuizFile(filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading quiz items: {ex.Message}");
            }
        }
        // create sample questions if file empty or not there
        static void CreateSampleQuizFile(string filePath)
        {
            try
            {
                var sampleQuestions = new List<string>
                {
                    "What is the capital of France?|Paris",
                    "What is 2 + 2?|4",
                    "What is the chemical symbol for water?|H2O"
                };

                File.WriteAllLines(filePath, sampleQuestions);
                Console.WriteLine("Sample quiz questions have been created. Restart Game.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating the sample quiz file: {ex.Message}");
            }
        }
    }
}
