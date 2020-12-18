#include<iostream>
#include<conio.h>
#include<ctime>

using namespace std;

void insertionSort(int *mas, int n)
{
	int tmp, i;
	for (int j = 1; j < n; j++)
	{
		tmp = mas[j];
		for (i = j - 1; (i >= 0) && (mas[i] > tmp); i--)
		{
			mas[i + 1] = mas[i];
		}
		mas[i + 1] = tmp;
	}
}
void selectionSort(int *mas, int n)
{
	int tmp;
	for (int i = 0; i<n; i++)
		for (int j = i; j<n; j++)
			if (mas[j] < mas[i])
			{
				tmp = mas[j];
				mas[j] = mas[i];
				mas[i] = tmp;
			}
}
void bubleSort(int *mas, int n)
{
	int tmp;
	for (int j = n - 1; j>0; j--)
		for (int i = 0; i<j; i++)
			if (mas[i] > mas[i + 1])
			{
				tmp = mas[i];
				mas[i] = mas[i + 1];
				mas[i + 1] = tmp;
			}
}
void sheykerSort(int*mas, int n)
{
	int tmp;
	bool checking;
	do
	{
		checking = false;
		for (int i = n - 1; i>0; i--)
			if (mas[i - 1] > mas[i])
			{
				tmp = mas[i - 1];
				mas[i - 1] = mas[i];
				mas[i] = tmp;
				checking = true;
			}
		for (int i = 1; i<n; i++)
			if (mas[i - 1]>mas[i])
			{
				tmp = mas[i - 1];
				mas[i - 1] = mas[i];
				mas[i] = tmp;
				checking = true;
			}
	} while (checking);
}
void shellaSort(int *mas, int n)
{
	for (int d = n / 2; d >= 1; d /= 2)
		for (int i = d; i < n; i++)
			for (int j = i; j >= d && mas[j - d] > mas[j]; j -= d)
			{
				//swap(mas[j], mas[j - d]);
				int tmp = mas[j];
				mas[j] = mas[j - d];
				mas[j - d] = tmp;
			}
}
void quickSort(int *mas, int left, int right)
{
	int i = left, j = right, tmp = 0;
	int centr = mas[(left + right) / 2];
	while (i <= j)
	{
		while (mas[i] < centr)
			i++;
		while (mas[j] > centr)
			j--;
		if (i <= j)
		{
			tmp = mas[i];
			mas[i] = mas[j];
			mas[j] = tmp;
			i++;
			j--;
		}
	}
	if (left < j)
		quickSort(mas, left, j);
	if (i<right)
		quickSort(mas, i, right);
}

int main()
{
	int n;
	cout << "Enter size of array: ";
	cin >> n;
	int *mas = new int[n];
	srand(time(NULL));
	for (int i = 0; i < n; i++)
		*(mas + i) = rand() % 100 + 1;
	//for (int i = 0; i < n; i++)
	//	cout << mas[i] << "  ";
	cout << endl;
	//Insert-----------------------------------------------------------------------------------------------------------
	int a1 = clock();
	insertionSort(mas, n);
	cout << "\n\nSorted array from INSERT sorting are: " << endl;
	//for (int i = 0; i < n; i++)
	 // cout << mas[i] << "  ";
	int a2 = clock();
	cout <<"\nTime of working INSERT sortint is: "<< double(a2 - a1) / CLOCKS_PER_SEC << endl;
	for (int i = 0; i < n; i++)
		*(mas + i) = rand() % 100 + 1;
	//Select------------------------------------------------------------------------------------------------------------
	int b1 = clock();
	selectionSort(mas, n);
	cout << "\n\nSorted array from SELECT sorting are: " << endl;
	//for (int i = 0; i < n; i++)
	//	cout << mas[i] << "  ";
	int b2 = clock();
	cout << "\nTime of working SELECT sortint is: " << double(b2 - b1) / CLOCKS_PER_SEC << endl;
	//Buble------------------------------------------------------------------------------------------------------------
	for (int i = 0; i < n; i++)
		*(mas + i) = rand() % 100 + 1;
	//for(int i=0;i<n;i++)
	//cout << "_______" << mas[i] << " ";
	int c1 = clock();
	bubleSort(mas, n);
	cout << "\n\nSorted array from BUBLE sort are: " << endl;
	//for (int i = 0; i < n; i++)
	//	cout << mas[i] << "  ";
	int c2 = clock();
	cout << "\nTime of working BUBLE sort is: " << double(c2 - c1) / CLOCKS_PER_SEC << endl;
	//Sheyker----------------------------------------------------------------------------------------------------------
	for (int i = 0; i < n; i++)
		*(mas + i) = rand() % 100 + 1;
	//for (int i = 0; i<n; i++)
		//cout << "_______" << mas[i] << " ";
	int d1 = clock();
	sheykerSort(mas, n);
	cout << "\n\nSorted array from SHEYKER sort are: " << endl;
	//for (int i = 0; i < n; i++)
		//cout << mas[i] << "  ";
	int d2 = clock();
	cout << "\nTime of working SHEYKER sort is: " << double(d2 - d1) / CLOCKS_PER_SEC << endl;
	//Shella------------------------------------------------------------------------------------------------------------
	for (int i = 0; i < n; i++)
		*(mas + i) = rand() % 100 + 1;
	int e1 = clock();
	shellaSort(mas, n);
	cout << "\n\nSorted array from SHELLA sort are: " << endl;
	//for (int i = 0; i < n; i++)
		//cout << mas[i] << "  ";
	int e2 = clock();
	cout << "\nTime of working SHELLA sort is: " << double(e2 - e1) / CLOCKS_PER_SEC << endl;
	//Quick Sort---------------------------------------------------------------------------------------------------------
	for (int i = 0; i < n; i++)
		*(mas + i) = rand() % 100 + 1;
	int f1 = clock();
	quickSort(mas, 0,n-1);
	cout << "\n\nSorted array from QUICK sort are: " << endl;
	//for (int i = 0; i < n; i++)
		//cout << mas[i] << "  ";
	int f2 = clock();
	cout << "\nTime of working QUICK sort is: " << double(f2 - f1) / CLOCKS_PER_SEC << endl;
	delete [] mas;
	_getch();
	return 0;
}

