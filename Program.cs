using System.Collections.Generic;
using System.Diagnostics;

namespace InputValidator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// How to use the method.
			int test01 = InputWithValidation<int>("Please input a whole number: ");
			string test02 = InputWithValidation<string>("Please input a string: ");
			float test03 = InputWithValidation<float>("Please input a whole number or a decimal number: ");
			double test04 = InputWithValidation<double>("Please input a whole number or a larger decimal number than the previous: ");

			Console.WriteLine($"{test01}\n{test02}\n{test03}\n{test04}");

			Console.ReadKey();
		}

		static public void DisplayInvalidInputError(string validInput)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write($"\nMake sure input is of type {validInput}.\n");
			Console.ForegroundColor = ConsoleColor.White;
		}

		static T InputWithValidation<T>(string prompt)
		{
			while (true) {

				Console.Write(prompt);

				switch (typeof(T)) {
					case Type t when t == typeof(int):
						if (int.TryParse(Console.ReadLine(), out int resultInt)) {
							return (T)(object)resultInt;
						}
						else {
							DisplayInvalidInputError("int");
						}
					break;

					case Type t when t == typeof(float):
						if (Single.TryParse(Console.ReadLine(), out float resultFloat)) {
							return (T)(object)resultFloat;
						}
						else {
							DisplayInvalidInputError("float");
						}
					break;

					case Type t when t == typeof(double):
						if (double.TryParse(Console.ReadLine(), out double resultDouble)) {
							return (T)(object)resultDouble;
						}
						else {
							DisplayInvalidInputError("double");
						}
					break;

					case Type t when t == typeof(string):
						string input = Console.ReadLine();
						if (string.IsNullOrEmpty(input))
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Input can not be empty.");
							Console.ForegroundColor = ConsoleColor.White;
						}
						else {
							return (T)(object)input;
						}
					break;
				}
			}
		}
	}
}
