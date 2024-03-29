#include "stdafx.h"
#include<iostream>
#include<conio.h>
#include<math.h>
#include<iomanip>

using namespace std;

double f_tocn(double x)
{
	return 2 * exp(x) / (1 + exp(x)*(cos(x) + sin(x)));
}

double func(double x, double y)
{
	return y - y * y*cos(x);
}

double func(int neq, double x, double *y, double *y_p)
{
	for (int i = 0; i < neq; i++)
	{
		y_p[i] = y[i] - y[i] * y[i] * (cos(x));;
	}
	return *y_p;
}

double RK4(double h)
{
	double a = 0.0, b = 2.1;

	double *y = new double[((b - a) / h) + 1];
	double *k1 = new double[((b - a) / h) + 1];
	double *k2 = new double[((b - a) / h) + 1];
	double *k3 = new double[((b - a) / h) + 1];
	double *k4 = new double[((b - a) / h) + 1];
	double *y_tocn = new double[((b - a) / h) + 1];


	int i = 0;
	y[i] = 1.0;

	cout << "\t\t\t\t\t***** RUNGE-KUTTA 4 *****" << endl;
	cout << endl;
	cout << "\t";
	for (int i = 1; i <89; i++)
	{
	cout << "-";
	}
	cout << endl;
	cout << "\t| " << setw(5) << "x" << setw(15) << "y(x)" << setw(15) << "y" << setw(25) << "y(x)-y" << setw(26) << "100e/y|" << endl;
	cout << "\t";
	for (int i = 1; i <89; i++)
	{
	cout << "-";
	}
	cout << endl;

	for (double xp = a; xp <= b+h; xp += h, i++)
	{
		k1[i] = h * func(xp, y[i]);
		k2[i] = h * func(xp + h / 2, y[i] + k1[i] / 2);
		k3[i] = h * func(xp + h / 2, y[i] + k2[i] / 2);
		k4[i] = h * func(xp + h, y[i] + k3[i]);

		y_tocn[i] = f_tocn(xp);
		y[i + 1] = y[i] + (1 / 6.)*(k1[i] + 2 * k2[i] + 2 * k3[i] + k4[i]);

		cout << "\t| " << setw(5) << xp << setw(15) << y_tocn[i] << setw(15) << y[i] << setw(25) << fabs(y_tocn[i] - y[i]) << setw(25) << fabs((100 * (y_tocn[i] - y[i])) / y[i]) << "|" << endl;
	}

	cout << "\t";
	for (int i = 1; i <89; i++)
	{
	cout << "-";
	}
	cout << endl;
	return *y;
}

double rk(double a, double h, double yk)
{
	double k0;
	double k1;
	double k2;
	double k3;

	k0 = h * func(a, yk);
	k1 = h * func(a + h / 2, yk + k0 / 2);
	k2 = h * func(a + h / 2, yk + k1 / 2);
	k3 = h * func(a + h, yk + k2);

	yk = yk + 1 / 6. * (k0 + 2 * k1 + 2 * k2 + k3);
	return yk;
}

double RK4(int neq, double *y_p, double *y, double h, double xk, double xkPlus1)
{
	double nt = ((xkPlus1 - xk) / h);

	double *k1 = new double[nt];
	double *k2 = new double[nt];
	double *k3 = new double[nt];
	double *k_rez = new double[nt];
	double x, z;

	h = ((xkPlus1 - xk) / nt);

	for (int it = 0; it < nt; it++)
	{
		x = xk + (it - 1)*h;


		for (int i = 0; i < neq; i++)
		{
			k_rez[i] = y[i];
		}

		*y_p = func(neq, x, y, y_p);
		for (int i = 0; i < neq; i++)
		{
			k1[i] = y_p[i] * h;
			y[i] = k_rez[i] + k1[i] / 2;
		}
		z = x + h / 2;

		*y_p = func(neq, z, y, y_p);
		for (int i = 0; i < neq; i++)
		{
			k2[i] = y_p[i] * h;
			y[i] = k_rez[i] + k2[i] / 2;
		}
		z = x + h / 2;

		*y_p = func(neq, z, y, y_p);

		for (int i = 0; i < neq; i++)
		{
			k3[i] = y_p[i] * h;
			y[i] = k_rez[i] + k3[i];
		}
		z = x + h;

		*y_p = func(neq, z, y, y_p);
	}

	for (int i = 0; i < neq; i++)
	{
		y[i] = k_rez[i] + (1 / 6)*(k1[i] + 2 * k2[i] + 2 * k3[i] + y_p[i] * h);
	}

	return *y;
}

void AdamsaMoultona4(double a, double b, double h)
{
	
	cout << "\t\t\t\t\t***** ADAMSA-MOULTONA 4 *****" << endl;
	cout << endl;
	cout << "\t";
	for (int i = 1; i <89; i++)
	{
		cout << "-";
	}
	cout << endl;
	cout << "\t| " << setw(5) << "x" << setw(15) << "y(x)" << setw(15) << "y" << setw(25) << "y(x)-y" << setw(26) << "100e/y|" << endl;
	cout << "\t";
	for (int i = 1; i <89; i++)
	{
		cout << "-";
	}
	cout << endl;
	
	double yk = 1.0;
	double y;

	while (a < b + h)
	{
		yk = yk + h / 24 * (9*func(a + h, rk(a, h, yk)) +19* func(a, yk) - 5*func(a-h,rk(a,h,yk)) + func(a-2*h,rk(a,h,yk)));
		y = f_tocn(a);

		cout << "\t| " << setw(5) << a << setw(15) << y << setw(15) << yk << setw(25) << fabs(y - yk) << setw(25) << fabs((100 * (y - yk)) / yk) << "|" << endl;

		a += h;
	}

	cout << "\t";
	for (int i = 1; i <89; i++)
	{
		cout << "-";
	}
}

int main()
{
	double h1 = 0.5, h2 = h1 / 5, h3 = h1 / 25;
	double a = 0.0, b = 2.1;
	double h = 0.01;
	
	RK4(h);
	cout << "\n\n\n\n";
	AdamsaMoultona4(a, b, h);
	
	_getch();
	return 0;
}