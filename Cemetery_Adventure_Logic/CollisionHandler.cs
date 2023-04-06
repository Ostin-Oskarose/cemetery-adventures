using Cemetery_Adventure_Logic.Entity;
using Cemetery_Adventure_Logic.Entity.Character;
using Cemetery_Adventure_Logic.GameBoard;

namespace Cemetery_Adventure_Logic;

public class CollisionHandler
{

    public CollisionType GetCollisionType((int X, int Y) position, GameBoard.Board board)
    {
        switch (board.BoardArray[position.Y, position.X])
        {
            case Character:
                return CollisionType.Character;
            case Obstacle:
                return CollisionType.Obstacle;
            case FloorItem:
                return CollisionType.Item;
            default:
                throw new ArgumentException("Unknown Collision");
        }
    }

    public void ResolveCharacterCollision(Character character, (int X, int Y) move, GameBoard.Board board, MessageBuffer messageBuffer)
    {
        var target = board.BoardArray[move.Y, move.X] as Character;
        if (target == character) return;
        var damage = character.Attack(target);
        messageBuffer.Add($"{character.Name} attacks {target.Name} for {damage} damage");
    }

    public void ResolveObstacleCollision(Character character, (int X, int Y) move, Game game, GameBoard.Board board)
    {
        var obstacle = board.BoardArray[move.Y, move.X];
        if (obstacle is Stairs stairs && character is Player && ((Player)character).CheckForKey())
        {
            game.NextFloor(stairs, character);
        }
    }

    public void ResolveItemCollision(Character character, Player player, (int X, int Y) move, GameBoard.Board board, MessageBuffer messageBuffer)
    {
        if (character != player) return;

        var item = ((FloorItem)board.BoardArray[move.Y, move.X]).Item;

        board.MoveEntity(character.Position, move);
        character.Move(move.X, move.Y);

        messageBuffer.Add($"You found a {item.Name}");

        if (player.SameTypeItem(item))
        {
            var worstItem = player.WorstItem(item);
            if (worstItem == item) return;
            player.RemoveItemFromInventory(worstItem.Name);
        }

        messageBuffer.Add($"You equip the {item.Name}");
        player.AddItemToInventory(item);
        player.UpdateStatistics(item);
    }
}