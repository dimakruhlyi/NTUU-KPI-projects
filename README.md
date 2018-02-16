// КР про кулю та точки перетину.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
// Z = -0.27 * (y - 0.52)^2 + 1.24 * y * x^2
// (x + 2.00)^2 + (y - 1.32)^2 + (z - 6.40)^2= (3.57)^2
// -0.77 * x + 0.64 * y - 0.03 * z - 2.19 = 0

#include <iostream>
#include <ctime>
using namespace std;

int main()
{
	double R = 3.57 * 3.57;
	R = round(R * 10000.0) / 10000.0;
	cout << "R = " << R << endl;
	double c;
	time_t start1 = clock();
	for (double x = -5.58; x <= 3; x += 0.0001)
	{
		for (double y = -2.26; y <= 5; y += 0.0001)
		{
			double z = -0.27 * pow((y - 0.52), 2) + 1.24 * y * x * x;
			if (z <= 12 && z >= -1)
			{
				double z2 = pow((x + 2.0), 2) + pow((y - 1.32), 2) + pow((z - 6.40), 2);
				z2 = round(z2 * 10000.0) / 10000.0;

				if ((z2 < R + 0.001 && z2 > R - 0.001) || z2 == R)
				{
					c = -0.77 * x + 0.64 * y - 0.03 * z - 2.19;
					if (c < 0.001 && c > -0.001)
					{
						//cout << z1 << "    " << z2 << "    " << z3 << endl;
						printf("x = %6.4lf\ny = %6.4lf\nz = %6.4lf\n", x, y, z);
						cout << c << "-----------------\n" << endl;
						cout << "!!!You have 100 points!!!\n";
					}
				}
			}
		}
	}
	double duration1 = (clock() - start1) / (double)CLOCKS_PER_SEC;
	cout << duration1 << endl;
	cout << "\t\t\tTHE END" << endl;
	system("pause");
	return 0;
}
/*z1 = round(z1 * 10000.0) / 10000.0;
//z2 = sqrt(fabs(3.57 * 3.57 - pow((x + 2.00), 2) - pow((y - 1.32), 2))) + 6.40;
////z2 = round(z2 * 10000.0) / 10000.0;
//z3 = (-0.77 * x + 0.64 * y - 2.19) / 0.03;
////z3 = round(z3 * 10000.0) / 10000.0;




*/
