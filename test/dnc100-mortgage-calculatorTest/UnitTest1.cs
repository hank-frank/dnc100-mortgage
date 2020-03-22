using System;
using Xunit;
using dnc100_mortgage_calculator;

namespace dnc100_mortgage_calculatorTest
{
    public class UnitTest1
    {
        double principal = 1000;
        double interest = 1;
        int term = 10;
        int period = 10;

        [Fact]
        public void MortgageCalculate()
        {
            Mortgage mortgage = new Mortgage(principal, interest, term, period);
            double expected = 10.51;
            Assert.Equal(expected, Math.Round(mortgage.Calculate(), 2));
        }

        [Fact]
        public void MorgageMonthlyInterestRate()
        {
            Mortgage mortgage = new Mortgage(principal, interest, term, period);
            double testMonthlyInterestRate = 0.001;
            Assert.Equal(testMonthlyInterestRate, Math.Round(mortgage.MonthlyInterestRate(interest, period), 4));
        }

        [Fact]
        public void MorgageNumberOfPayments()
        {
            Mortgage mortgage = new Mortgage(principal, interest, term, period);
            int testPayments = 100;
            Assert.Equal(testPayments, mortgage.NumberOfPayments(term, period));
        }

        [Fact]
        public void MorgageCompoundedInterestRate()
        {
            Mortgage mortgage = new Mortgage(principal, interest, term, period);
            double monthlyInterestRate = 0.001;
            int numberOfPayments = 100;
            double testCompoundedInterest = 1.1051;
            Assert.Equal(testCompoundedInterest, Math.Round(mortgage.CompoundedInterestRate(monthlyInterestRate, numberOfPayments), 4));
        }

        [Fact]
        public void MortgageInterestQuotient()
        {
            Mortgage mortgage = new Mortgage(principal, interest, term, period);
            double monthlyInterestRate = 0.001;
            int numberOfPayments = 100;
            double compoundedInterest = 1.1051;
            double testQuotient = 0.0105;
            Assert.Equal(testQuotient, Math.Round(mortgage.InterestQuotient(monthlyInterestRate, compoundedInterest, numberOfPayments), 4));
        }
    }

}
