using Domain.Interfaces;
using Domain.Dtos;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Services
{
    public class Robot: IRobot
    {
        public string GetLastLoop(string input)
        {
            List<CoordinateDto> visited = new() { new CoordinateDto() };

            if(!string.IsNullOrEmpty(input))
                GetPath(input, visited);

            List<CoordinateDto> loopElements = GetloopElements(visited);
            if (loopElements.Count < 1)
            {
                return "No Loop";
            }

            int startIndex = visited.IndexOf(loopElements.First()) + 1;
            int endIndex = visited.IndexOf(loopElements.Last());

            return WriteResultString(visited, startIndex, endIndex);
        }

        //Function that loops through input and generates the coordinates that the robot went through
        private static void GetPath(string input, List<CoordinateDto> visited)
        {
            input = input.ToUpper();
            CoordinateDto lastCoordinate = new();
            foreach (char movement in input)
            {
                lastCoordinate = CalculateCoordinate(movement, lastCoordinate);

                visited.Add(lastCoordinate);
            }
        }
        //Function to generate a new coordinate based on inputs
        private static CoordinateDto CalculateCoordinate(char input, CoordinateDto lastCoordinate)
        {
            CoordinateDto newCoodinate = new(lastCoordinate);

            //Used nested if-else to avoid raising the complexity unnecessarily
            //In a robot with a more complex behaviour a state pattern could be valid
            if (input == 'U')
            {
                newCoodinate.Y += 1;
                newCoodinate.Instruction = input.ToString();
            }
            else if (input == 'D')
            {
                newCoodinate.Y -= 1;
                newCoodinate.Instruction = input.ToString();
            }
            else if (input == 'R')
            {
                newCoodinate.X += 1;
                newCoodinate.Instruction = input.ToString();
            }
            else if (input == 'L')
            {
                newCoodinate.X -= 1;
                newCoodinate.Instruction = input.ToString();
            }
            else
            {
                Console.WriteLine($"Skipped Invalid Input: {input}");
            }
            return newCoodinate;
        }

        //Function that finds repeated elements and returns the first that happened(first loop)
        private static List<CoordinateDto> GetloopElements(List<CoordinateDto> visited)
        {
            var repeatedElements = visited.GroupBy(g => new
            {
                g.X,
                g.Y,
            }).Where(w => w.Count() > 1);

            if(repeatedElements.Any())
            {
                return repeatedElements
                        .First().ToList();
            }

            return new();
        }

        //Gets the commands given to the robot in between the beginning and the end of the loop
        //and transforms it in a string
        private static string WriteResultString(List<CoordinateDto> visited, int startIndex, int endIndex)
        {
            string result = string.Empty;

            for (int i = startIndex; i <= endIndex; i++)
            {
                result += visited[i].Instruction;
            }

            return result;
        }
    }
}