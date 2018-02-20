#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <cstring>
#include <string>
#include <ctime>
#include <time.h>
#include <iomanip> 
#include <fstream>
#include <typeinfo> 
#include<conio.h>

using namespace std;

enum typeMedicine { withRecept = 1, withoutRecept };

class Medicine
{
protected:
	string medicineName;
	string medicineType;
	int medicinePrice;

	char* medicineName_char;
	char* medicineType_char;
public:
	Medicine();

	/*void set_medicineName(string name)
	{
	this->medicineName = name;
	}

	void set_medicineType(string type)
	{
	this->medicineType = type;
	}*/

	//--------------------------------CHAR-------------------------------

	void set_medicineName_Char(char* medicineName_char_n)
	{
		medicineName_char = new char[strlen(medicineName_char_n) + 1];
		strcpy(this->medicineName_char, medicineName_char_n);
	}

	void set_medicineType_Char(char* medicineType_char_n)
	{
		medicineType_char = new char[strlen(medicineType_char_n) + 1];
		strcpy(this->medicineType_char, medicineType_char_n);
	}

	//----------------------------------------------------------------

	void set_medicinePrice(int price)
	{
		this->medicinePrice = price;
	}

	int get_medicinePrice()
	{
		return this->medicinePrice;
	}

	string get_medicineName()
	{
		return this->medicineName;
	}

	string get_medicineType()
	{
		return this->medicineType;
	}

	virtual void Show()
	{
		cout << "Medicine name: " << this->get_medicineName() << endl;
		cout << "Medicine type: " << this->get_medicineType() << endl;;
		cout << "Medicine price: " << this->get_medicinePrice() << endl;;
	}

	void operator = (Medicine Medicine_n)
	{
		this->medicineName = Medicine_n.medicineName;
		this->medicinePrice = Medicine_n.medicinePrice;
	}

	friend ostream& operator<<(ostream& os, const Medicine& dt);
};

ostream& operator<<(ostream& os, const Medicine& dt)
{
	//os << "Name                  Type            Price " << endl;
	os.width(5);
	os << dt.medicineName_char;
	os.width(22);
	os << dt.medicineType_char;
	os.width(18);
	os<<dt.medicinePrice;
	return os;
}

Medicine::Medicine()
{
	int choose;
	string medicineType, medName;
	typeMedicine typeS;

	char* medicineType_Char;
	char* medName_Char;

	choose = rand() % 2 + 1;

	switch (choose)
	{
	case withRecept:
	{
		medicineType = "With Recept";
		medicineType_Char = new char[strlen("With Recept") + 1];
		strcpy(medicineType_Char, "With Recept");
	}break;
	case withoutRecept:
	{
		medicineType = "Without Recept";
		medicineType_Char = new char[strlen("Without Recept") + 1];
		strcpy(medicineType_Char, "Without Recept");
	}break;
	default:
	{
		medicineType = "Without Recept";
		medicineType_Char = new char[strlen("Without Recept") + 1];
		strcpy(medicineType_Char, "Without Recept");
	}
	}

	choose = rand() % 5 + 1;

	switch (choose)
	{
	case 1:
	{
		medName = "Citramon";
		medName_Char = new char[strlen("Citramon   ") + 1];
		strcpy(medName_Char, "Citramon   ");
	}break;
	case 2:
	{
		medName = "Paracetamol";
		medName_Char = new char[strlen("Paracetamol") + 1];
		strcpy(medName_Char, "Paracetamol");
	}break;
	case 3:
	{
		medName = "Vitrum";
		medName_Char = new char[strlen("Vitrum     ") + 1];
		strcpy(medName_Char, "Vitrum     ");
	}break;
	case 4:
	{
		medName = "Noshpa";
		medName_Char = new char[strlen("Noshpa     ") + 1];
		strcpy(medName_Char, "Noshpa     ");
	}break;
	case 5:
	{
		medName = "Remancardin";
		medName_Char = new char[strlen("Remancardin") + 1];
		strcpy(medName_Char, "Remancardin");
	}break;
	default:
	{
		medName = "Amizon";
		medName_Char = new char[strlen("Amizon     ") + 1];
		strcpy(medName_Char, "Amizon     ");
	}
	}

	//------------------------------------------------STRING---------------------

	/*this->set_medicineName(medName);
	this->set_medicineType(medicineType);*/

	//----------------------------------------------CHAR-----------------------

	this->set_medicineName_Char(medName_Char);
	this->set_medicineType_Char(medicineType_Char);

	//------------------------------------------------------------------------

	this->set_medicinePrice(rand() % 100 + 1);


}

