using System;

class Level2Programs
{
    static void Main()
    {
        EmployeeBonus();
        YoungestAndTallest();
        LargestAndSecondLargest();
        LargestAndSecondLargestUpdated();
        ReverseNumber();
        CalculateBMI();
        CalculateBMIUsing2DArray();
        StudentMarks();
        StudentMarksUsing2DArray();
        DigitFrequency();
    }

    static void EmployeeBonus()
    {
        int employeeCount = 10;
        double[] salary = new double[employeeCount];
        double[] years = new double[employeeCount];
        double[] bonus = new double[employeeCount];
        double[] newSalary = new double[employeeCount];

        double totalOldSalary = 0;
        double totalBonus = 0;
        double totalNewSalary = 0;

        for (int index = 0; index < employeeCount; index++)
        {
            Console.Write("Enter salary of employee " + (index + 1) + ": ");
            if (!double.TryParse(Console.ReadLine(), out salary[index]) || salary[index] <= 0)
            {
                Console.WriteLine("Invalid salary.");
                index--;
                continue;
            }

            Console.Write("Enter years of service: ");
            if (!double.TryParse(Console.ReadLine(), out years[index]) || years[index] < 0)
            {
                Console.WriteLine("Invalid years of service.");
                index--;
                continue;
            }
        }

        for (int index = 0; index < employeeCount; index++)
        {
            double bonusRate;

            if (years[index] > 5)
                bonusRate = 0.05;
            else
                bonusRate = 0.02;

            bonus[index] = salary[index] * bonusRate;
            newSalary[index] = salary[index] + bonus[index];

            totalOldSalary += salary[index];
            totalBonus += bonus[index];
            totalNewSalary += newSalary[index];
        }

        Console.WriteLine("\nEmployee Details");

        for (int index = 0; index < employeeCount; index++)
        {
            Console.WriteLine("Employee " + (index + 1));
            Console.WriteLine("Old Salary: " + salary[index]);
            Console.WriteLine("Bonus: " + bonus[index]);
            Console.WriteLine("New Salary: " + newSalary[index]);
        }

        Console.WriteLine("Total Old Salary: " + totalOldSalary);
        Console.WriteLine("Total Bonus: " + totalBonus);
        Console.WriteLine("Total New Salary: " + totalNewSalary);
    }

    static void YoungestAndTallest()
    {
        string[] names = { "Amar", "Akbar", "Anthony" };
        int[] ages = new int[names.Length];
        double[] heights = new double[names.Length];

        for (int index = 0; index < names.Length; index++)
        {
            Console.Write("Enter age of " + names[index] + ": ");

            if (!int.TryParse(Console.ReadLine(), out ages[index]) || ages[index] <= 0)
            {
                Console.WriteLine("Invalid age.");
                index--;
                continue;
            }

            Console.Write("Enter height of " + names[index] + ": ");

            if (!double.TryParse(Console.ReadLine(), out heights[index]) || heights[index] <= 0)
            {
                Console.WriteLine("Invalid height.");
                index--;
            }
        }

        int youngestIndex = 0;
        int tallestIndex = 0;

        for (int index = 1; index < names.Length; index++)
        {
            if (ages[index] < ages[youngestIndex])
                youngestIndex = index;

            if (heights[index] > heights[tallestIndex])
                tallestIndex = index;
        }

        Console.WriteLine("Youngest: " + names[youngestIndex]);
        Console.WriteLine("Tallest: " + names[tallestIndex]);
    }

    static void LargestAndSecondLargest()
    {
        Console.Write("Enter a number: ");
        if (!int.TryParse(Console.ReadLine(), out int number) || number < 0)
        {
            Console.WriteLine("Invalid number.");
            return;
        }

        int maxDigit = 10;
        int[] digits = new int[maxDigit];
        int index = 0;

        if (number == 0)
        {
            digits[index] = 0;
            index++;
        }

        while (number != 0 && index < maxDigit)
        {
            digits[index] = number % 10;
            number = number / 10;
            index++;
        }

        int largest = 0;
        int secondLargest = 0;

        for (int digitIndex = 0; digitIndex < index; digitIndex++)
        {
            if (digits[digitIndex] > largest)
            {
                secondLargest = largest;
                largest = digits[digitIndex];
            }
            else if (digits[digitIndex] > secondLargest &&
                     digits[digitIndex] != largest)
            {
                secondLargest = digits[digitIndex];
            }
        }

        Console.WriteLine("Largest: " + largest);
        Console.WriteLine("Second Largest: " + secondLargest);
    }

