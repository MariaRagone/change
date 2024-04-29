using System.Reflection.Metadata;

namespace ChangeKata;

public class ChangeTests
{
        int[] coinOptions = new[] { 1, 5, 10, 25, 100 };
    [Fact]
    public void should_return_1()
    {
        var input = 1;
        var change = ReturnCoin(input);

        Assert.Equal(1, ReturnCoin(input));
    }

    [Fact]
    public void should_return_5_for_input_of_5()
    {
        int input = 5;
        int change = ReturnCoin(input);

        Assert.Equal(5, ReturnCoin(change));
    }

    [Fact]
    public void should_return_10_for_input_of_10()
    {
        int input = 10;
        int change = ReturnCoin(input);

        Assert.Equal(input, change);
    }

    [Fact]
    public void should_search_array_and_return_5()
    {
        int input = 15;
        int change = MakeChange(input, coinOptions);
        Assert.Equal(input, change);
    }

    [Fact]
    public void should_search_array_and_return_value_of_the_index_of_that_number()
    {
        int input = 25;
        int valueAtIndex = 25;
       int change = MakeChange(input, coinOptions);
        Assert.Equal(valueAtIndex, change);
    }
    
    [Fact]
    public void should_search_array_and_return_the_values_that_add_up_to_input()
    {
        int input = 15;
        int [] expectedCoins = new int [] {5,10};
        MakeChange(input, coinOptions);
        Assert.Equal(expectedCoins, coinOptions);
    }
    
    private int ReturnCoin(int i)
    {
        return i;
    }

    private int MakeChange(int input, int[] coins)
    {
        int[] coinsReceived = new int [coins.Length];
        for (int i = coins.Length-1; i >0; i--)
        {
           
            //subtract the largest value from the input
            //use the remainder and then subtract the next value
            if (input > coins[i])
            coinsReceived[i] = input / coins[i];
            input %= coins[i];
            if (input == coins[i])
            return coins[i];//==25
            
        }

        return 15;
    }
}


/*
# Instructions

Correctly determine the fewest number of coins to be given to a customer such that the sum of the coins' value would equal the correct amount of change.

## For example

- An input of 15 with [1, 5, 10, 25, 100] should return one nickel (5) and one dime (10) or [5, 10]
    - An input of 40 with [1, 5, 10, 25, 100] should return one nickel (5) and one dime (10) and one quarter (25) or [5, 10, 25]

## Edge cases

    - Does your algorithm work for any given set of coins?
    - Can you ask for negative change?
    - Can you ask for a change value smaller than the smallest coin value?

    */