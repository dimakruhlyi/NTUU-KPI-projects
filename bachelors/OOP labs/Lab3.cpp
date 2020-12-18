#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <stdio.h>
#include <stdlib.h>

using namespace std;

class assignment
{
	char *Name;
	char *LastName;
	char *Position;
	int Day;
	int Mounth;
	int Year;
	char *Town;
	int NumberDays;
	double Pay;

public:
	assignment(int i);
	assignment(char *name = "Endry", char *lastname = "Dmutruk", char *posit = "Stydent", char *sity = "Kyiv",
		int day = 15, int mounth = 6, int year = 1999, int numbersDays = 15, double pay = 1100.5);
	assignment(assignment &);
	~assignment();

	void CheckingText(char *);
	void CheckingDate();
	void CheckingPay(int);

	assignment operator+ (const assignment &);
	assignment &operator= (const assignment &);
	operator int();
	bool operator> (const assignment &);

	void Get();
	void Set();
};

assignment :: operator int()
{
	return int(Pay);
}

bool assignment :: operator> (const assignment & A)
{
	return Pay > A.Pay;
}

assignment assignment :: operator+ (const assignment & A)
{
	assignment Result(*this);
	Result.Pay = Pay + A.Pay;
	Result.NumberDays = NumberDays + A.NumberDays;
	//cout « endl « "Suma: " « NumberDays « " + " « A.NumberDays « endl;
	return Result;
}

assignment  &assignment :: operator= (const assignment & A)
{
	if (this == &A) return *this;

	Name = new char[strlen(A.Name) + 1];
	strcpy(Name, A.Name);
	LastName = new char[strlen(A.LastName) + 1];
	strcpy(LastName, A.LastName);
	Position = new char[strlen(A.Position) + 1];
	strcpy(Position, A.Position);
	Town = new char[strlen(A.Town) + 1];
	strcpy(Town, A.Town);

	Day = A.Day;
	Pay = A.Pay;
	NumberDays = A.NumberDays;
	return *this;
}

void assignment::Set()
{
	char *Mas = new char[100];

	printf("Write Name:\n");
	CheckingText(Mas);
	Name = new char[strlen(Mas) + 1];
	strcpy(Name, Mas);

	printf("\nWrite LastName:\n");
	CheckingText(Mas);
	LastName = new char[strlen(Mas) + 1];
	strcpy(LastName, Mas);

	printf("\nWrite Position:\n");
	CheckingText(Mas);
	Position = new char[strlen(Mas) + 1];
	strcpy(Position, Mas);

	printf("\nShablon: DD.MM.YYYY\n");
	printf("Write Date:\n");
	CheckingDate();

	printf("\nWrite Town:\n");
	CheckingText(Mas);
	Town = new char[strlen(Mas) + 1];
	strcpy(Town, Mas);

	printf("\n0 < 5000\n");
	printf("Write NumberDays:\n");
	CheckingPay(1);
	printf("\nWrite Pay:\n");
	CheckingPay(0);

	delete[] Mas;
}

void assignment::Get()
{
	printf("Name: %s\n", Name);
	printf("LastName: %s\n", LastName);
	printf("Position: %s\n", Position);
	printf("Date: %d.%d.%d\n", Day, Mounth, Year);
	printf("Town: %s\n", Town);
	printf("NumberDays: %d\n", NumberDays);
	printf("Pay: %f\n\n\n", Pay);
}


void assignment::CheckingDate()
{
	char *god = new char[20];
	int i = 0;
	int w = 0;
	int ind = 0;

	int a, b, c;

	while (true)
	{

		i = 0;
		ind = 1;
		int u = 1;
		int v = 0;

		while (i < 30)
		{
			god[i] = getchar();
			if (god[i] == '\n') break;
			if (god[i] == '.') v++;

			if (god[i] > 57 || god[i] < 45)
			{
				ind = 0;
				break;
			}
			i++;
		}

		if (ind) u = 0;
		god[i] = '\0';

		if (v != 2)
		{
			ind = 0;
		}

		if (i > 12)
		{
			u = 1;
			ind = 0;
		}

		if (ind)
		{
			char *day = new char[10];
			char *month = new char[10];
			char *year = new char[10];

			int j = 0;
			for (i = 0; i < 3; i++)
			{
				if (god[i] == '.') break;
				day[j] = god[i];
				j++;
			}

			j = 0;
			for (i++; i < 6; i++)
			{
				if (god[i] == '.') break;
				month[j] = god[i];
				j++;
			}

			j = 0;
			for (i++;; i++)
			{
				if (god[i] == '\0') break;
				year[j] = god[i];
				j++;
			}



			a = atoi(day);
			b = atoi(month);
			c = atoi(year);

			int mas[12] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

			if (c % 4 == 0) mas[1] += 1;
			if (b < 1 || b > 12) ind = 0;
			if (a < 1 || a > mas[b - 1]) ind = 0;
			if (c < 1950 || c > 2017) ind = 0;
			if (ind) u = 1;
		}
		if (ind) break;
		else
		{
			printf("Error\n\n");
			cin.clear();
			if (u) while (cin.get() != '\n');
		}
	}
	Day = a;
	Mounth = b;
	Year = c;

}

