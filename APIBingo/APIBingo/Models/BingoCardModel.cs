namespace APIBingo.Models
{
    public class BingoCardModel
    {
        private const int _maxRows = 3;
        private const int _maxColumns = 9;
        private const int _minValue = 1;
        private const int _maxValue = 10;
        private readonly int[,] _range;
        private readonly int[] _blankCellsByColumns;

        public int Id { get; set; }
        public int GameId { get; set; }
        public int Card { get; set; }
        public string Numbers { get; set; }
        public string OrderedN { get; set; }
        public bool Completed { get; set; }

        public BingoCardModel(int bingoCardNumber)
        {
            Card = bingoCardNumber;
            Completed = false;
            Numbers = string.Empty;
            OrderedN = string.Empty;

            int[,] card = new int[_maxRows, _maxColumns];

            //I generate a matrix with minimum and maximum ranges of numbers that the card can have per column.
            _range = BuildRange();

            //I define three columns with 2 empty fields and the remaining ones with only 1 empty field.
            _blankCellsByColumns = DefineBlankCellsByColumns();

            //I specify which fields will contain numbers and which ones will be empty.
            DefineBlankCellsByRows(card, _blankCellsByColumns);

            //I assign random numbers to the matrix representing the bingo cards.
            BuildMatrix(card);
        }

        public void RedefineNumbers()
        {
            int[,] card = new int[_maxRows, _maxColumns];
            string[] orderedNumbers = OrderedN.Split(',');
            int order = 0;

            for (int c = 0; c < _maxColumns; c++)
            {
                for (int r = 0; r < _maxRows; r++) 
                {
                    card[r, c] = string.IsNullOrEmpty(orderedNumbers[order]) ? 0 : 1;
                    order++;
                }
            }
            BuildMatrix(card);
        } 

        private static int[,] BuildRange()
        {
            int minValue = _minValue;
            int maxValue = _maxValue;
            int[,] range = new int[_maxRows - 1, _maxColumns];

            for (var c = 0; c < _maxColumns; c++)
            {
                if (c == _maxColumns - 1)
                    maxValue += 1;

                range[0, c] = minValue;
                range[1, c] = maxValue;

                minValue = maxValue;
                maxValue += 10;
            }
            return range;
        }

        private static int[] DefineBlankCellsByColumns() 
        {
            int currentCell;
            int previousCell = 0;
            int numberLap;
            int[] blankCellsByColumns = new int[_maxColumns];
            Random random = new();
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    currentCell = random.Next(0, _maxColumns - 1);

                    if (currentCell == previousCell + 1)
                    {
                        numberLap = random.Next(0, 1);
                        if (numberLap == 1)
                            currentCell = previousCell;
                    }
                } while (currentCell == previousCell);

                blankCellsByColumns[currentCell] = 2;
                previousCell = currentCell;
            }

            for (int r = 0; r < _maxColumns; r++)
            {
                if (blankCellsByColumns[r] != 2)
                    blankCellsByColumns[r] = 1;
            }

            return blankCellsByColumns;
        }

        private static int[,] DefineBlankCellsByRows(int[,] card, int[] blankCellsByColumns)
        {
            int row0;
            int row1;
            Random random = new();

            for (var r = 0; r < 2; r++)
            {
                if (r == 0)
                {
                    do
                    {
                        row0 = 0;
                        for (int c0 = 0; c0 < 9; c0++)
                        {
                            card[r, c0] = random.Next(0, 3);
                            if (card[r, c0] > 0)
                            {
                                card[r, c0] = 1;
                                row0 += 1;
                                if (row0 == 5)
                                    break;
                            }
                        }
                    } while (row0 != 5);
                }
                else if (r == 1)
                {
                    do
                    {
                        row1 = 0;
                        for (int c1 = 0; c1 < 9; c1++)
                        {
                            if (card[r - 1, c1] == 1 && blankCellsByColumns[c1] == 2)
                            {
                                card[r, c1] = 0;
                                card[r + 1, c1] = 0;
                            }
                            else if (card[r - 1, c1] == 0 && blankCellsByColumns[c1] == 1)
                            {
                                card[r, c1] = 1;
                                card[r + 1, c1] = 1;
                            }
                            else if (blankCellsByColumns[c1] == 2 && card[r - 1, c1] == 0)
                            {
                                card[r, c1] = random.Next(0, 3);
                                if (card[r, c1] > 0)
                                {
                                    card[r, c1] = 1;
                                    card[r + 1, c1] = 0;
                                }
                                else
                                {
                                    card[r + 1, c1] = 1;
                                }
                            }
                            else if (blankCellsByColumns[c1] == 1 && card[r - 1, c1] == 1)
                            {
                                card[r, c1] = random.Next(0, 3);
                                if (card[r, c1] > 0)
                                {
                                    card[r, c1] = 1;
                                    card[r + 1, c1] = 0;
                                }
                                else
                                {
                                    card[r + 1, c1] = 1;
                                }
                            }
                            row1 += card[r, c1];
                        }
                    } while (row1 != 5);
                }
            }
            return card;
        }

        private void BuildMatrix(int[,] card)
        {
            DefineNumbersInCard(card, _range, _blankCellsByColumns);
            Numbers = GetNumbersFromCard(card);
            OrderedN = GetOrderedNumbersFromCard(card);
        }

        private static int[,] DefineNumbersInCard(int[,] card, int[,] range, int[] blankCellsByColumns) 
        {
            int currentNumber;
            int previousNumber = 0;
            for (var c = 0; c < 9; c++)
            {
                int Num1 = 0;
                int Num2 = 0;
                int Pos1 = 0;
                int Pos2 = 0;

                for (int r = 0; r < 3; r++)
                {
                    if (card[r, c] == 1)
                    {
                        do
                        {
                            Random randomNumber = new();
                            currentNumber = randomNumber.Next(range[0, c], range[1, c]);
                        } while (currentNumber == previousNumber);
                        card[r, c] = currentNumber;
                        previousNumber = currentNumber;

                        if (blankCellsByColumns[c] == 1)
                        {
                            if (Num1 == 0)
                            {
                                Num1 = card[r, c];
                                Pos1 = r;
                            }
                            else
                            {
                                Num2 = card[r, c];
                                Pos2 = r;
                            }
                        }
                    }
                }

                if (Num1 > Num2)
                {
                    card[Pos1, c] = Num2;
                    card[Pos2, c] = Num1;
                }
            }
            return card;
        }

        private static string GetNumbersFromCard(int[,]card) 
        {
            string numbers = string.Empty;
            for (int c = 0; c < _maxColumns; c++) 
            {
                for (int r = 0; r < _maxRows; r++)
                {
                    if (card[r, c] != 0) 
                        numbers += card[r, c].ToString() + ',';
                }
            }
            numbers = numbers[..^1];
            return numbers;
        }

        private static string GetOrderedNumbersFromCard(int[,] card) 
        {
            string numbers = string.Empty;
            for (int c = 0; c < 9; c++)
            {
                for (int r = 0; r < 3; r++)
                {
                    if (r == 0 && c == 0)
                    {
                        if (card[r, c] != 0) 
                            numbers = card[r, c].ToString();
                    }
                    else
                    {
                        numbers += ",";
                        if (card[r, c] > 0)
                            numbers += card[r, c].ToString();
                    }
                }
            }
            return numbers;
        }
    }
}
