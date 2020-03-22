using System;

namespace dnc100_mortgage_calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Whats up bro? I hear you're interested in Mortgage Rates, super cool.");

       
            Console.WriteLine("Input the Principal Balance: ");
            double principal = Double.Parse(Console.ReadLine());

            Console.WriteLine("Input the Interest Rate: ");
            double interestRate = Double.Parse(Console.ReadLine());
            
            Console.WriteLine("Input the Term: (# of years)");
            int term = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Input the Period (# of payments per year): ");
            int period = Int32.Parse(Console.ReadLine());

            
            Mortgage mortgage = new Mortgage(principal, interestRate, term, period);

            

            double monthlyPayment = mortgage.Calculate();

            int months = mortgage.NumberOfPayments(term, period);
            double monthlyRate = mortgage.MonthlyInterestRate(interestRate, period);
            double compoundInterest = mortgage.CompoundedInterestRate(monthlyRate, months);
            double iQ = mortgage.InterestQuotient(monthlyRate, compoundInterest, months);

            
            Console.WriteLine($"principal: {principal}, interestRate: {interestRate}");
            Console.WriteLine($"term: {term}, period: {period}");
            Console.WriteLine($" your # of monthly payments: {months}");
            Console.WriteLine($"monthly interest rate: {monthlyRate}");
            Console.WriteLine($"Compound interest: {compoundInterest}");
            Console.WriteLine($"IQ : {iQ}");
            Console.WriteLine($"monthly payment: {Math.Round(monthlyPayment, 2)}");

            Console.WriteLine($"hit any key to finish...");
            Console.ReadKey();
    }
    }
}