    static void LargestAndSecondLargestUpdated()
    {
        Console.Write("Enter a number: ");
        if (!long.TryParse(Console.ReadLine(), out long number) || number < 0)
        {
            Console.WriteLine("Invalid number.");
            return;
        }

        int maxDigit = 10;
        int[] digits = new int[maxDigit];
        int index = 0;

        if (number == 0)
        {
            digits[index] = 0;
            index++;
        }

        while (number != 0)
        {
            if (index == maxDigit)
            {
                maxDigit += 10;

                int[] temp = new int[maxDigit];

                for (int copyIndex = 0; copyIndex < digits.Length; copyIndex++)
                {
                    temp[copyIndex] = digits[copyIndex];
                }

                digits = temp;
            }

            digits[index] = (int)(number % 10);
            number = number / 10;
            index++;
        }

        int largest = 0;
        int secondLargest = 0;

        for (int digitIndex = 0; digitIndex < index; digitIndex++)
        {
            if (digits[digitIndex] > largest)
            {
                secondLargest = largest;
                largest = digits[digitIndex];
            }
            else if (digits[digitIndex] > secondLargest &&
                     digits[digitIndex] != largest)
            {
                secondLargest = digits[digitIndex];
            }
        }

        Console.WriteLine("Largest: " + largest);
        Console.WriteLine("Second Largest: " + secondLargest);
    }

    static void ReverseNumber()
    {
        Console.Write("Enter a number: ");
        if (!int.TryParse(Console.ReadLine(), out int number) || number < 0)
        {
            Console.WriteLine("Invalid number.");
            return;
        }

        string numberText = number.ToString();
        int digitCount = numberText.Length;

        int[] digits = new int[digitCount];

        int tempNumber = number;

        for (int index = 0; index < digits.Length; index++)
        {
            digits[index] = tempNumber % 10;
            tempNumber = tempNumber / 10;
        }

        int[] reverseDigits = new int[digitCount];

        for (int index = 0; index < reverseDigits.Length; index++)
        {
            reverseDigits[index] = digits[digitCount - 1 - index];
        }

        Console.Write("Reversed Number: ");

        for (int index = reverseDigits.Length - 1; index >= 0; index--)
        {
            Console.Write(reverseDigits[index]);
        }

        Console.WriteLine();
    }

    static void CalculateBMI()
    {
        Console.Write("Enter number of persons: ");

        if (!int.TryParse(Console.ReadLine(), out int personCount) || personCount <= 0)
        {
            Console.WriteLine("Invalid number of persons.");
            return;
        }

        double[] height = new double[personCount];
        double[] weight = new double[personCount];
        double[] bmi = new double[personCount];
        string[] status = new string[personCount];

        for (int index = 0; index < personCount; index++)
        {
            Console.Write("Enter height in meters for person " + (index + 1) + ": ");

            if (!double.TryParse(Console.ReadLine(), out height[index]) || height[index] <= 0)
            {
                Console.WriteLine("Invalid height.");
                index--;
                continue;
            }

            Console.Write("Enter weight in kg for person " + (index + 1) + ": ");

            if (!double.TryParse(Console.ReadLine(), out weight[index]) || weight[index] <= 0)
            {
                Console.WriteLine("Invalid weight.");
                index--;
                continue;
            }

            bmi[index] = weight[index] / (height[index] * height[index]);

            if (bmi[index] < 18.5)
                status[index] = "Underweight";
            else if (bmi[index] < 25)
                status[index] = "Normal";
            else if (bmi[index] < 30)
                status[index] = "Overweight";
            else
                status[index] = "Obese";
        }

        for (int index = 0; index < personCount; index++)
        {
            Console.WriteLine("Person " + (index + 1));
            Console.WriteLine("Height: " + height[index]);
            Console.WriteLine("Weight: " + weight[index]);
            Console.WriteLine("BMI: " + bmi[index]);
            Console.WriteLine("Status: " + status[index]);
        }
    }

    static void CalculateBMIUsing2DArray()
    {
        Console.Write("Enter number of persons: ");

        if (!int.TryParse(Console.ReadLine(), out int personCount) || personCount <= 0)
        {
            Console.WriteLine("Invalid number of persons.");
            return;
        }

        double[,] personData = new double[personCount, 3];
        string[] weightStatus = new string[personCount];

        for (int index = 0; index < personCount; index++)
        {
            Console.Write("Enter height in meters: ");

            if (!double.TryParse(Console.ReadLine(), out personData[index, 0]) ||
                personData[index, 0] <= 0)
            {
                Console.WriteLine("Invalid height.");
                index--;
                continue;
            }

            Console.Write("Enter weight in kg: ");

            if (!double.TryParse(Console.ReadLine(), out personData[index, 1]) ||
                personData[index, 1] <= 0)
            {
                Console.WriteLine("Invalid weight.");
                index--;
                continue;
            }

            personData[index, 2] =
                personData[index, 1] /
                (personData[index, 0] * personData[index, 0]);

            double bmi = personData[index, 2];

            if (bmi < 18.5)
                weightStatus[index] = "Underweight";
            else if (bmi < 25)
                weightStatus[index] = "Normal";
            else if (bmi < 30)
                weightStatus[index] = "Overweight";
            else
                weightStatus[index] = "Obese";
        }

        for (int index = 0; index < personCount; index++)
        {
            Console.WriteLine("Person " + (index + 1));
            Console.WriteLine("Height: " + personData[index, 0]);
            Console.WriteLine("Weight: " + personData[index, 1]);
            Console.WriteLine("BMI: " + personData[index, 2]);
            Console.WriteLine("Status: " + weightStatus[index]);
        }
    }

