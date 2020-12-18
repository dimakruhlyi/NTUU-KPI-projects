#include<iostream>
#include<stdio.h>
#include<stdlib.h>
#include<conio.h>
#include<locale.h>
#include<ctime>
#include<math.h>
#define á 0.045
#define A 70

using namespace std;

struct Values {
	double x1;
	double x2;
	double dx;
	double *fx;
};

double round(double x)
{
	int precision = 2;
	int mul = 1;

	for (int i = 0; i < precision; i++)
	{
		mul *= 10;
	}
 //cout << floor(x * mul + .5) / mul << endl;
	return floor(x * mul + .5) / mul;

}

void ReadPar(double *a, double *b, int *size, Values &str)
{
	printf("Enter value first parametr: ");
	scanf_s("%lf", &(*a));
	printf("Enter value second parametr: ");
	scanf_s("%lf", &(*b));
	printf("Enter the first boundary value: ");
	scanf_s("%lf", &str.x1);
	printf("Enter the second boundary value: ");
	scanf_s("%lf", &str.x2);
	printf("Enter step: ");
	scanf_s("%lf", &str.dx);

	(*size) = (str.x2 - str.x1) / round(str.dx) + 1;
}

void Tab(Values &str, int *count_int, double a, double b, int size)
{
	double eps = 0.1;
	int i = 0;

	printf("%c", 201);
	for (int i = 0; i < 11; i++) printf("%c", 205);
	printf("%c", 203);
	for (int i = 0; i < 10; i++) printf("%c", 205);
	printf("%c\n", 187);

	printf("%c    f(x)   %c      x   %c\n", 186, 186, 186);

	while (i<size) {
		if (str.x1 <= 1)
		{
			str.fx[i] = a*str.x1*str.x1 - b;
			if (str.fx[i]>0 && str.fx[i]<A)
				(*count_int)++;
		}
		else
		{
			str.fx[i] = a / (str.x1 + b);
			if (str.fx[i]>0 && str.fx[i]<A)
				(*count_int)++;
		}
		printf("%c", 204);
		for (int i = 0; i < 11; i++) printf("%c", 205);
		printf("%c", 206);
		for (int i = 0; i < 10; i++) printf("%c", 205);
		printf("%c\n", 185);

		printf("%c%8.3f%4.0c%7.1f   %c\n", 186, str.fx[i], 186, str.x1, 186);

		i++;
		str.x1 += str.dx;
	}

	printf("%c", 200);
	for (int i = 0; i < 11; i++) printf("%c", 205);
	printf("%c", 202);
	for (int i = 0; i < 10; i++) printf("%c", 205);
	printf("%c\n", 188);
}

void Print(const int *intf, int size) {
	printf("\n");
	for (int j = 0; j < size; j++) {
		for (int i = 0; i < intf[j]; i++) {
			printf(" ");
		}
		printf("%c\n", 0xB0);
	}
}

void selectionSort(double *mas, int size)
{
	double tmp;
	for (int i = 0; i<size; i++)
		for (int j = i; j<size; j++)
			if (mas[j] < mas[i])
			{
				tmp = mas[j];
				mas[j] = mas[i];
				mas[i] = tmp;
			}
}

void Norm(double *fx, int *intf, int size)
{
	double max = fx[0], min = fx[0];

	for (int i = 1; i < size; i++)
	{
		if (max < fx[i]) max = fx[i];
		if (min > fx[i]) min = fx[i];
	}

  for (int i = 0; i < size; i++)
	{
		fx[i] -= min;
	}

	double koef = A / (max - min);

	for (int i = 0; i < size; i++)
	{
		fx[i] *= koef;
	}

	int t = 0;
	for (int j = 0; j < size; j++)
	{
		if (fx[j] >= 0 && fx[j] <= A)
		{
			intf[t] = int(fx[j] + 0.5);
			t++;
		}
	}
}

void getS(Values str, double *rnd, int size) {
	srand(time(NULL));
	double S1 = 0;
	double S2 = str.fx[0];
	int  count = 0;
	for (int i = 0; i <size; i++)
	{
		if (str.fx[i] > 0)
		{
			S1 += str.fx[i]; count++;
		}
		if (str.fx[i] > S2)
		{
			S2 = str.fx[i];

		}
	}
	S1 /= count;

	printf("\nS1 = %0.4f\n", S1);
	printf("S2 = %0.4f\n", S2);

	double Smax = 0, Smin = 0;
	if (S1 > S2) { Smax = S1; Smin = S2; }
	else { Smax = S2; Smin = S1; }
	double Sser = (Smin + Smax) / 2;

	const double st = fabs(á * Sser);
	const int max_i = fabs(Smax - Smin) / st;

	printf("Step's value for random array: %f \n", st);
	printf("\n\n\n");
	for (int i = 0; i < size; ++i) {
		rnd[i] = Smin + (rand() % (max_i + 1))*st;
		
	}
	//selectionSort(rnd, a.size);
	
}

void PrintRandom(double *mas, int n)
{
	printf("\n\n");
	printf("%c%c%c%c%c%c%c%c%c%c\n", 213, 196, 196, 196, 196, 196, 196, 196, 196, 184);
	for (int i = 0; i < n; i++)
	{
		printf("%c%8.4f%c\n", 179, mas[i], 179);
		if (i < n - 1)
		{
			printf("%c%c%c%c%c%c%c%c%c%c\n", 195, 196, 196, 196, 196, 196, 196, 196, 196, 180);
		}
	}
	printf("%c%c%c%c%c%c%c%c%c%c\n", 212, 196, 196, 196, 196, 196, 196, 196, 196, 190);
}

int main()
{
	Values obj = { 0 };
	int count_int = 0, size = 0;
	double a=0, b=0;
	ReadPar(&a,&b,&size,obj);
	obj.fx = new double[size];
	double *rnd = new double[size];
	int *intf = new int[count_int];
	
	printf("\t\t\t FUNCTION:\n");
	Tab(obj, &count_int, a,b, size);
	getS( obj, rnd, size);
	Norm(obj.fx, intf, size);
	Print(intf, size);
	
	printf("\t\t\t RANDOM ARRAY:\n");
	PrintRandom(rnd, size);
	Norm(rnd, intf, size);
	Print(intf, size);
	
	printf("\n\n\nValue of array: %p\n", rnd);
	printf("Pointer of array: %p", &rnd);
	_getch();
	return 0;
}