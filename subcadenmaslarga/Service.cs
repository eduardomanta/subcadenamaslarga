namespace subcadenmaslarga
{
    public class Service
    {
        public readonly string[] _lines;

        public Service(string[] lines)
        {
            _lines = lines;
        }

        public string[,] GetArray()
        {
            string[,] array = new string[_lines.Length, _lines.Length];

            for (int i = 0; i < _lines.Length; i++)
            {
                if (string.IsNullOrEmpty(_lines[i])) continue;
                string[] letters = _lines[i].Split(",");
                if (letters.Length == 0) continue;
                if (letters.Length != _lines.Length) continue;

                for (int j = 0; j < letters.Length; j++)
                {
                    array[i, j] = letters[j]?.Trim() ?? "";
                }
            }
            return array;
        }

        public void Evaluating(string characterArray, ResultModel resultAux, ResultModel result)
        {
            if (string.IsNullOrEmpty(characterArray)) return;

            if (resultAux.character != characterArray)
            {
                resultAux.character = characterArray;
                resultAux.count = 1;
            }
            else
            {
                resultAux.count++;
                if (resultAux.count > result.count)
                {
                    result.count = resultAux.count;
                    result.character = resultAux.character;
                }
            }
        }

        public void FindHorizontalOrVertical(string[,] array, int i, bool horizontal, ResultModel resultAux, ResultModel result)
        {
            for (int j = 0; j < _lines.Length; j++)
            {
                if (horizontal)
                    Evaluating(array[i, j], resultAux, result);
                else
                    Evaluating(array[j, i], resultAux, result);
            }

            if (resultAux.count > result.count)
            {
                result.count = resultAux.count;
                result.character = resultAux.character;
            }
        }

        public void FindDiagonal(string[,] array, ResultModel resultAux, ResultModel result)
        {
            for (int i = 0; i < _lines.Length; i++)
            {
                for (int j = 0; j < _lines.Length; j++)
                {
                    #region top left
                    if (i > 0 && j > 0)
                    {
                        resultAux = new ResultModel("", 1);
                        int count = 0;
                        for (int r = i; r >= 0; r--)
                        {
                            if (j - count < 0) break;
                            Evaluating(array[r, j - count], resultAux, result);
                            count++;
                        }
                    }

                    if (resultAux.count > result.count)
                    {
                        result.count = resultAux.count;
                        result.character = resultAux.character;
                    }

                    #endregion

                    #region top right
                    if (i > 0 && j < _lines.Length - 1)
                    {
                        resultAux = new ResultModel("", 1);
                        int count = 0;
                        for (int r = i; r >= 0; r--)
                        {
                            if (j + count > _lines.Length - 1) break;
                            Evaluating(array[r, j + count], resultAux, result);
                            count++;
                        }
                    }

                    if (resultAux.count > result.count)
                    {
                        result.count = resultAux.count;
                        result.character = resultAux.character;
                    }
                    #endregion

                    #region bottom left
                    if (i < _lines.Length - 1 && j > 0)
                    {
                        resultAux = new ResultModel("", 1);
                        int count = 0;
                        for (int r = i; r < _lines.Length; r++)
                        {
                            if (j - count < 0) break;
                            Evaluating(array[r, j - count], resultAux, result);
                            count++;
                        }
                    }

                    if (resultAux.count > result.count)
                    {
                        result.count = resultAux.count;
                        result.character = resultAux.character;
                    }
                    #endregion

                    #region bottom right
                    if (i < _lines.Length - 1 && j < _lines.Length - 1)
                    {
                        resultAux = new ResultModel("", 1);
                        int count = 0;
                        for (int r = i; r < _lines.Length; r++)
                        {
                            if (j + count > _lines.Length - 1) break;
                            Evaluating(array[r, j + count], resultAux, result);
                            count++;
                        }
                    }

                    if (resultAux.count > result.count)
                    {
                        result.count = resultAux.count;
                        result.character = resultAux.character;
                    }
                    #endregion
                }
            }
        }

    }

    public class ResultModel
    {
        public ResultModel(string character, int max)
        {
            this.count = max;
            this.character = character;
        }

        public int count { get; set; }
        public string character { get; set; }
    }
}