class Date
{
protected:
	int dateYear;
	int dateMounth;
	int dateDay;
public:
	Date();

	void set_dateYear(int year)
	{
		this->dateYear = year;
	}

	void set_dateMounth(int mounth)
	{
		this->dateMounth = mounth;
	}

	void set_dateDay(int day)
	{
		this->dateDay = day;
	}

	int get_dateYear()
	{
		return this->dateYear;
	}

	int get_dateMounth()
	{
		return this->dateMounth;
	}

	int get_dateDay()
	{
		return this->dateDay;
	}

	virtual void Show()
	{
		cout << "Date year: " << get_dateYear() << endl;
		cout << "Date mounth: " << get_dateMounth() << endl;
		cout << "Date day: " << get_dateDay() << endl;
	}

	friend ostream& operator<<(ostream& os, const Date& dt);
};

ostream& operator<<(ostream& os, const Date& dt)
{
	//os << "Year Mounth Day " << endl;
	os.width(5);
	os << dt.dateYear;
	os.width(4);
	os << dt.dateMounth;
	os.width(5);
	os << dt.dateDay;
	return os;
}

Date::Date()
{
	this->set_dateYear(rand() % (2017 - 1950 + 1) + 1950);
	this->set_dateMounth(rand() % 12 + 1);
	this->set_dateDay(rand() % 31 + 1);
}

class Pharmacist : virtual public Date
{
protected:
	string pharmacistName;
	string pharmacistSurname;

	char* pharmacistName_Char;
	char* pharmacistSurname_Char;
public:
	Pharmacist();

	/*void set_pharmacistName(string name)
	{
	this->pharmacistName = name;
	}

	void set_pharmacistSurname(string surname)
	{
	this->pharmacistSurname = surname;
	}*/

	//------------------------------------------------------------CHAR---------------------

	void set_pharmacistName_Char(char* name_char)
	{
		pharmacistName_Char = new char[strlen(name_char) + 1];
		strcpy(this->pharmacistName_Char, name_char);
	}

	void set_pharmacistSurname_Char(char* surname_char)
	{
		pharmacistSurname_Char = new char[strlen(surname_char) + 1];
		strcpy(this->pharmacistSurname_Char, surname_char);
	}
	//----------------------------------------------------------------------------------

	string get_pharmacistName()
	{
		return this->pharmacistName;
	}

	string get_pharmacistSurname()
	{
		return this->pharmacistSurname;
	}

	virtual void Show()
	{
		cout << "\nBirthday of pharmacist:" << endl;
		Date::Show();
		cout << "\nPharmacist name is: " << this->get_pharmacistName() << endl;
		cout << "Pharmacist surname is: " << this->get_pharmacistSurname() << endl;
	}

	void operator =(Pharmacist obj)
	{
		this->pharmacistName = obj.pharmacistName;
		this->pharmacistSurname = obj.pharmacistSurname;
	}

	friend ostream& operator<<(ostream& os, const Pharmacist& Pharmacist_n);
};

ostream& operator<<(ostream& os, const Pharmacist& Pharmacist_n)
{
	//os << "YearB MounthB DayB  Name  Surname" << endl;
	os << (Date&)Pharmacist_n;
	os.width(10);
	os << Pharmacist_n.pharmacistName_Char;
	os.width(13);
	os << Pharmacist_n.pharmacistSurname_Char;
	return os;
}

