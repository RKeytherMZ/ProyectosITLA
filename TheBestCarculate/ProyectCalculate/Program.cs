//Rubby Keyther Martinez Zorrilla 2024-2036

List<decimal> typedNumbers = new List<decimal>();

decimal result = 0;
int typedOption = 1;
int wantToContinue = 0;
bool running = true;


Console.WriteLine("This is the best calculator");

while (running)
{
    DisplayHeader();

    try
    {
        typedOption = Convert.ToInt32(Console.ReadLine());

        if (typedOption == 5)
        { running = false; }
        else
        {

            typedNumbers.Clear();
            Console.WriteLine("Please Type the first number");
            typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));

            Console.WriteLine("Please Type the second number");
            typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));


            wantToContinue = 0;
            while (wantToContinue != 2)
            {
                Console.WriteLine("you want to continue inserting numbers? 1. Yes, 2. No");
                wantToContinue = Convert.ToInt32(Console.ReadLine());
                if (wantToContinue == 1)
                {
                    Console.WriteLine("Please Type another number");
                    typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));
                }
            }

            switch (typedOption)
            {
                case 1:
                    {
                        result = AddList(typedNumbers);
                    }
                    break;
                case 2:
                    result = SubstractNumber(typedNumbers);

                    break;
                case 3:

                    result = MultiplyNumbers(typedNumbers);

                    break;
                case 4:

                    result = DivideNumbers(typedNumbers);

                    break;
                default:
                    result = 0;
                    break;
            }

            Console.WriteLine($"The Result of the operation is:{result}");


        }
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine($"you can not divide by zero: {ex.Message}");
    }
    catch (ArithmeticException ex)
    {
        Console.WriteLine($"you can not divide by zero: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"You need to choose a correct option: {ex.Message}");
    }
    finally
    {
        Console.WriteLine("Closing Db Conection");
    }

}

static decimal AddList(List<decimal> typedNumbers)
{
    decimal result = 0;
    foreach (decimal typedNumber in typedNumbers)
    {
        result += typedNumber;
    }
    return result;
}


static decimal SubstractNumber(List<decimal> typedNumbers)
{
    decimal result = typedNumbers[0]; 
    for (int i = 1; i < typedNumbers.Count; i++)
    {
        result -= typedNumbers[i];
    }
    return result;


}

static decimal MultiplyNumbers(List<decimal> typedNumbers)
{
    decimal result = typedNumbers[0]; 
    for (int i = 1; i < typedNumbers.Count; i++)
    {
        result *= typedNumbers[i];
    }
    return result;


}

static decimal DivideNumbers(List<decimal> typedNumbers)
{
    decimal result = typedNumbers[0]; 
    for (int i = 1; i < typedNumbers.Count; i++)
    {
        if (typedNumbers[i] == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }
        result /= typedNumbers[i];
    }
    return result;


}

static void DisplayHeader()
{
    Console.WriteLine("Please Type the option number than you want");
    Console.WriteLine("---------------------------------------");
    Console.WriteLine("1. Sum, \n2. Substract,  \n3. Multiplication,  \n4. Division,  \n5. Exit");
}