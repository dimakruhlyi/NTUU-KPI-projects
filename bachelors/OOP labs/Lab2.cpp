#define _CRT_SECURE_NO_WARNINGS
#include<stdio.h>
#include<stdlib.h>
#include<conio.h>
#include<iostream>

using namespace std;

class Money_Premium
{
	char *surname;
	char *name;
	char *position;
	int day;
	int month;
	int year;
	double sum_money_premium;

public:
	 
	Money_Premium();
  Money_Premium(char *surnm, char *nm, char *pos, int d, int m, int y, double sum);
	Money_Premium( Money_Premium & p);
  ~Money_Premium();
	
	 void Check_Date();
	 void Check_Sum_Money_Premium();
	 void Check_text(char*);
	 void Output_Data();
	 void output();
};

Money_Premium :: Money_Premium()
{
	surname = new char[9];
	strcpy(surname, "Kruhlyi ");
	
	name = new char [5];
	strcpy(name, "Dima");
  cout << surname << name << endl;
	position = new char [8];
	strcpy(position, "Student");
	cout << position << endl;
	day = 4; month = 11; year = 1999;
	cout << day << "." << month << "." << year << endl;
	sum_money_premium = 1000.5;
	cout << sum_money_premium << endl;
}

Money_Premium :: Money_Premium( Money_Premium &p)
{
	//cout << "\t\t\t *** COPY constructor ***" << endl;
	*this = p;
	surname = new char[strlen(p.surname) + 1];
	strcpy(surname, p.surname);
	name = new char[strlen(p.name) + 1];
	strcpy(name, p.name);
	position = new char[strlen(p.position) + 1];
	strcpy(position, p.position);
	day = p.day;
	month = p.month;
	year = p.year;
	sum_money_premium = p.sum_money_premium;
}

Money_Premium :: Money_Premium(char *surnm, char *nm, char *pos, int d, int m, int y,double sum)
{
	surname = new char[strlen(surnm)+1];
	strcpy(surname, surnm);
	name = new char[strlen(nm) + 1];
	strcpy(name, nm);
	position = new char[strlen(pos) + 1];
	strcpy(position, pos);
	day = d;
	month = m;
	year = y;
	sum_money_premium = sum;

}

Money_Premium :: ~Money_Premium()
{
	//cout << "\t---- DESTRUCTOR ----\n";
	delete surname;
	delete name;
	delete position;
}

void Money_Premium :: Check_text(char *any_text)
{
	int count_mass_element = 0, defis = 0, ind = 0;
	while (true)
	{
		ind = 1;
		count_mass_element = 0;
		defis = 0;
		int clear_bufer = 1;

		while (count_mass_element < 100)
		{
			char symbol = getchar();
			any_text[count_mass_element] = symbol;

			if (symbol == 45 && defis == 0)
			{
				defis = 1;
				symbol = cin.get();
				if (symbol == '\n') clear_bufer = 0;
				if ((symbol > 96 && symbol < 123) || (symbol > 64 && symbol < 91));
				else
				{
					ind = 0;
					break;
				}

				count_mass_element++;
				any_text[count_mass_element] = symbol;
				symbol = 98;
			}

			if (symbol == '\n') break;


			if ((symbol > 96 && symbol < 123) || (symbol > 64 && symbol < 91));
			else
			{
				ind = 0;
				break;
			}

			count_mass_element++;
		}
		any_text[count_mass_element] = '\0';
		if (ind) break;
				else
				{
					cout << "    --- Error ---\n    Input again!\n";
					cin.clear();
					if (clear_bufer) while (cin.get() != '\n');
				}
	}

	if (any_text[0] < 65 || any_text[0] > 90)
	{
		any_text[0] -= 32;
	}

	int ind3 = 0;
	for (int i = 1; i < strlen(any_text); i++)
	{
		if (any_text[i] == 45)
		{
			ind3 = 1;
		}

		if ((any_text[i] < 95 || any_text[i] > 122) && !ind3)
		{
			any_text[i] += 32;
		}

		if (ind3)
		{
			++i;
			if (any_text[i] < 65 || any_text[i] > 90)
			{
				any_text[i] -= 32;
			}
			ind3 = 0;
		}
	}
}

