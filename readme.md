# MatrixLib
MatrixLib is a c# library that helps you to create matrices and do matrix calculations in c#. It is very simple to use.

## How to add 
You need to download the dll , or you can build the dll from the source code.

 - Create a project 
 - Open solution explorer menu
 ![Add reference](https://i.ibb.co/y4XJZFK/Annotation-2019-11-24-170306.png)
 - Right click on references and click *Add Reference*
 -![Reference Manager](https://i.ibb.co/Tqg3NdJ/Annotation-2019-11-24-170444.png)
 - Click *Browse*
![Select the files to reference](https://i.ibb.co/PzzSpkc/Annotation-2019-11-24-170600.png)
 - Select **MatrixLib.dll** and click *Add*
 ![enter image description here](https://i.ibb.co/rtj1Jpb/Annotation-2019-11-24-170655.png)
 - We have successfully added the library .
 - Don't forget the include the library.
 - ![enter image description here](https://i.ibb.co/GR90WGW/Annotation-2019-11-24-171947.png)
 - Now we are ready to use the library

## Create matrix

There are different ways to create matrix , but one of them is 
### Empty matrix creation
   ```csharp
   Matrix matrix = new Matrix(3,3);
```
We specified the row length and column length of the matrix. 
After doing that we can add rows and columns. Adding rows and columns will be explained later.
### Matlab like matrix creation
```csharp
   Matrix matrix = new Matrix("[12 6 3;15 56 88;55 32 18]");
```
Created matrix will look like:
![enter image description here](https://i.ibb.co/H7t95B7/Annotation-2019-11-24-173412.png)

You have to type ';' semicolon after row.
You have to type space after element.
Typing unnecessary spaces causes error.

If the string is not in desired format this will throw **MatrixFormatException**
You can catch it :)

### Create matrix from two dimensional double array
```csharp
   double[,] twoDimensionalArr = new double[2, 2] {
    {80,9 },
    {16,71 }
    };
    Matrix matrix = new Matrix(twoDimensionalArr);
    
```
Created matrix will look like:
![enter image description here](https://i.ibb.co/txzfss7/Annotation-2019-11-24-173412.png)

## Adding rows and columns

There are 2 functions to adding rows and columns;

**Adding as rows**
*AddAssRow(int index, double [] arr)*

```csharp
   Matrix matrix = new Matrix(3,3);
   double[] row1 = { 1, 6, 6 };
   double[] row2 = { 5, 7, 3 };
   double[] row3 = { 3, 4, 8 };
   matrix.AddAsRow(1 , row1);
   matrix.AddAsRow(2 , row2);
   matrix.AddAsRow(3 , row3)
    
```
Matrix will look like:
![enter image description here](https://i.ibb.co/47RkN7D/Annotation-2019-11-24-203554.png)
***Adding as columns***
*AddAssColumn(int index, double [] arr)*
```csharp
 Matrix matrix = new Matrix(3,3);
 double[] col1 = { 7, 4, 1 };
 double[] col2 = { 4, 5, 7 };
 double[] col3 = { 9, 8, 6 };
 matrix.AddAsColumn(1 , col1);
 matrix.AddAsColumn(2 , col2);
 matrix.AddAsColumn(3,  col3);
    
```
Matrix will look like:
![enter image description here](https://i.ibb.co/0qyQ1dv/Annotation-2019-11-24-204104.png)

## Matrix row length and column length
You may want to get row length and column length of the matrix.
There are two properties for that;
```csharp
Matrix matrix = new Matrix("[12 6 3;15 56 88;55 32 18]");
Console.WriteLine("Row length of the matrix is = " + matrix.RowLength);
Console.WriteLine("Column length of the matrix is = " + matrix.ColLength);  
```
Output is : 
![enter image description here](https://i.ibb.co/Ns591vQ/Annotation-2019-11-24-204104.png)

## Displaying matrices
There are ToString() method for displaying matrices.
```csharp
Matrix matrix = new Matrix("[12 6 3;15 56 88;55 32 18]");
Console.WriteLine(matrix.ToString());
```
Output is:
![enter image description here](https://i.ibb.co/PmP3byR/Annotation-2019-11-24-204104.png)

## Getting and setting matrix elements
We can get and set matrix elements using indexer.

Getting matrix element

```csharp
Matrix matrix = new Matrix("[12 6 3;15 56 88;55 32 18]");
Console.WriteLine(matrix[1,1]);
// this will output the first row and first column element (12)
```
Setting matrix element
```csharp
Matrix matrix = new Matrix("[12 6 3;15 56 88;55 32 18]");
matrix[2, 3] = 42;
 //this will change the second row and third column element to (42)
```

## Matrix addition , subtraction and multiplication

You can simply add or subtract matrices like int or double.
### Addition
```csharp
Matrix m1 = new Matrix("[12 6 3;15 56 88;55 32 18]");
 Matrix m2 = new Matrix("[8 5 4;12 55 12;43 18 12]");
Matrix m3 = m2 + m1;
Console.WriteLine(m3.ToString());
```
if the row and column lengths of the matrices are not equal this will throw **MatrixAdditionException**

Output is:
![enter image description here](https://i.ibb.co/PcGBcHL/Annotation-2019-11-24-212147.png)
### Subtraction
```csharp
Matrix m1 = new Matrix("[12 6 3;15 56 88;55 32 18]");
Matrix m2 = new Matrix("[8 5 4;12 55 12;43 18 12]");
Matrix m3 = m2 - m1;
Console.WriteLine(m3.ToString());
```
if the row and column lengths of the matrices are not equal this will throw **MatrixSubtractionException**
Output is:
![enter image description here](https://i.ibb.co/qFqsYqy/Annotation-2019-11-24-212147.png)
### Multiplication
```csharp
Matrix m1 = new Matrix("[1 2;2 0;3 1]");
Matrix m2 = new Matrix("[4 3;1 2]");
Matrix m3 = m1* m2;
Console.WriteLine(m3.ToString());
```
if the number of columns of the first matrix is ​​not equal to the number of rows of the second matrix this will throw **MatrixMultiplicationException**
Output is :
![enter image description here](https://i.ibb.co/QcV7PPd/Annotation-2019-11-24-212147.png)
#### Multiplication matrix with scalar number
```csharp
   Matrix m1 = new Matrix("[1 2;2 0;3 1]");
   Matrix m3 = m1* 2;
   Console.WriteLine(m3.ToString());
```
Output is:
![enter image description here](https://i.ibb.co/7SWkVyn/Annotation-2019-11-24-212147.png)

## Transpose of the matrix

You can easily get the transpose of the matrix using Transpose(); method.
```csharp
   Matrix m1 = new Matrix("[2 6 7;3 6 2;4 6 5]");
   Matrix m2 = m1.Transpose();
   Console.WriteLine(m2.ToString());
```
Output is :
![enter image description here](https://i.ibb.co/XYzyj36/Annotation-2019-11-24-221247.png)
## Determinant of the matrix
There is Det(); method for calculate determinant.
```csharp
   Matrix m1 = new Matrix("[1 5 3;2 4 7;4 6 2]");          
   Console.WriteLine(m1.Det());
   // output is (74)
```
If matrix is not square this will throw **MatrixIsNotSquareException**
## Turning matrix into two dimensional double array

```csharp
   Matrix m1 = new Matrix("[1 5 3;2 4 7;4 6 2]");
   double[,] arr = m1.ToDoubleArray();
   
```
## Contributors

 - Emir Yusuf Topbaş <emiryusuftopbas@gmail.com>
## License & copyright
Licensed under the [MIT License](LICENSE)

