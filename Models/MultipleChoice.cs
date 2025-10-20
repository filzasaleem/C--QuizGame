namespace QuizGame;

public class MultipleChoice : Question
{
    public override int Ask()
    {
        Console.WriteLine($"{Text} \n");
        for (int i = 0; i < Options.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {Options[i]} \n");
        }
        int userAnswer;
        while (true)
        {
            Console.Write("Enter your choice number: \n");
            var input = Console.ReadLine();

            if (int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= Options.Count)
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a valid number.\n");

        }
        return userAnswer;
    }
        
    public override bool CheckAnswer(int answer)
        {
            return answer == CorrectAnswer;
            
        }

    
}
