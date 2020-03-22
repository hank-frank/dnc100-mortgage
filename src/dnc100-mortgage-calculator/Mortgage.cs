using System;
using System.Collections.Generic;
using System.Text;

namespace dnc100_mortgage_calculator
{
    public class Mortgage
    {
        private int _period;
        private int _term;
        private double _interest;
        private double _principle;

        public Mortgage(double principle, double interest, int term, int period)
            {
                _period = period;
                _term = term;
                _interest = interest;
                _principle = principle;
                
            }

            public double Calculate()
            {
                double monthlyInterestRate = MonthlyInterestRate(_interest, _period);
                int numberOfPayments = NumberOfPayments(_term, _period);
                double compoundedInterestRate = CompoundedInterestRate(monthlyInterestRate, numberOfPayments);
                double interestQuotient = InterestQuotient(monthlyInterestRate, compoundedInterestRate, numberOfPayments);
                return _principle * interestQuotient;
                
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
                //return (monthlyInterestRate * compoundedInterestRate) / ((Math.Pow((1 + monthlyInterestRate), numberOfPayments)) - 1);
    }
    }
}
