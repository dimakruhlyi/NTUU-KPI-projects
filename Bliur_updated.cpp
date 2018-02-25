#define _CRT_SECURE_NO_WARNINGS
#include<stdio.h>
#include<stdlib.h>
#include<time.h>
#include<ctime>

void f1(int rad, int N, double **arr, int sum,int n,int i,int e, int **mas, int t)
{

	for (int y = 1; y <= rad; y++)
	{
		for (int p = e; p <= t; p++)
		{
			sum += mas[p][y + rad];
			n++;
		}
		arr[i][y] = (double)sum / n;
	}
	for (int u = rad + 1; u < N - rad; u++)
	{
		for (int s = e; s <= t; s++)
		{
			sum += mas[s][u + rad];
			sum -= mas[s][u - rad - 1];
		}
		arr[i][u] = (double)sum / n;
	}
	for (int o = N - rad; o < N; o++)
	{
		for (int d = e; d <= t; d++)
		{
			sum -= mas[d][o - rad - 1];
			n--;
		}
		arr[i][o] = (double)sum / n;
	}
}
void f2(int rad, int N, double **arr, int sum, int n, int i, int e, int **mas, int t)
{
	for (int y = 1; y <N - rad; y++)
	{
		for (int p = e; p <= t; p++)
		{
			sum += mas[p][y + rad];
			n++;
		}
		arr[i][y] = (double)sum / n;
	}
	for (int u = N - rad; u <= rad; u++)
	{
		arr[i][u] = (double)sum / n;
	}
	for (int o = rad + 1; o< N; o++)
	{
		for (int d = e; d <= t; d++)
		{
			sum -= mas[d][o - rad - 1];
			n--;
		}
		arr[i][o] = (double)sum / n;
	}
}

int main()
{
	int N, rad;
	printf("Enter quantity of elements matrix: ");
	scanf("%d", &N);
	printf("\nEnter radius of blur: ");
	scanf("%d", &rad);
	if (rad > N)
		rad = N;
		
	double **arr = new double *[N];
	for (int i = 0; i < N; i++)
		arr[i] = new double[N];
	int a2 = clock();
	int sum = 0, n = 0,e,t;
	unsigned long int counter = 0;
	double ser;
	int **mas = new int *[N];
	for (int i = 0; i < N; i++)
		mas[i] = new int[N];
	srand(time(NULL));
	for (int i = 0; i < N; i++)
		for (int j = 0; j < N; j++)
			*(*(mas+i)+j) = rand() % 10 + 1;
	/*printf("Started array:\n");
	for (int i = 0; i < N; i++)
	{
	for (int j = 0; j < N; j++)
			printf("%3d", mas[i][j]);
	printf("\n");
	}*/

	for (int i = 0; i < N; i++)
	{
		int q,w;
		sum = 0;
		n = 0;
		if (i-rad<0)
			e = 0;
		else e = i - rad;
		if (i + rad > N - 1)
			t = N - 1;
		else t = i + rad;

		for ( q = e; q <=t; q++)
		{
			for (w = 0; w <= rad; w++)
			{
				sum += mas[q][w];
				n++;
			}
		}
		arr[i][0] = (double)sum / n;

		if (rad > N / 2 && rad < N)
			f2(rad, N, arr, sum, n, i, e, mas, t);
		else
			f1(rad, N, arr, sum, n, i, e, mas, t);
	}
	/*printf("\nPerformed array: \n\n");
	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++)
			printf(" %3.2f\t", arr[i][j]);
		printf("\n");
	}*/
	int a = clock();
	double time2 = (double)(a-a2) / CLOCKS_PER_SEC;
	printf("\n\nTime of working program is:   %f\n", time2);
	//printf("Quantity of iteratsiy are:  %d\n", counter);
	system("pause");
	return 0;
}