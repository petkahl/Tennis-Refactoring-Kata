using System;
using System.Collections.Generic;

namespace Tennis
{

    enum Score
    {
        Love = 0,
        Fifteen = 1,
        Thirty = 2,
        Forty = 3
    }

    class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public static Dictionary<int, string> victory = new Dictionary<int, string>() {
            { -2, "Win for player2" },
            { -1, "Advantage player2" },
            { 1, "Advantage player1" },
            { 2, "Win for player1" }
            };

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void Player1WonPoint()
        {
            m_score1++;
        }
        public void Player2WonPoint()
        {
            m_score2++;
        }
        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                Player1WonPoint();
            else
                Player2WonPoint();
        }

        public string GetScore()
        {
            string score = "";
            if (m_score1 == m_score2)
            {
                if (m_score1 >= 3)
                {
                    score = "Deuce";
                }
                else
                {
                    score = CalculateOneScore(m_score1) + "-All";
                }
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                var minusResult = m_score1 - m_score2;
                var absResult = Math.Abs(minusResult);

                if (absResult > 2)
                {
                    minusResult = minusResult / absResult * 2;
                }
                score = victory[minusResult];
            }
            else
            {
                score = CalculateOneScore(m_score1) + "-" + CalculateOneScore(m_score2);
            }
            return score;
        }

        private static string CalculateOneScore(int score)
        {
            string result = string.Empty;
            Score s = (Score)score;
            result = s.ToString();
            //switch (score)
            //{
            //    case 0:
            //        result = "Love";
            //        break;
            //    case 1:
            //        result = "Fifteen";
            //        break;
            //    case 2:
            //        result = "Thirty";
            //        break;
            //    case 3:
            //        result = "Forty";
            //        break;
            //}

            return result;
        }
    }
}

