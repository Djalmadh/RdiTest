#include <iostream>
#include "CoinCombinator.h"

int main()
{
    CoinCombinator coin;
    int coins[] = { 1, 5, 10, 20, 25, 50};
    int size = sizeof(coins) / sizeof(coins[0]);

    std::cout <<"Input = 10 => Resultado: "<< coin.GetNumberOfCombinations(coins, size, 10)<<"\n";
    std::cout <<"Input = 20 => Resultado: " << coin.GetNumberOfCombinations(coins, size, 20);
}
