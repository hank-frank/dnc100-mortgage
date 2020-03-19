using System;

namespace dnc100_mortgage_calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Mortgage mortgage;
            double principal, interestRate, monthlyPayment;
            int term, period;

            // Use .WriteLine to greet the user
            Console.WriteLine("Whats up bro? I hear you're interested in Mortgage Rates, super cool.");

            // Use a mix of WriteLine and ReadLine to obtain the mortgage attributes (Making sure to typecast)
            Console.WriteLine("Input the Principal Balance: ");
            principal = Double.Parse(Console.ReadLine());

            Console.WriteLine("Input the Interest Rate: ");
            interestRate = Double.Parse(Console.ReadLine());
            
            Console.WriteLine("Input the Term: (# of years)");
            term = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Input the Period (# of payments per year): ");
            period = Int32.Parse(Console.ReadLine());

            // Create a new Mortgage with the given attributes
            mortgage = new Mortgage(principal, interestRate, term, period);

            // Use the Mortgage functions to calculate the monthly payment

            monthlyPayment = mortgage.Calculate();

            int months = mortgage.NumberOfPayments(term, period);
            double monthlyRate = mortgage.MonthlyInterestRate(interestRate, period);
            double compoundInterest = mortgage.CompoundedInterestRate(monthlyRate, months);
            double iQ = mortgage.InterestQuotient(monthlyRate, compoundInterest, months);

            // Use WriteLine to output the monthly payment
            Console.WriteLine($"principal: {principal}, interestRate: {interestRate}");
            Console.WriteLine($"term: {term}, period: {period}");
            Console.WriteLine($" your # of monthly payments: {months}");
            Console.WriteLine($"monthly interest rate: {monthlyRate}");
            Console.WriteLine($"Compound interest: {compoundInterest}");
            Console.WriteLine($"IQ : {iQ}");
            Console.WriteLine($"monthly payment: {monthlyPayment}");

            Console.WriteLine($"hit any key to finish...");
            Console.ReadKey();


    }
    }
}