    static void StudentMarks()
    {
        Console.Write("Enter number of students: ");

        if (!int.TryParse(Console.ReadLine(), out int studentCount) ||
            studentCount <= 0)
        {
            Console.WriteLine("Invalid number of students.");
            return;
        }

        double[] physics = new double[studentCount];
        double[] chemistry = new double[studentCount];
        double[] maths = new double[studentCount];
        double[] percentage = new double[studentCount];
        char[] grade = new char[studentCount];

        for (int index = 0; index < studentCount; index++)
        {
            Console.Write("Enter Physics marks: ");
            if (!double.TryParse(Console.ReadLine(), out physics[index]) ||
                physics[index] < 0 || physics[index] > 100)
            {
                Console.WriteLine("Invalid marks.");
                index--;
                continue;
            }

            Console.Write("Enter Chemistry marks: ");
            if (!double.TryParse(Console.ReadLine(), out chemistry[index]) ||
                chemistry[index] < 0 || chemistry[index] > 100)
            {
                Console.WriteLine("Invalid marks.");
                index--;
                continue;
            }

            Console.Write("Enter Maths marks: ");
            if (!double.TryParse(Console.ReadLine(), out maths[index]) ||
                maths[index] < 0 || maths[index] > 100)
            {
                Console.WriteLine("Invalid marks.");
                index--;
                continue;
            }

            percentage[index] =
                (physics[index] + chemistry[index] + maths[index]) / 3;

            grade[index] = GetGrade(percentage[index]);
        }

        for (int index = 0; index < studentCount; index++)
        {
            Console.WriteLine("Student " + (index + 1));
            Console.WriteLine("Physics: " + physics[index]);
            Console.WriteLine("Chemistry: " + chemistry[index]);
            Console.WriteLine("Maths: " + maths[index]);
            Console.WriteLine("Percentage: " + percentage[index]);
            Console.WriteLine("Grade: " + grade[index]);
        }
    }

    static void StudentMarksUsing2DArray()
    {
        Console.Write("Enter number of students: ");

        if (!int.TryParse(Console.ReadLine(), out int studentCount) ||
            studentCount <= 0)
        {
            Console.WriteLine("Invalid number of students.");
            return;
        }

        double[,] marks = new double[studentCount, 3];
        double[] percentage = new double[studentCount];
        char[] grade = new char[studentCount];

        for (int index = 0; index < studentCount; index++)
        {
            Console.Write("Enter Physics marks: ");

            if (!double.TryParse(Console.ReadLine(), out marks[index, 0]) ||
                marks[index, 0] < 0 || marks[index, 0] > 100)
            {
                Console.WriteLine("Invalid marks.");
                index--;
                continue;
            }

            Console.Write("Enter Chemistry marks: ");

            if (!double.TryParse(Console.ReadLine(), out marks[index, 1]) ||
                marks[index, 1] < 0 || marks[index, 1] > 100)
            {
                Console.WriteLine("Invalid marks.");
                index--;
                continue;
            }

            Console.Write("Enter Maths marks: ");

            if (!double.TryParse(Console.ReadLine(), out marks[index, 2]) ||
                marks[index, 2] < 0 || marks[index, 2] > 100)
            {
                Console.WriteLine("Invalid marks.");
                index--;
                continue;
            }

            percentage[index] =
                (marks[index, 0] + marks[index, 1] + marks[index, 2]) / 3;

            grade[index] = GetGrade(percentage[index]);
        }

        for (int index = 0; index < studentCount; index++)
        {
            Console.WriteLine("Student " + (index + 1));
            Console.WriteLine("Physics: " + marks[index, 0]);
            Console.WriteLine("Chemistry: " + marks[index, 1]);
            Console.WriteLine("Maths: " + marks[index, 2]);
            Console.WriteLine("Percentage: " + percentage[index]);
            Console.WriteLine("Grade: " + grade[index]);
        }
    }

    static char GetGrade(double percentage)
    {
        if (percentage >= 90)
            return 'A';
        else if (percentage >= 80)
            return 'B';
        else if (percentage >= 70)
            return 'C';
        else if (percentage >= 60)
            return 'D';
        else
            return 'F';
    }

    static void DigitFrequency()
    {
        Console.Write("Enter a number: ");

        if (!long.TryParse(Console.ReadLine(), out long number) || number < 0)
        {
            Console.WriteLine("Invalid number.");
            return;
        }

        string numberText = number.ToString();
        int digitCount = numberText.Length;

        int[] digits = new int[digitCount];
        long tempNumber = number;

        if (number == 0)
        {
            digits[0] = 0;
        }
        else
        {
            for (int index = 0; index < digits.Length; index++)
            {
                digits[index] = (int)(tempNumber % 10);
                tempNumber = tempNumber / 10;
            }
        }

        int[] frequency = new int[10];

        for (int index = 0; index < digits.Length; index++)
        {
            frequency[digits[index]]++;
        }

        for (int index = 0; index < frequency.Length; index++)
        {
            if (frequency[index] > 0)
            {
                Console.WriteLine(index + " occurs " + frequency[index] + " time(s)");
            }
        }
    }
}
