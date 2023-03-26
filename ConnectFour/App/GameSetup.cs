using ConnectFour.Models.Players;

namespace ConnectFour.App;

public record GameSetup(IPlayer Player1, IPlayer Player2, ConnectFourBoard Board);