Pharmacist::Pharmacist()
{
	int choose;
	string name, surname;

	char* name_char;
	char* surname_char;

	choose = rand() % 5 + 1;

	switch (choose)
	{
	case 1:
	{
		name = "Dima";
		name_char = new char[strlen("Dima") + 1];
		strcpy(name_char, "Dima");
	}break;
	case 2:
	{
		name = "Sergiy";
		name_char = new char[strlen("Sergiy") + 1];
		strcpy(name_char, "Sergiy");
	}break;
	case 3:
	{
		name = "Maxym";
		name_char = new char[strlen("Maxym") + 1];
		strcpy(name_char, "Maxym");
	}break;
	case 4:
	{
		name = "Andriy";
		name_char = new char[strlen("Andriy") + 1];
		strcpy(name_char, "Andriy");
	}break;
	case 5:
	{
		name = "Nazar";
		name_char = new char[strlen("Nazar") + 1];
		strcpy(name_char, "Nazar");
	}break;
	default:
	{
		name = "Oleg";
		name_char = new char[strlen("Oleg") + 1];
		strcpy(name_char, "Oleg");
	}
	}

	choose = rand() % 5 + 1;

	switch (choose)
	{
	case 1:
	{
		surname = "Kruhlyi";
		surname_char = new char[strlen("Kruhlyi") + 1];
		strcpy(surname_char, "Kruhlyi");
	}break;
	case 2:
	{
		surname = "Oliynyk";
		surname_char = new char[strlen("Oliynyk") + 1];
		strcpy(surname_char, "Oliynyk");
	}break;
	case 3:
	{
		surname = "Tymoshenko";
		surname_char = new char[strlen("Tymoshenko") + 1];
		strcpy(surname_char, "Tymoshenko");
	}break;
	case 4:
	{
		surname = "Dmytruk";
		surname_char = new char[strlen("Dmytruk") + 1];
		strcpy(surname_char, "Dmytruk");
	}break;
	case 5:
	{
		surname = "Shkliarskyi";
		surname_char = new char[strlen("Shkliarskyi") + 1];
		strcpy(surname_char, "Shkliarskyi");
	}break;
	default:
	{
		surname = "Momot";
		surname_char = new char[strlen("Momot") + 1];
		strcpy(surname_char, "Momot");
	}
	}
	//---------------------------------STRING--------------------------------

	/*this->set_pharmacistName(name);
	this->set_pharmacistSurname(surname);*/

	//-------------------------------CHAR-------------------------------------

	this->set_pharmacistName_Char(name_char);
	this->set_pharmacistSurname_Char(surname_char);

}

class Operation : virtual public  Medicine, Pharmacist
{
public:
	Date conducting;
	int count;
	double price_operation;
public:
	Operation();

	void set_count(int qout)
	{
		this->count = qout;
	}

	void set_price_operation(double price)
	{
		this->price_operation = price;
	}

	int get_count()
	{
		return this->count;
	}

	double get_price_operation()
	{
		return this->price_operation;
	}

	virtual void Show()
	{
		cout << "Conducting an operation: " << endl;
		conducting.Show();
		cout << endl;
		Medicine::Show();
		Pharmacist::Show();

		cout << "Count of medicine: " << this->get_count() << endl;
		cout << "Price of operation: " << this->get_price_operation() << endl;
	}

	friend ostream& operator<<(ostream& os, const Operation& Operation_n);
};

ostream& operator<<(ostream& os, const Operation& Operation_n)
{
	//os << "Year Mounth Day medicineName   medicineType   medicinePrice   count  YearB  MounthB  DayB   Name   Surname   priceOperation" << endl;
	os << (Date&)Operation_n;
	os << "   ";
	os << (Medicine&)Operation_n;
	os.width(10);
	os << Operation_n.count;
	os << "   ";
	os << (Pharmacist&)Operation_n;
	os.width(10);
	os << Operation_n.price_operation;
	return os;
}

Operation::Operation()
{
	this->set_count(rand() % 100 + 1);
	this->set_price_operation(rand() % 200 + 1);
}

