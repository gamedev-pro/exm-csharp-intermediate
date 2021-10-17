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
	Player* player = nullptr;

	void ShowPlayerCoins()
	{
		if (player != nullptr)
		{
			printf("Player coins: %d\n", player->coins);
		}
	}
};

class GameMode
{
public:
	Player* player;
	UI* ui;

	void StartGame()
	{
		player = new Player();
		player->coins = 10;

		ui = new UI();
		ui->player = player;
	}

	void GameOver()
	{
		delete player;
		delete ui;
	}
};

int main()
{
	GameMode* gameMode = new GameMode();
	gameMode->StartGame();

	//raw pointers
	Player* player = gameMode->player;
	UI* ui = gameMode->ui;

	ui->ShowPlayerCoins();
	player->SpendCoins();
	ui->ShowPlayerCoins();

	gameMode->GameOver();

	player->SpendCoins();
	//ui->ShowPlayerCoins();
}