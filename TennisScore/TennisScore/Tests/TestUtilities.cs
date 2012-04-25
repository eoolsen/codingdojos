using System;

namespace TennisScore
{
    class TestUtilities
    {
        internal static void WinOrdinaryGame(Action playerWinspoint)
        {
            for (int i = 0; i < 4; i++)
            {
                playerWinspoint();
            }
        }
    }
}
