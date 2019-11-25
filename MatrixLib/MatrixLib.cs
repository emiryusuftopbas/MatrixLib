using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    class RowLengthException : Exception
    {
        public RowLengthException(string message) : base(message)
        {

        }
    }
    class ColumnLengthException : Exception
    {
        public ColumnLengthException(string message) : base(message)
        {

        }
    }
    class MatrixIndexOutOfBoundsException : Exception
    {
        public MatrixIndexOutOfBoundsException(string message) : base(message)
        {

        }
    }
    class MatrixAdditionException : Exception
    {
        public MatrixAdditionException(string message) : base(message)
        {
            message = "You cannot add matrices that are not equal";
        }
    }
    class MatrixSubtractionException : Exception
    {
        public MatrixSubtractionException(string message) : base(message)
        {
            message = "You cannot subtract matrices that are not equal";
        }
    }
    class MatrixMultiplicationException : Exception
    {
        public MatrixMultiplicationException(string message) : base(message)
        {

        }
    }
    class MatrixFormatException : Exception
    {
        public MatrixFormatException(string message) : base(message)
        {

        }
    }
    class MatrixIsNotSquareException : Exception
    {
        public MatrixIsNotSquareException(string message) : base(message)
        {

        }
    }
    class ArrayCanNotConvertibleException : Exception
    {
        public ArrayCanNotConvertibleException(string message) : base(message)
        {

        }
    }
    public class Matrix
    {

        int _rowLength;
        int _colLength;
        double[,] matrixArr;

        /// <summary>
        /// Returns row length of the matrix
        /// </summary>
        /// <returns>Row length of the matrix.</returns>
        public int RowLength
        {
            get
            {
                return _rowLength;
            }

        }

        /// <summary>
        /// Returns column length of the matrix
        /// </summary>
        /// <returns>Column length of the matrix.</returns>
        public int ColLength
        {
            get
            {
                return _colLength;
            }
        }

        private void SetColLength(int value)
        {
            if (value < 0)
            {
                throw new ColumnLengthException("must be greater than or equal to zero");
            }
            else
            {
                _colLength = value;
            }
        }
        private void SetRowLength(int value)
        {
            if (value < 0)
            {
                throw new RowLengthException("must be greater than or equal to zero");
            }
            else
            {
                _rowLength = value;
            }
        }

        /// <summary>
        /// Creates matrix.
        /// </summary>
        /// <param name="rowLength">Row length.</param>
        /// <param name="colLength">Column length.</param>
        public Matrix(int rowLength, int colLength)
        {
            SetRowLength(rowLength);
            SetColLength(colLength);

            matrixArr = new double[this.RowLength, this.ColLength];
        }

        /// <summary>
        /// Creates matrix from given string.
        /// </summary>
        /// <param name="query">Matlab like matrix definition sytantax [ ; ;] ';' represents rows.</param>
        public Matrix(string query)
        {
            string[] splittedToSBO = query.Split('[');
            string[] splittedToSBC = splittedToSBO[1].Split(']');
            string[] splittedToSemiColon = splittedToSBC[0].Split(';');
            if (splittedToSBO.Length == 2 && splittedToSBO.Length == 2 && CheckRowColFormat(splittedToSemiColon))
            {
                SetRowLength(splittedToSemiColon.Length);
                SetColLength(splittedToSemiColon[0].Split(' ').Length);

                matrixArr = new double[RowLength, ColLength];

                for (int i = 0; i < RowLength; i++)
                {
                    string[] splittedToSpace = splittedToSemiColon[i].Split(' ');

                    for (int j = 0; j < ColLength; j++)
                    {
                        matrixArr[i, j] = Convert.ToDouble(splittedToSpace[j]);
                    }
                }
            }
            else
            {
                throw new MatrixFormatException("Matrix not in desired format");
            }
        }

        /// <summary>
        /// Creates matrix from two-dimensional double array.
        /// </summary>
        /// <param name="matrix">two-dimensional double array.</param>
        public Matrix(double[,] matrix)
        {
            SetRowLength(matrix.GetLength(0));
            SetColLength(matrix.GetLength(0));
            matrixArr = new double[RowLength, ColLength];
            if (matrix.Length == (matrix.GetLength(0) * matrix.GetLength(1)))
            {
                for (int i = 0; i < RowLength; i++)
                {
                    for (int j = 0; j < ColLength; j++)
                    {
                        matrixArr[i, j] = matrix[i, j];
                    }
                }
            }
            else
            {
                throw new MatrixIsNotSquareException("Array can not convertible exception");
            }

        }

        private bool CheckRowColFormat(string[] splittedToSemiColon)
        {
            int rowLength = splittedToSemiColon.Length;

            int[] columnLengths = new int[rowLength];
            List<bool> convertibleOrNot = new List<bool>();
            double fortest;
            for (int i = 0; i < rowLength; i++)
            {
                columnLengths[i] = splittedToSemiColon[i].Split(' ').Length;
                for (int j = 0; j < splittedToSemiColon[i].Split(' ').Length; j++)
                {
                    string el = splittedToSemiColon[i].Split(' ')[j];
                    convertibleOrNot.Add(double.TryParse(el, out fortest));

                }
            }

            if ((columnLengths.Max() == columnLengths.Max()) && !convertibleOrNot.Contains(false))
                return true;
            return false;
        }


        public double this[int rowIndex, int colIndex]
        {
            set
            {
                matrixArr[rowIndex - 1, colIndex - 1] = value;
            }
            get
            {
                return matrixArr[rowIndex - 1, colIndex - 1];
            }
        }

        /// <summary>
        /// Returns transpose of the matrix.
        /// </summary>
        /// <returns>Transpose of matrix </returns>
        public Matrix Transpose()
        {
            Matrix result = new Matrix(ColLength, RowLength);
            for (int i = 1; i <= RowLength; i++)
            {
                for (int j = 1; j <= ColLength; j++)
                {
                    result[i, j] = this[j, i];

                }
            }
            return result;
        }


        double DetCalc(int n, double[,] matrix)
        {
            double d = 0;
            int subi, subj;

            double[,] subMatrix = new double[n, n];

            if (n == 1)
            {
                return matrix[0, 0];
            }
            else if (n == 2)
            {
                return ((matrix[0, 0] * matrix[1, 1]) - (matrix[1, 0] * matrix[0, 1]));
            }
            else
            {
                for (int k = 0; k < n; k++)
                {
                    subi = 0;
                    for (int i = 1; i < n; i++)
                    {
                        subj = 0;
                        for (int j = 0; j < n; j++)
                        {
                            if (j == k)
                            {
                                continue;
                            }
                            subMatrix[subi, subj] = matrix[i, j];
                            subj++;
                        }
                        subi++;
                    }
                    d = d + (Math.Pow(-1, k) * matrix[0, k] * DetCalc(n - 1, subMatrix));
                }
            }
            return d;
        }

        /// <summary>
        /// Determinant calculator function.
        /// </summary>
        /// <returns>Determinant of the matrix</returns>
        public double Det()
        {
            if (ColLength != RowLength)
                throw new MatrixIsNotSquareException("Matrix must be square matrix");
            else
                return DetCalc(Convert.ToInt32(Math.Sqrt(matrixArr.Length)), matrixArr);
        }



        /// <summary>
        /// Adds rows to matrix.
        /// </summary>
        /// <param name="rowIndex">Id of the row to add.</param>
        /// <param name="rowArr">Double array of row elements.</param>
        /// <returns>Nothing.</returns>
        public void AddAsRow(int rowIndex, double[] rowArr)
        {
            if ((rowIndex > RowLength) || (rowIndex <= 0) || (rowArr.Length > ColLength))
            {
                throw new MatrixIndexOutOfBoundsException("");
            }
            else
            {
                for (int i = 0; i < rowArr.Length; i++)
                {
                    matrixArr[rowIndex - 1, i] = rowArr[i];
                }
            }

        }
        /// <summary>
        /// Adds columns to matrix.
        /// </summary>
        /// <param name="rowIndex">Id of the column to add.</param>
        /// <param name="rowArr">Double array of column elements.</param>
        /// <returns>Nothing.</returns>
        public void AddAsColumn(int colIndex, double[] colArr)
        {
            if ((colIndex > ColLength) || (colIndex <= 0) || (colArr.Length > ColLength))
            {
                throw new MatrixIndexOutOfBoundsException("");
            }
            else
            {
                for (int i = 0; i < colArr.Length; i++)
                {
                    matrixArr[i, colIndex - 1] = colArr[i];
                }
            }
        }

        /// <summary>
        /// Returns a double array that represents the current matrix.
        /// </summary>
        /// <returns>A double array that represents the current matrix.</returns>
        public double[,] ToDoubleArray()
        {
            return matrixArr;
        }

        /// <summary>
        /// Returns a string that represents the current matrix.
        /// </summary>
        /// <returns>A string that represents the current matrix..</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < RowLength; i++)
            {
                str.Append("| ");
                for (int j = 0; j < ColLength; j++)
                {
                    str.Append(matrixArr[i, j] + " ");
                }
                str.Append("|");

                str.Append("\n");
            }
            return str.ToString();
        }

        public override bool Equals(Object obj)
        {

            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Matrix m1 = (Matrix)obj;
                bool isRowLengthEqual = this.RowLength == m1.RowLength;
                bool isColLengthEqual = this.ColLength == m1.RowLength;
                List<bool> isElementsEqual = new List<bool>();
                for (int i = 1; i <= RowLength; i++)
                {
                    for (int j = 1; j <= ColLength; j++)
                    {
                        if (this[i, j] == m1[i, j])
                            isElementsEqual.Add(true);
                        else
                            isElementsEqual.Add(false);
                    }
                }
                return isRowLengthEqual && isColLengthEqual && !isElementsEqual.Contains(false);

            }
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix(m1.RowLength, m2.ColLength);
            if (!(m1.RowLength == m2.RowLength) || !(m1.ColLength == m2.ColLength))
            {
                throw new MatrixAdditionException("");
            }
            else
            {
                for (int i = 1; i <= m1.RowLength; i++)
                {
                    for (int j = 1; j <= m1.ColLength; j++)
                    {
                        result[i, j] = m1[i, j] + m2[i, j];


                    }
                }
                return result;
            }
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix(m1.RowLength, m2.ColLength);
            if (!(m1.RowLength == m2.RowLength) || !(m1.ColLength == m2.ColLength))
            {
                throw new MatrixSubtractionException("");
            }
            else
            {
                for (int i = 1; i <= m1.RowLength; i++)
                {
                    for (int j = 1; j <= m1.ColLength; j++)
                    {
                        result[i, j] = m1[i, j] - m2[i, j];
                    }
                }
                return result;
            }
        }


        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (!(m1.ColLength == m2.RowLength))
            {
                throw new MatrixMultiplicationException("");
            }
            else
            {
                Matrix result = new Matrix(m1.RowLength, m2.RowLength);

                for (int i = 1; i <= m1.RowLength; i++)
                {
                    for (int j = 1; j <= m2.ColLength; j++)
                    {
                        result[i, j] = 0;
                        for (int r = 1; r <= m1.ColLength; r++)
                        {
                            result[i, j] += m1[i, r] * m2[r, j];
                        }
                    }
                }

                return result;
            }
        }
        public static Matrix operator *(Matrix m1, double number)
        {

            Matrix result = new Matrix(m1.RowLength, m1.ColLength);

            for (int i = 1; i <= m1.RowLength; i++)
            {
                for (int j = 1; j <= m1.ColLength; j++)
                {
                    result[i, j] = Convert.ToDouble(m1[i, j]) * number;
                }
            }

            return result;
        }


    }
}
