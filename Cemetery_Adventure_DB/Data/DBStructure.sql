DROP TABLE IF EXISTS saved_games;

CREATE TABLE saved_games (
	id int IDENTITY(1,1) PRIMARY KEY,
	saved_time SMALLDATETIME NOT NULL,
	floor int NOT NULL,
	player_name VARCHAR(20) NOT NULL,
	maxHP int NOT NULL,
	armor_type int,
	weapon_type int
);

INSERT INTO saved_games (saved_time, floor, player_name, maxHP, armor_type, weapon_type) VALUES
(GETDATE(), 3, 'Bob', 20, 1, 2);
