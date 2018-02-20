#include<iostream>
#include<conio.h>
#include<string>

using namespace std;

class Date
{
protected:
	int year;
	int week;
public:
	Date()
	{
		cout << "Enter year: ";
		cin >> year;
		cout << "Enter week: ";
		cin >> week;
	}

	void Show();
};

void Date::Show()
{
	cout << endl;
	cout << "Year: " << year << endl;
	cout << "Week: " << week << endl;
}

class Flower
{
protected:
	string name;
	string color;
public:
	Flower()
	{
		cout << "Enter name of flower: ";
		cin >> name;
		cout << "Enter color of flower: ";
		cin >> color;
	}
	
	void Show();
};

void Flower::Show()
{
	cout << endl;
	cout << "Flowers's name is: " << name << endl;
	cout << "Flower's color is: " << color << endl;
}

enum Type_Flower_Commodity
{
	Pot=1, Bouquet, Piece
};

class Flower_Commodity : public Flower
{
protected:
	Type_Flower_Commodity type;
	double cost;
	int choose;
public:
	Flower_Commodity()
	{
		cout << "Enter type flower for sell:\n\tIf you want to buy:\n\t\ta post - press 1\n\t\ta bouquet - press 2\n\t\ta piece - press 3\n Your choose: ";
		while (true)
		{
			cin >> choose;
			if (choose > 0 && choose < 4)
				break;
			else
				cout << "Error! Try again." << endl;
		}
		
		cout << "Enter cost of flower: ";
		cin >> cost;
	}

	void Show()
	{
		cout << "Flower_Commodity: flower's name: " << name << endl;;
		cout << "Flower_Commodity: flower's color: " << color<<endl;
		switch (choose)
		{
		case Pot: cout << "Flower_Commodity: flower's type is pot." << endl; break;
		case Bouquet: cout << "Flower_Commodity: flower's type is bouquet." << endl; break;
		case Piece: cout << "Flower_Commodity: flower's type is piece." << endl; break;
		}
		cout << "Cost of flower: " << cost << endl;
	}
};

class Consignment : public Flower_Commodity
{
protected:
	int count;
	double cost_consignment;
public:
	Consignment()
	{
		cout << "Enter quantity of flowers: ";
		cin >> count;
		cout << "Enter cost of consignment: ";
		cin >> cost_consignment;
	}

	void Show()
	{
		cout << "Consignment: flowers's name is: " << name << endl;
		cout << "Consignment: flowers's color is: " << color << endl;
		switch (choose)
		{
		case Pot: cout << "Consignment: flower's type is pot." << endl; break;
		case Bouquet: cout << "Consignment: flower's type is bouquet." << endl; break;
		case Piece: cout << "Consignment: flower's type is piece." << endl; break;
		}
	  cout<<"Consignment: cost of flower: " << cost << endl; 
		cout << "Consignment: flower's count: " << count << endl;
		cout << "Consignment: cost consignment: " << cost_consignment << endl;
	}
};

class Supply_of_goods :virtual public Date, virtual public Consignment
{
public:
	Supply_of_goods()
	{
	}

	void Show()
	{
		cout << "\t\t*** Supply of goods ***" << endl;
		cout << "Year: " << year << endl;
		cout << "Week: " << week << endl;

		cout << "flowers's name is: " << name << endl;
		cout << "flowers's color is: " << color << endl;
		switch (choose)
		{
		case Pot: cout << "flower's type is pot." << endl; break;
		case Bouquet: cout << "flower's type is bouquet." << endl; break;
		case Piece: cout << "flower's type is piece." << endl; break;
		}
		cout << "cost of flower: " << cost << endl;
		cout << "flower's count: " << count << endl;
		cout << "cost consignment: " << cost_consignment << endl;
	}
};

class List_supply : public Flower
{
protected:
	string list_goods[7];
	int quantity;
public:
	List_supply()
	{
		cout << "Enter quantity of commodity for SUPPLY for a week: ";
		cin >> quantity;
		for (int i = 0; i < quantity; i++)
		{
			cout << "Enter day " << i + 1 << " supply: ";
			cin >> list_goods[i]; cout << endl;
		}
	}
	void Show()
	{
		cout << "\n\t\t SUPPLY of consingnment: " << endl;
		cout << "Flowers's name is: " << name << endl;
		cout << "Flower's color is: " << color << endl;

		for (int i = 0; i < quantity; i++)
		{
			cout << "Day " << i + 1 << " supply: ";
		 cout<< list_goods[i]; cout << endl;
		}
	}
};

