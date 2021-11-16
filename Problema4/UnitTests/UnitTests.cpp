#include "pch.h"
#include "CppUnitTest.h"
#include "../Problema4/CoinCombinator.cpp"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTests
{
	TEST_CLASS(UnitTests)
	{
	public:
		
		TEST_METHOD(TestMethod_FirstInput)
		{
			CoinCombinator coin;
			int coins[] = { 1, 5, 10, 20, 25, 50 };
			int size = sizeof(coins) / sizeof(coins[0]);

			Assert::AreEqual(4, coin.GetNumberOfCombinations(coins,size,10));
		}
		TEST_METHOD(TestMethod_SecondInput)
		{
			CoinCombinator coin;
			int coins[] = { 1, 5, 10, 20, 25, 50 };
			int size = sizeof(coins) / sizeof(coins[0]);

			Assert::AreEqual(10, coin.GetNumberOfCombinations(coins,size,20));
		}
		TEST_METHOD(TestMethod_ZeroInput)
		{
			CoinCombinator coin;
			int coins[] = { 1, 5, 10, 20, 25, 50 };
			int size = sizeof(coins) / sizeof(coins[0]);

			Assert::AreEqual(1, coin.GetNumberOfCombinations(coins,size,0));
		}
		TEST_METHOD(TestMethod_LessThanZeroInput)
		{
			CoinCombinator coin;
			int coins[] = { 1, 5, 10, 20, 25, 50 };
			int size = sizeof(coins) / sizeof(coins[0]);

			Assert::AreEqual(0, coin.GetNumberOfCombinations(coins,size,-1));
		}
		TEST_METHOD(TestMethod_LessThanZeroSize)
		{
			CoinCombinator coin;
			int coins[] = { 1, 5, 10, 20, 25, 50 };
			int size = sizeof(coins) / sizeof(coins[0]);

			Assert::AreEqual(0, coin.GetNumberOfCombinations(coins,-1,10));
		}
		TEST_METHOD(TestMethod_ZeroSize)
		{
			CoinCombinator coin;
			int coins[] = { 1, 5, 10, 20, 25, 50 };
			int size = sizeof(coins) / sizeof(coins[0]);

			Assert::AreEqual(0, coin.GetNumberOfCombinations(coins,0,10));
		}
	};
}