void init_Medicine(Medicine *medicine_n);
void init_Pharmacist(Pharmacist *pharmacist_n);
void init_Operation(Operation *operation_n);

class List_of_operations_for_a_week : virtual public Date, Operation
{
protected:
	Date first_day_of_week;
	Operation *Lists_of_operations;
	int count;
public:
	List_of_operations_for_a_week();

	void set_List_of_operations_for_a_week_Count(int count_n) {
		this->count = count_n;
	}

	int get_List_of_operations_for_a_week_Count() {
		return this->count;
	}

	Operation* get_Lists_of_operations()
	{
		return this->Lists_of_operations;
	}

	/*------------------------------------*/
	Operation& operator [] (int i) {

		if (i < 0 || i >= get_List_of_operations_for_a_week_Count()) {
			cout << "INDEX ERROR!";
			exit(1);
		}
		return Lists_of_operations[i];
	}
	/*-------------------------------------*/

	void Show()
	{
		cout << "\n\n\n Date of first day of a week: " << endl;
		first_day_of_week.Show();
		cout << "\n--------------------------------------------------" << endl;
		for (int i = 0; i < this->get_List_of_operations_for_a_week_Count(); i++)
		{
			cout << "------------------------- Part of operations list ------------------" << endl;
			Lists_of_operations[i].Show();
			cout << "----------------------------------------------------------" << endl;
		}
	}


	friend ostream& operator<<(ostream& os, const List_of_operations_for_a_week& List_of_operations_for_a_week_n);

	void WriteFile();
	void WriteFileBinary();
};

ostream& operator<<(ostream& os, const List_of_operations_for_a_week& List_of_operations_for_a_week_n)
{
	os << "Date first day os the week: " << endl;
	os << "Year Mounth Day " << endl;
	os << (Date&)List_of_operations_for_a_week_n;
	os << "\n\n";
	os << "Count = " << List_of_operations_for_a_week_n.count<<endl;
	os << "Lists of opetation: " << endl;
	os << "Year Mounth Day medicineName           medicineType        medicinePrice   count  YearB MthB DayB   Name      Surname   priceOperation" << endl;
	for (int i = 0; i < List_of_operations_for_a_week_n.count; i++)
	{
		os << (Operation&)List_of_operations_for_a_week_n.Lists_of_operations[i];
		os << endl;
	}
	return os;
}

void init_List_of_operations_for_a_week(List_of_operations_for_a_week *list_of_operations_for_a_week_n);

void List_of_operations_for_a_week::WriteFile()
{
	ofstream file_out("file_single_out.txt");
	file_out << *this;
	file_out.close();
}

void List_of_operations_for_a_week::WriteFileBinary()
{
	ofstream file_out("file_binary_out.txt", ios_base::binary);
	file_out << *this;
	file_out.close();
}

List_of_operations_for_a_week::List_of_operations_for_a_week()
{
	this->set_List_of_operations_for_a_week_Count(rand() % 200 + 1);
	/*cout << "\n\n\n Date of first day of a week: " << endl;
	first_day_of_week.Show();
	cout << "\n--------------------------------------------------" << endl;*/
	Lists_of_operations = new Operation[this->get_List_of_operations_for_a_week_Count()];
	for (int i = 0; i < this->get_List_of_operations_for_a_week_Count(); i++)
	{
		init_Operation(&Lists_of_operations[i]);
		/*cout << "------------------------- Part of operations list ------------------" << endl;
		Lists_of_operations[i].Show();
		cout << "----------------------------------------------------------" << endl;*/
	}
}

void init_Medicine(Medicine *medicine_n)
{
	Medicine obj;
	*medicine_n = obj;
}

void init_Pharmacist(Pharmacist *pharmacist_n)
{
	Pharmacist obj;
	*pharmacist_n = obj;
}

void init_Operation(Operation *operation_n)
{
	Operation obj;
	init_Medicine(operation_n);
	//init_Pharmacist(operation_n);
	*operation_n = obj;
}

