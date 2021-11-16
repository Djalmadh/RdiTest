#include "CoinCombinator.h"
#include <climits>

int CoinCombinator::GetNumberOfCombinations(int coins[], int size, int input)
{
    if (IsInvalid(size, input))
        return 0;

    // If the input is zero we have one solution 
    // that is sending 0 coins
    if (input == 0)
        return 1;

    // NumberOfCombinations is sum of solutions
    // (I) including coins[size-1] (II) excluding coins[size-1]
    return GetNumberOfCombinations(coins, size - 1, input) + //(I)
           GetNumberOfCombinations(coins, size, input - coins[size - 1]); //(II)
}

bool CoinCombinator::IsInvalid(int size, int input)
{
    // If input is less than 0 
    // Or if the input is greater than 0 and there's no coins
    // There's no solutions
    if (input < 0 || (size <= 0 && input >= 1))
        return true;
    else
        return false;
}
