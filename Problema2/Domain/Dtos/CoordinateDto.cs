namespace Domain.Dtos
{
    public class CoordinateDto
    {
        public CoordinateDto()
        {
            X = 0;
            Y = 0;
            Instruction = "";
        }
        public CoordinateDto(CoordinateDto coordinate)
        {
            X = coordinate.X;
            Y = coordinate.Y;
            Instruction = coordinate.Instruction;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public string Instruction { get; set; }
    }
}