void init_List_of_operations_for_a_week(List_of_operations_for_a_week *list_of_operations_for_a_week_n)
{
	List_of_operations_for_a_week obj;
	*list_of_operations_for_a_week_n = obj;

}

template <class AnyType>
double average_harmonical(AnyType a)
{
	double sum = 0;

	cout << a.get_List_of_operations_for_a_week_Count() << "\n\n\n\n";

	for (int i = 0; i < a.get_List_of_operations_for_a_week_Count(); i++)
	{
		cout << a[i].get_price_operation() << endl;
		sum += 1 / a[i].get_price_operation();

	}
	return a.get_List_of_operations_for_a_week_Count() / sum;;
}


template <class AnyType>
class List_of_operations_for_a_week_NEW : virtual public Date, Operation
{
protected:
	Date first_day;
	AnyType *List;
	int count;
public:
	List_of_operations_for_a_week_NEW();

	void set_count_NEW(int c)
	{
		this->count = c;
	}

	int get_count_NEW()
	{
		return this->count;
	}

	void Show()
	{
		cout << "\n\n\n Date of first day of a week: " << endl;
		first_day.Show();
		cout << "\n--------------------------------------------------" << endl;
		for (int i = 0; i < this->get_count_NEW(); i++)
		{
			cout << "------------------------- Part of operations list ------------------" << endl;
			List[i].Show();
			cout << "----------------------------------------------------------" << endl;
		}
	}
};

template<class AnyType>
List_of_operations_for_a_week_NEW<AnyType>::List_of_operations_for_a_week_NEW()
{
	this->set_count_NEW(rand() % 100 + 1);
	List = new Operation[this->get_count_NEW()];
	for (int i = 0; i < this->get_count_NEW(); i++)
	{
		init_Operation(&List[i]);
	}

}

/*additional template*/
template <class AnyType>
class DATE_NEW {
protected:
	AnyType dateYear;
	AnyType dateMounth;
	AnyType dateDay;
public:
	DATE_NEW();
	void set_dateYear(AnyType year)
	{
		this->dateYear = year;
	}

	void set_dateMounth(AnyType mounth)
	{
		this->dateMounth = mounth;
	}

	void set_dateDay(AnyType day)
	{
		this->dateDay = day;
	}

	AnyType get_dateYear()
	{
		return this->dateYear;
	}

	AnyType get_dateMounth()
	{
		return this->dateMounth;
	}

	AnyType get_dateDay()
	{
		return this->dateDay;
	}
	virtual void Show()
	{
		cout << "Date year: " << setprecision(4)<< get_dateYear() << endl;
		cout << "Date mounth: " << setprecision(4)<< get_dateMounth() << endl;
		cout << "Date day: " << setprecision(4)<< get_dateDay() << endl;
	}
};

template <class AnyType>
DATE_NEW<AnyType>::DATE_NEW()
{
	this->set_dateYear(rand() % (2017 - 1950 + 1) + 1950);
	this->set_dateMounth(rand() % 12 + 1);
	this->set_dateDay(rand() % 31 + 1);
}

int main()
{
	srand(time(NULL));
	
	clock_t t;
	t = clock();
	
	/*List_of_operations_for_a_week obj;
	cout << obj << endl;
	obj.WriteFile();
	obj.WriteFileBinary();*/

	DATE_NEW<int> obj;
	obj.Show();

	/*List_of_operations_for_a_week_NEW<Operation> obj;
	cout << "Count = " << obj.get_count_NEW() << endl;
	obj.Show();*/
	
	
	//-------------------------------------------------------------------------------------------
	/*List_of_operations_for_a_week object;
	init_List_of_operations_for_a_week(&object);
	object.Show();

	double harmonical = 0;
	harmonical = average_harmonical(object);
	cout << "AVERAGE HARMONICAL is: " << harmonical << endl;
	*/
	//-------------------------------------------------------------------------------------------
	t = clock() - t;
	printf("It took me %d clicks (%f seconds).\n", (int)t, ((double)t) / CLOCKS_PER_SEC);
	_getch();
	return 0;
}