using System;
using System.Collections.Generic;
using System.Text;

namespace dnc100_mortgage_calculator
{
    public class Mortgage
    {
    private int period;
    private int term;
    private double interest;
    private double principle;

    public Mortgage(double mPrinciple, double mInterest, int mTerm, int mPeriod)
        {
            period = mPeriod;
            term = mTerm;
            interest = mInterest;
            principle = mPrinciple;
            
        }

        public double Calculate()
        {
            int months = period * term;
            double r = interest / 1200;
            double top = r * Math.Pow((1 + r), months);
            double bottom = Math.Pow((1 + r), months) - 1;
            double payment = (principle * (top / bottom));

            string str = payment.ToString("0.00");
            double pay = Convert.ToDouble(str);

            return pay;
            
        }

        public double MonthlyInterestRate(double interest, int period)
        {

            double percent = interest / 100;
            double monthlyRate = percent / period;
              
            return monthlyRate;
        }

        public int NumberOfPayments(int term, int period)
        {
            return period * term;
        }

        public double CompoundedInterestRate(double monthlyInterestRate, int numberOfPayments)
        {
            double final = Math.Pow((1 + monthlyInterestRate), numberOfPayments);
            return final;
        }

        public double InterestQuotient(double monthlyInterestRate, double compoundedInterestRate, int numberOfPayments)
        {

            double iQ = (monthlyInterestRate * numberOfPayments) * (1 - compoundedInterestRate);

            return Math.Abs(iQ);
        }
    }
}

//public static double MortgageCalculator(double balance, double rate, int term, int period)
//{
//  int months = term * 12;
//  double r = rate / 1200;
//  double top = r * Math.Pow((1 + r), months);
//  double bottom = Math.Pow((1 + r), months) - 1;
//  double payment = (balance * (top / bottom));

//  string str = payment.ToString("0.00");
//  double pay = Convert.ToDouble(str);
//  return pay;
//}
