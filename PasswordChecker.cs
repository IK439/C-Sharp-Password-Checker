using System;
using System.Text.RegularExpressions;

/* This program validates a user-entered password against
   modern security requirements, and evaluates its strength based on
   common risk patterns such as repetition, sequences, and weak terms */

namespace PasswordChecker
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Minimum required password length
            const int minLength = 12;

            // Prompt the user to enter a password
            Console.WriteLine("Running Password Checker...");

            Console.WriteLine("\nPassword Criteria");

            Console.WriteLine("\nA strong password:");
            Console.WriteLine("- is at least 12 characters long");
            Console.WriteLine("- has 1 uppercase letter");
            Console.WriteLine("- has 1 lowercase letter");
            Console.WriteLine("- has 1 number");
            Console.WriteLine("- has 1 special character");

            Console.WriteLine("\nRemember... your password must not contain whitespace or have 3 or more repeated characters in a row");

            Console.WriteLine("\nPlease enter your password:");
            string input = Console.ReadLine();

            // Check for null or whitespace in input
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Password cannot be empty or contain whitespace");
                return;
            }

            // Enforce minimum length
            bool hasMinLength = input.Length >= minLength;

            // Require at least one uppercase letter (A–Z)
            bool hasUpper = Regex.IsMatch(input, "[A-Z]");

            // Require at least one lowercase letter (a–z)
            bool hasLower = Regex.IsMatch(input, "[a-z]");

            // Require at least one number (0–9)
            bool hasDigit = Regex.IsMatch(input, "[0-9]");

            // Require at least one special character
            bool hasSpecial = Regex.IsMatch(input, @"[^a-zA-Z0-9]");

            // Detect whitespace characters
            bool hasWhitespace = Regex.IsMatch(input, @"\s");

            // Detect three or more repeated characters in a row
            bool hasRepeatedChars = Regex.IsMatch(input, @"(.)\1\1");

            // Detect common sequential patterns (alphabetic or numeric)
            bool hasSequentialChars = Regex.IsMatch(
                input.ToLower(),
                @"abc|bcd|cde|def|123|234|345|456|567|678|789"
            );

            // Detect very common weak password words
            bool hasCommonPattern = Regex.IsMatch(
                input.ToLower(),
                @"password|qwerty|admin|letmein|welcome"
            );

            // If any core requirement fails, the password is rejected
            if (!hasMinLength || !hasUpper || !hasLower || !hasDigit || !hasSpecial)
            {
                Console.WriteLine("Password does not meet minimum requirements");
                return;
            }

            // Reject passwords containing whitespace
            if (hasWhitespace)
            {
                Console.WriteLine("Password must not contain whitespace");
                return;
            }

            int riskScore = 0;

            // Increment risk score for each detected weakness
            if (hasRepeatedChars) riskScore++;
            if (hasSequentialChars) riskScore++;
            if (hasCommonPattern) riskScore++;

            // Map risk score to a strength assessment
            switch (riskScore)
            {
                case 0:
                    Console.WriteLine("Password strength: Excellent");
                    break;
                case 1:
                    Console.WriteLine("Password strength: Good");
                    break;
                case 2:
                    Console.WriteLine("Password strength: Fair");
                    break;
                default:
                    Console.WriteLine("Password strength: Weak");
                    break;
            }
        }
    }
}