void assignment::CheckingText(char *name)
{
	int i = 0;
	int w = 0;
	int ind = 0;
	while (true)
	{
		ind = 1;
		i = 0;
		w = 0;
		int u = 1;

		while (i < 100)
		{
			char q = getchar();
			name[i] = q;

			if (q == 45 && w == 0)
			{
				w = 1;
				q = cin.get();
				if (q == '\n') u = 0;
				if ((q > 96 && q < 123) || (q > 64 && q < 91));
				else
				{
					ind = 0;
					break;
				}

				i++;
				name[i] = q;
				q = 98;
			}

			if (q == '\n') break;


			if ((q > 96 && q < 123) || (q > 64 && q < 91));
			else
			{
				ind = 0;
				break;
			}

			i++;
		}
		name[i] = '\0';

		if (i > 99)
		{
			u = 1;
			ind = 0;
		}

		if (ind) break;
		else
		{
			printf("Error\n\n");
			cin.clear();
			if (u) while (cin.get() != '\n');
			//scanf("%*[^\n]");
		}
	}

	if (name[0] < 65 || name[0] > 90)
	{
		name[0] -= 32;
	}

	int ind3 = 0;
	for (int i = 1; i < strlen(name); i++)
	{
		if (name[i] == 45)
		{
			ind3 = 1;
		}

		if ((name[i] < 95 || name[i] > 122) && !ind3)
		{
			name[i] += 32;
		}

		if (ind3)
		{
			++i;
			if (name[i] < 65 || name[i] > 90)
			{
				name[i] -= 32;
			}
			ind3 = 0;
		}
	}
}

void assignment::CheckingPay(int b)
{
	char *pay1 = new char[100];
	int i = 0;
	int w = 0;
	int ind = 0;

	while (true)
	{
		i = 0;
		ind = 1;
		int u = 1;
		int v = 0;

		while (i < 11)
		{
			pay1[i] = getchar();
			if (pay1[i] == '\n') break;
			if (pay1[i] == '.') v++;
			if (pay1[i] > 57 || pay1[i] < 46)
			{
				ind = 0;
				break;
			}
			i++;
		}
		pay1[i] = '\0';

		if (ind) u = 0;
		if (v > 1 && b == 0) ind = 0;
		if (v > 0 && b == 1) ind = 0;

		int j = 0;
		if (ind)
		{
			if (i > 10)
			{
				u = 1;
				ind = 0;
			}
			int step = 1;
			char *drob = new char[10];
			int t = 0;


			for (int i = 0; i < 100; i++)
			{
				if (pay1[i] == '\0') break;
				if (t)
				{
					drob[j] = pay1[i];
					j++;
					step *= 10;
				}
				if (pay1[i] == '.') t = 1;
			}

			double sum = atoi(pay1);
			double sum1 = atoi(drob);

			if (sum > 5000 && b == 1) ind = 0;

			if (sum < 0) ind = 0;
			if (ind) u = 1;
			if (b == 0) Pay = sum + sum1 / step;
			if (b == 1) NumberDays = sum;
		}


		if (ind) break;
		else
		{
			printf("Error\n\n");
			cin.clear();
			if (u) while (cin.get() != '\n');
		}
	}
}


assignment::assignment(int i)
{
	Set();
}

assignment::assignment(char *nam, char *lastnam, char *posit, char *sity,
	int day, int mounth, int year, int numbersDay, double pay)
{
	Name = new char[strlen(nam) + 1];
	strcpy(Name, nam);
	LastName = new char[strlen(lastnam) + 1];
	strcpy(LastName, lastnam);
	Position = new char[strlen(posit) + 1];
	strcpy(Position, posit);
	Town = new char[strlen(sity) + 1];
	strcpy(Town, sity);
	Day = day;
	Mounth = mounth;
	Year = year;
	NumberDays = numbersDay;
	Pay = pay;
}

assignment::~assignment()
{
	delete[] Name;
	delete[] LastName;
	delete[] Position;
	delete[] Town;
}

assignment::assignment(assignment &A)
{
	*this = A;
	Name = new char[strlen(A.Name) + 1];
	strcpy(Name, A.Name);
	LastName = new char[strlen(A.LastName) + 1];
	strcpy(LastName, A.LastName);
	Position = new char[strlen(A.Position) + 1];
	strcpy(Position, A.Position);
	Town = new char[strlen(A.Town) + 1];
	strcpy(Town, A.Town);
	Day = A.Day;
	Mounth = A.Mounth;
	Year = A.Year;
	NumberDays = A.NumberDays;
	Pay = A.Pay;
}


int main()
{
	assignment A(0);
	assignment B;
	//cout « "Suma: " « endl « 
	assignment C;
	system("cls");
	C = A + B;
	A.Get();
	B.Get();

	C.Get();
	if (A > B) cout << endl << "Operator >  —- "  << "A > B" << endl;
	else cout << endl << "Operator >  —- " << "B > A" << endl;

	cout << endl << "Operator (int) C  —- " <<(int)C << endl;


	system("pause");
	return 0;
}