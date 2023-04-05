DROP TABLE IF EXISTS saved_games;

CREATE TABLE saved_games (
	id int IDENTITY(1,1) PRIMARY KEY,
	saved_time SMALLDATETIME NOT NULL,
	floor int NOT NULL,
	player_name VARCHAR(20) NOT NULL,
	maxHP int NOT NULL,
	damage int NOT NULL,
	defense int NOT NULL,
	armor VARCHAR(20),
	weapon VARCHAR(20)
);

INSERT INTO saved_games (saved_time, floor, player_name, maxHP, damage, defense, armor, weapon) VALUES
(GETDATE(), 3, 'Bob', 20, 5, 0, '', '');