void Money_Premium::Check_Date()
{
	char inputed_date[20];
	cout << "You must to enter through a dot!" << endl;
	int ind = 0, count_mas_element = 0, day1, year1, month1;

	while (true)
	{

		count_mas_element = 0;
		ind = 1;
		int ind2 = 1, count_of_point = 0;

		while (count_mas_element < 30)
		{
			inputed_date[count_mas_element] = getchar();
			if (inputed_date[count_mas_element] == '\n') break;
			if (inputed_date[count_mas_element] == '.') count_of_point++;

			if (inputed_date[count_mas_element] > 57 || inputed_date[count_mas_element] < 45)
			{
				ind = 0;
				break;
			}
			count_mas_element++;
		}

		if (ind) ind2 = 0;
		inputed_date[count_mas_element] = '\0';

		if (count_of_point != 2)
		{
			ind = 0;
		}

		if (count_mas_element > 12)
		{
			ind2 = 1;
			ind = 0;
		}

		if (ind)
		{
			char *temp_day = new char[10];
			char *temp_month = new char[10];
			char *temp_year = new char[10];

			int count2 = 0;
			for (count_mas_element = 0; count_mas_element < 3; count_mas_element++)
			{
				if (inputed_date[count_mas_element] == '.') break;
				temp_day[count2] = inputed_date[count_mas_element];
				count2++;
			}

			count2 = 0;
			for (count_mas_element++; count_mas_element < 6; count_mas_element++)
			{
				if (inputed_date[count_mas_element] == '.') break;
				temp_month[count2] = inputed_date[count_mas_element];
				count2++;
			}

			count2 = 0;
			for (count_mas_element++;; count_mas_element++)
			{
				if (inputed_date[count_mas_element] == '\0') break;
				temp_year[count2] = inputed_date[count_mas_element];
				count2++;
			}



			day1 = atoi(temp_day);
			month1 = atoi(temp_month);
			year1 = atoi(temp_year);

			int mas[12] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

			if (year1 % 4 == 0) mas[1] += 1;
			if (month1 < 1 || month1 > 12) ind = 0;
			if (day1 < 1 || day1 > mas[month1 - 1]) ind = 0;
			if (year1 < 1950 || year1 > 2017) ind = 0;
			if (ind) ind2 = 1;
		}


		if (ind) break;
		else
		{
			cout << "\t--- Error ---\n\tInput again!\n";
			cin.clear();
			if (ind2) while (cin.get() != '\n');
		}
	}
	day = day1;
	month = month1;
	year = year1;

}

void Money_Premium::Check_Sum_Money_Premium()
{
	
	char *premium = new char[20];
	int ind = 0, ind2=0, i = 0;

	while (true)
	{
		i = 0;
		ind = 1;
		int indik_right = 1, count_point = 0;

		while (i < 11)
		{
			premium[i] = getchar();
			if (premium[i] == '\n') break;
			if (premium[i] == '.') count_point++;
			if (premium[i] > 57 || premium[i] < 46)
			{
				ind = 0;
				break;
			}
			i++;
		}
		premium[i] = '\0';

		if (ind) indik_right = 0;
		if (count_point > 1 && ind2 == 0) ind = 0;
		if (count_point > 0 && ind2 == 1) ind = 0;

		int j = 0;
		if (ind)
		{
			if (i > 10)
			{
				indik_right = 1;
				ind = 0;
			}
			int step = 1;
			char *drob = new char[10];
			int t = 0;


			for (int i = 0; i < 20; i++)
			{
				if (premium[i] == '\0') break;
				if (t)
				{
					drob[j] = premium[i];
					j++;
					step *= 10;
				}
				if (premium[i] == '.') t = 1;
			}

			double sum = atoi(premium);
			double sum1 = atoi(drob);

			if (sum > 5000 && ind2 == 1) ind = 0;

			if (sum < 0) ind = 0;
			if (ind) indik_right = 1;
			if (ind2 == 0) sum_money_premium = sum + sum1 / step;
		}


		if (ind) break;
		else
		{
			cout<< "\t--- Error ---\n\t    Input again!\n";
			cin.clear();
			if (indik_right) while (cin.get() != '\n');
		}
	}
}

void Money_Premium::output()
{
	cout << "\n\n";
	cout << surname << " " << name << " " << position << endl;
	cout << "Date: " << day << "." << month << "." << year << endl;
	cout << "Premium: " << sum_money_premium;
}

void Money_Premium::Output_Data()
{
	char *surnm = new char[50];
	cout << "\n\t\t\t***** Enter surname *****\n";
	Check_text(surnm);
	surname = new char[strlen(surnm) + 1];
	strcpy(surname, surnm);
	char *nm = new char[50];
	cout << "\n\t\t\t***** Enter name *****\n";
	Check_text(nm);
	name = new char[strlen(nm) + 1];
	strcpy(name, nm);

	cout << "\n\t\t\t***** Enter the destination date *****\n ";
	Check_Date();

	char *pos = new char[50];
	cout << "\n\t\t\t***** Enter position *****\n";
	Check_text(pos);
	position = new char[strlen(pos) + 1];
	strcpy(position, pos);
	cout << "\n\t\t\t***** Enter sum money premium *****\n ";
	Check_Sum_Money_Premium();

	cout << "\n\n\t\t Inputed information" << endl;
	cout << "\tSurname: " << surname << endl;
	cout << "\tName: " << name << endl;
	cout << "\tPosition: " << position << endl;
	cout << "\tDestination date: " << day << "." << month << "." << year << endl;
	cout << "\tSum money premium: " << sum_money_premium << endl;
}

Money_Premium global_object("I", "love", "TEF", 3,3,1933,342.6);

int main()
{
	Money_Premium money_premium, money_premium3 (money_premium);
	global_object.output();
	money_premium3.Output_Data();
	
	_getch();
	return 0;
}