#pragma once
class CoinCombinator
{
	public: 
		int GetNumberOfCombinations(int coins[], int size, int input);

	private:
		bool IsInvalid(int size, int input);
};