class Sell_of_goods :virtual public Date, virtual public Consignment
{
public:
	Sell_of_goods()
	{
	}

	void Show()
	{
		cout << "\t\t*** Sell of goods ***" << endl;
		cout << "Year: " << year << endl;
		cout << "Week: " << week << endl;

		cout << "flowers's name is: " << name << endl;
		cout << "flowers's color is: " << color << endl;
		switch (choose)
		{
		case Pot: cout << "flower's type is pot." << endl; break;
		case Bouquet: cout << "flower's type is bouquet." << endl; break;
		case Piece: cout << "flower's type is piece." << endl; break;
		}
		cout << "cost of flower: " << cost << endl;
		cout << "flower's count: " << count << endl;
		cout << "cost consignment: " << cost_consignment << endl;
	}
};

class List_sell : public Sell_of_goods
{
protected:
	string list_sell[7];
	int quantity_sell;
public:
	List_sell()
	{
		cout << "Enter quantity of commodity for SELL for a week: ";
		cin >> quantity_sell;
		for (int i = 0; i < quantity_sell; i++)
		{
			cout << "Enter day " << i + 1 << " sell: ";
			cin >> list_sell[i]; cout << endl;
		}
	}
	void Show()
	{
		cout << "\t\t SELL of consingnment: " << endl;
		cout << "Year: " << year << endl;
		cout << "Week: " << week << endl;
		cout << "Flowers's name is: " << name << endl;
		cout << "Flower's color is: " << color << endl;
		cout << "Cost of flower: " << cost << endl;

		switch (choose)
		{
		case Pot: cout << "flower's type is pot." << endl; break;
		case Bouquet: cout << "flower's type is bouquet." << endl; break;
		case Piece: cout << "flower's type is piece." << endl; break;
		}

		cout << "flower's count: " << count << endl;
		cout << "cost consignment: " << cost_consignment << endl;

		for (int i = 0; i < quantity_sell; i++)
		{
			cout << "Day " << i + 1 << " sell: ";
			cout << list_sell[i]; cout << endl;
		}
	}
};

class Weekly_balance : virtual public List_sell
{
public:
	Weekly_balance()
	{
	}
	void Show()
	{
		cout << "\t\t SELL of consingnment: " << endl;
		cout << "Year: " << year << endl;
		cout << "Week: " << week << endl;
		cout << "Flowers's name is: " << name << endl;
		cout << "Flower's color is: " << color << endl;
		cout << "Cost of flower: " << cost << endl;

		switch (choose)
		{
		case Pot: cout << "flower's type is pot." << endl; break;
		case Bouquet: cout << "flower's type is bouquet." << endl; break;
		case Piece: cout << "flower's type is piece." << endl; break;
		}

		cout << "flower's count: " << count << endl;
		cout << "cost consignment: " << cost_consignment << endl;

		for (int i = 0; i < quantity_sell; i++)
		{
			cout << "Day " << i + 1 << " sell: ";
			cout << list_sell[i];
			cout << endl;
		}
		cout << "\n\nTotal cost of goods delivery: " << cost_consignment*quantity_sell<<endl;
		cout << "Total profit from sale of goods: " << quantity_sell*cost*count<<endl;
		cout << "*****Weekly balance***** : " << (quantity_sell*cost*count) - (cost_consignment*quantity_sell) << endl;
		cout << "\t\t\tGOODBYE CUSTOMER" << endl;
	}
};

int main()
{
	/*cout << "\n\t\t SUPPLY of consingnment: " << endl;
	List_supply customer;
	cout << "\t\t SELL of consingnment: " << endl;
	Weekly_balance output;
	system("cls");

	customer.Show();
	output.Show();*/
	/*Supply_of_goods obj;

	system("cls");
	obj.Show();*/
	_getch();
	return 0;
}