using System;
using System.Collections.Generic;

namespace _03._The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfPieces = int.Parse(Console.ReadLine());
            var pieces = new Dictionary<string, string>();

            for (int i = 0; i < numOfPieces; i++)
            {
                string[] currPieceDetails = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string pieceName = currPieceDetails[0];
                string composerAndKey = $"{currPieceDetails[1]}:{currPieceDetails[2]}";

                pieces.Add(pieceName, composerAndKey);
            }

            string cmd = Console.ReadLine();

            while (cmd != "Stop")
            {
                string[] cmdArgs = cmd.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string currCmd = cmdArgs[0];
                string currPieceName = cmdArgs[1];

                if (currCmd == "Add")
                {
                    if (pieces.ContainsKey(currPieceName))
                    {
                        Console.WriteLine($"{currPieceName} is already in the collection!");
                        cmd = Console.ReadLine();
                        continue;
                    }

                    string currComposerAndKey = $"{cmdArgs[2]}:{cmdArgs[3]}";

                    pieces.Add(currPieceName, currComposerAndKey);

                    Console.WriteLine($"{currPieceName} by {cmdArgs[2]} in {cmdArgs[3]} added to the collection!");
                }
                else if (!pieces.ContainsKey(currPieceName))
                {
                    Console.WriteLine($"Invalid operation! {currPieceName} does not exist in the collection.");
                    cmd = Console.ReadLine();
                    continue;
                }
                else if (currCmd == "Remove")
                {
                    pieces.Remove(currPieceName);

                    Console.WriteLine($"Successfully removed {currPieceName}!");
                }
                else if (currCmd == "ChangeKey")
                {
                    string newComposerKeyPair = $"{pieces[currPieceName].Split(':')[0]}:{cmdArgs[2]}";

                    pieces[currPieceName] = newComposerKeyPair;

                    Console.WriteLine($"Changed the key of {currPieceName} to {cmdArgs[2]}!");
                }

                cmd = Console.ReadLine();
            }

            foreach (var piece in pieces)
            {
                string composer = piece.Value.Split(':')[0];
                string key = piece.Value.Split(':')[1];

                Console.WriteLine($"{piece.Key} -> Composer: {composer}, Key: {key}");
            }
        }
    }
}
