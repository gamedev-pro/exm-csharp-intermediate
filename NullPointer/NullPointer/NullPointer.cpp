#include <stdio.h>

class Player
{
public:
	int coins;

	void SpendCoins()
	{
		coins--;
	}
};

class UI
{
public:
	Player* player;

	void ShowPlayerCoins()
	{
		if (player != nullptr)
		{
			printf("Player coins: %d\n", player->coins);
		}
	}
};

int main()
{
	Player* player = new Player();
	player->coins = 10;

	UI* ui = new UI();
	//ui->player = player;

	ui->ShowPlayerCoins();
	player->SpendCoins();
	ui->ShowPlayerCoins();
}