# MatrixLib
MatrixLib is a c# library that helps you to create matrices and do matrix calculations in c#. It is very simple to use.

## How to add 
You need to download the dll , or you can build the dll from the source code.

 - Create a project 
 - Open solution explorer menu
 ![Add reference](https://user-images.githubusercontent.com/58172827/76756158-3f1f6980-6796-11ea-84b7-ddd2127e99b4.png)
 - Right click on references and click *Add Reference*
 -![Reference Manager](https://user-images.githubusercontent.com/58172827/76756231-64ac7300-6796-11ea-9887-e102eece8819.png)
 - Click *Browse*
![Select the files to reference](https://user-images.githubusercontent.com/58172827/76756312-7f7ee780-6796-11ea-9156-e3c879de62d8.png)
 - Select **MatrixLib.dll** and click *Add*
 ![enter image description here](https://user-images.githubusercontent.com/58172827/76756371-98879880-6796-11ea-9b0a-52177fc729a2.png)
 - We have successfully added the library .
 - Don't forget the include the library.
 - ![import matrixlib](https://user-images.githubusercontent.com/58172827/76756411-ac32ff00-6796-11ea-8688-ac695338581b.png)
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
![enter image description here](https://user-images.githubusercontent.com/58172827/76756497-da184380-6796-11ea-8fb2-9cd84e65f248.png)

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
![enter image description here](https://user-images.githubusercontent.com/58172827/76756562-f916d580-6796-11ea-880a-3785b4226b7b.png)

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
![enter image description here](https://user-images.githubusercontent.com/58172827/76756645-2a8fa100-6797-11ea-96e3-19414d14425f.png)

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
![enter image description here](https://user-images.githubusercontent.com/58172827/76756702-45621580-6797-11ea-8763-0a05a691402d.png)

## Matrix row length and column length
You may want to get row length and column length of the matrix.
There are two properties for that;
```csharp
Matrix matrix = new Matrix("[12 6 3;15 56 88;55 32 18]");
Console.WriteLine("Row length of the matrix is = " + matrix.RowLength);
Console.WriteLine("Column length of the matrix is = " + matrix.ColLength);  
```
Output is : 
![enter image description here](https://user-images.githubusercontent.com/58172827/76756758-5f9bf380-6797-11ea-9e54-9c30eea3ef8b.png)

## Displaying matrices
There are ToString() method to display matrices.
```csharp
Matrix matrix = new Matrix("[12 6 3;15 56 88;55 32 18]");
Console.WriteLine(matrix.ToString());
```
Output is:
![enter image description here](https://user-images.githubusercontent.com/58172827/76756801-78a4a480-6797-11ea-998c-ca24075747d5.png)

## Getting and setting matrix elements
We can get and set matrix elements by using indexer.

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
![enter image description here](https://user-images.githubusercontent.com/58172827/76756855-970aa000-6797-11ea-8334-efeda21679b8.png)
### Subtraction
```csharp
Matrix m1 = new Matrix("[12 6 3;15 56 88;55 32 18]");
Matrix m2 = new Matrix("[8 5 4;12 55 12;43 18 12]");
Matrix m3 = m2 - m1;
Console.WriteLine(m3.ToString());
```
if the row and column lengths of the matrices are not equal this will throw **MatrixSubtractionException**
Output is:
![enter image description here](https://user-images.githubusercontent.com/58172827/76756921-b43f6e80-6797-11ea-894b-b058cf886354.png)
### Multiplication
```csharp
Matrix m1 = new Matrix("[1 2;2 0;3 1]");
Matrix m2 = new Matrix("[4 3;1 2]");
Matrix m3 = m1* m2;
Console.WriteLine(m3.ToString());
```
if the number of columns of the first matrix is ​​not equal to the number of rows of the second matrix this will throw **MatrixMultiplicationException**
Output is :
![enter image description here](https://user-images.githubusercontent.com/58172827/76757013-db963b80-6797-11ea-8977-fd666616b473.png)
#### Multiplication matrix with scalar number
```csharp
   Matrix m1 = new Matrix("[1 2;2 0;3 1]");
   Matrix m3 = m1* 2;
   Console.WriteLine(m3.ToString());
```
Output is:
![enter image description here](https://user-images.githubusercontent.com/58172827/76757052-f5378300-6797-11ea-80b5-f122ed1b4014.png)

## Transpose of the matrix

You can easily get the transpose of the matrix using Transpose(); method.
```csharp
   Matrix m1 = new Matrix("[2 6 7;3 6 2;4 6 5]");
   Matrix m2 = m1.Transpose();
   Console.WriteLine(m2.ToString());
```
Output is :
![enter image description here](https://user-images.githubusercontent.com/58172827/76757241-50697580-6798-11ea-9552-4b80039a999e.png)
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

