# Simple Quiz Application
This is a simple command-line quiz application written in C# that loads quiz questions and answers from a text file. Users can answer multiple-choice questions, and the program will track their score. If the file is missing or empty, a set of sample questions will be generated automatically.
__________________
# Features

- Displays a list of quiz questions.
- Prompts the user for answers.
- Compares user input to the correct answers.
- Keeps track of the score.
- If the quiz file is missing or empty, it generates a default set of sample questions.
- __________________
# File Format
The quiz questions and answers are stored in a text file (quiz_questions.txt). Each line in the file should have a question and its correct answer, separated by a pipe (|) symbol. Example:

csharp

Copy code
What is the capital of France?|Paris
What is 2 + 2?|4
What is the chemical symbol for water?|H2O

If the quiz_questions.txt file is missing or empty, the application will automatically generate the following sample quiz:

- What is the capital of France? – Correct answer: Paris
- What is 2 + 2? – Correct answer: 4
- What is the chemical symbol for water? – Correct answer: H2O
__________________
# Prerequisites
- .NET SDK (6.0 or higher) installed.
- A text editor (such as Visual Studio or Visual Studio Code) for modifying the source code or quiz questions file.
__________________
# How to Run the Application
Clone the repository:

bash
Copy code
git clone https://github.com/marklourenco/quizproject.git
Open the project in Visual Studio or your preferred IDE.

Build and run the application:

- In Visual Studio, press Ctrl+F5 to start the application without debugging.
- Alternatively, use the command line:
bash
Copy code
dotnet run
Answer the questions in the console prompt. The program will tell you whether your answers are correct or incorrect and will display your final score at the end.
__________________
# Code Structure
## Classes and Methods
- IQuizItem: Interface defining two methods:
  - Display(): To display the quiz question.
  - CheckAnswer(string answer): To check if the user's answer is correct.
- QuizItem: Abstract class implementing the IQuizItem interface. It contains a Question property.
- AnswerableQuizItem: Derived class that represents a quiz item with an answer. This class overrides the Display() and CheckAnswer() methods to show the question and validate the user's answer.
- Program: Main entry point of the application. It loads quiz items from a file, displays them to the user, and keeps track of the score.

## Key Methods
- LoadQuizItems(filePath, quizItems): Loads quiz questions and answers from a file and adds them to a list of QuizItem objects.
- CreateSampleQuizFile(filePath): Creates a sample quiz file if the quiz file is missing or empty.
- Display(): Displays a question to the user.
- CheckAnswer(answer): Checks if the user's answer is correct.
__________________
# Example Output

kotlin
Copy code
Welcome to the Simple Quiz Application!
What is the capital of France?
Your answer: Paris
Correct!
What is 2 + 2?
Your answer: 4
Correct!
What is the chemical symbol for water?
Your answer: H2O
Correct!
Your final score is: 3/3
__________________
# License
This project is open source and available under the MIT License. See the LICENSE file for details.
