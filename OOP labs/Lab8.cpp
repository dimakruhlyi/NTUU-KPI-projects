#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <cstring>
#include <string>
#include <string.h>
#include <ctime>
#include <time.h>
#include <iomanip> 
#include <fstream>
#include <typeinfo>    
#include <vector>
#include <algorithm> 
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

	void set_medicineName(string name)
	{
		this->medicineName = name;
	}

	void set_medicineType(string type)
	{
		this->medicineType = type;
	}

	//--------------------------------CHAR-------------------------------

	/*void set_medicineName_Char(char* medicineName_char_n)
	{
	medicineName_char = new char[strlen(medicineName_char_n) + 1];
	strcpy(this->medicineName_char, medicineName_char_n);
	}

	void set_medicineType_Char(char* medicineType_char_n)
	{
	medicineType_char = new char[strlen(medicineType_char_n) + 1];
	strcpy(this->medicineType_char, medicineType_char_n);
	}*/

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
	friend istream& operator >> (istream& stream, const Medicine& dt);
};

ostream& operator<<(ostream& os, const Medicine& dt)
{
	//os << "Name                  Type            Price " << endl;
	os.width(5);
	os << dt.medicineName;
	os.width(22);
	os << dt.medicineType;
	os.width(18);
	os << dt.medicinePrice;
	return os;
}

istream& operator >> (istream& stream, Medicine &dt)
{
	string medicineName, medicineType;
	int medicinePrice;
	stream >> medicineName >> medicineType;
	stream >> medicinePrice;
	dt.set_medicineName(medicineName);
	dt.set_medicineType(medicineType);
	dt.set_medicinePrice(medicinePrice);
	return stream;
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
		medName = "Citramon   ";
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
		medName = "Vitrum     ";
		medName_Char = new char[strlen("Vitrum     ") + 1];
		strcpy(medName_Char, "Vitrum     ");
	}break;
	case 4:
	{
		medName = "Noshpa     ";
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
		medName = "Amizon     ";
		medName_Char = new char[strlen("Amizon     ") + 1];
		strcpy(medName_Char, "Amizon     ");
	}
	}

	//------------------------------------------------STRING---------------------

	this->set_medicineName(medName);
	this->set_medicineType(medicineType);

	//----------------------------------------------CHAR-----------------------

	/*this->set_medicineName_Char(medName_Char);
	this->set_medicineType_Char(medicineType_Char);*/

	//------------------------------------------------------------------------

	this->set_medicinePrice(rand() % 100 - 80);


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
	friend istream& operator >> (istream& stream, const Date& dt);
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

istream& operator >> (istream& stream, Date& dt)
{
	int dateYear, dateMounth,dateDay;
	stream >> dateYear >> dateMounth >> dateDay;
	dt.set_dateYear(dateYear);
	dt.set_dateMounth(dateMounth);
	dt.set_dateDay(dateDay);
	return stream;
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

	void set_pharmacistName(string name)
	{
	this->pharmacistName = name;
	}

	void set_pharmacistSurname(string surname)
	{
	this->pharmacistSurname = surname;
	}

	//------------------------------------------------------------CHAR---------------------

	/*void set_pharmacistName_Char(char* name_char)
	{
		pharmacistName_Char = new char[strlen(name_char) + 1];
		strcpy(this->pharmacistName_Char, name_char);
	}

	void set_pharmacistSurname_Char(char* surname_char)
	{
		pharmacistSurname_Char = new char[strlen(surname_char) + 1];
		strcpy(this->pharmacistSurname_Char, surname_char);
	}*/
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
	friend istream& operator >> (istream& stream, const Pharmacist& dt);
};

ostream& operator<<(ostream& os, const Pharmacist& Pharmacist_n)
{
	//os << "YearB MounthB DayB  Name  Surname" << endl;
	os << (Date&)Pharmacist_n;
	os.width(10);
	os << Pharmacist_n.pharmacistName;
	os.width(13);
	os << Pharmacist_n.pharmacistSurname;
	return os;
}

istream& operator >> (istream& stream, Pharmacist& dt)
{
	string name, surname;
	stream >> name >> surname;
	dt.set_pharmacistName(name);
	dt.set_pharmacistSurname(surname);
	return stream;
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

	this->set_pharmacistName(name);
	this->set_pharmacistSurname(surname);

	//-------------------------------CHAR-------------------------------------

	/*this->set_pharmacistName_Char(name_char);
	this->set_pharmacistSurname_Char(surname_char);*/

}

class Operation : virtual public  Medicine,virtual public Pharmacist
{
public:
	Date conducting;
	int count;
	double price_operation;
public:
	Operation();

	void set_CondYear(int a)
	{
		this->conducting.set_dateYear(a);
	}
	
	void set_CondMonth(int a)
	{
		this->conducting.set_dateMounth(a);
	}
	
	void set_CondDay(int a)
	{
		this->conducting.set_dateDay(a);
	}
	
	Date get_Cond()
	{
		return this->conducting;
	}

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
	friend istream& operator >> (istream& stream, const Operation& dt);
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

istream &operator >> (istream &stream, Operation &dt)
{
	Date a;
	double price_operation;
	stream >> a;
	//dt.set_ASale(a);
	stream >> price_operation;
	dt.set_price_operation(price_operation);
	return stream;
}

Operation::Operation()
{
	this->set_count(rand() % 100 + 1);
	this->set_price_operation(rand() % 2000 + 1);
}

void init_Medicine(Medicine *medicine_n);
void init_Pharmacist(Pharmacist *pharmacist_n);
void init_Operation(Operation *operation_n);

class List_of_operations_for_a_week : virtual public Date, virtual public Operation
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

	void WriteFile(string);
	void WriteFileBinary(string);
};

ostream& operator<<(ostream& os, const List_of_operations_for_a_week& List_of_operations_for_a_week_n)
{
	os << "Date first day os the week: " << endl;
	os << "Year Mounth Day " << endl;
	os << (Date&)List_of_operations_for_a_week_n;
	os << "\n\n";
	os << "Count = " << List_of_operations_for_a_week_n.count << endl;
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

void List_of_operations_for_a_week::WriteFile(string fOut)
{
	ofstream file_out(/*fOut*/"file_single_out.txt");
	file_out << *this;
	file_out.close();
}

void List_of_operations_for_a_week::WriteFileBinary(string fOut_binary)
{
	ofstream file_out(/*fOut_binary*/"file_binary_out.txt", ios_base::binary);
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
		cout << "Date year: " << setprecision(4) << get_dateYear() << endl;
		cout << "Date mounth: " << setprecision(4) << get_dateMounth() << endl;
		cout << "Date day: " << setprecision(4) << get_dateDay() << endl;
	}
};

template <class AnyType>
DATE_NEW<AnyType>::DATE_NEW()
{
	this->set_dateYear(rand() % (2017 - 1950 + 1) + 1950);
	this->set_dateMounth(rand() % 12 + 1);
	this->set_dateDay(rand() % 31 + 1);
}

void SortDynamicArraySymbol(List_of_operations_for_a_week obj)
{
	string temp;
	string *arrStr = new string[obj.get_List_of_operations_for_a_week_Count()];
	for (int i = 0; i < obj.get_List_of_operations_for_a_week_Count(); i++) {
		arrStr[i] = obj[i].Operation::Medicine::get_medicineName();
	}
	for (int i = 1; i <= obj.get_List_of_operations_for_a_week_Count(); i++)
		for (int j = 0; j < obj.get_List_of_operations_for_a_week_Count() - i; j++) {
			if (strcmp(arrStr[j].c_str(), arrStr[j + 1].c_str()) > 0) {
				temp = arrStr[j];
				arrStr[j] = arrStr[j + 1];
				arrStr[j + 1] = temp;
			}
		}
	for (int i = 0; i < obj.get_List_of_operations_for_a_week_Count(); i++) {
		cout << arrStr[i] << endl;
	}
}

void SortDynamicArrayInt(List_of_operations_for_a_week obj) {
	int temp;
	int *arrInt = new int[obj.get_List_of_operations_for_a_week_Count()];
	for (int i = 0; i < obj.get_List_of_operations_for_a_week_Count(); i++) {
		arrInt[i] = obj[i].get_price_operation();
	}
	for (int i = 1; i <= obj.get_List_of_operations_for_a_week_Count(); i++) {
		for (int j = 0; j < obj.get_List_of_operations_for_a_week_Count() - i; j++) {
			if (*(arrInt + j) > *(arrInt + j + 1)) {
				temp = *(arrInt + j);
				*(arrInt + j) = *(arrInt + j + 1);
				*(arrInt + j + 1) = temp;
			}
		}
	}
	for (int i = 0; i < obj.get_List_of_operations_for_a_week_Count(); i++) {
		cout << arrInt[i] << endl;
	}
}

void ReadWriteFileWithArrayOfPointers(List_of_operations_for_a_week a /*string sInPointersArray, string sOut_2_PointersArray*/) {

	Operation obj2;
	Operation *pt_obj2 = &a;

	cout << "\n\n\t Pointer on : " << typeid(pt_obj2).name() << endl;
	cout << "\t*Pointer on : " << typeid(*pt_obj2).name() << endl << endl;


	Operation **pp = new Operation *[a.get_List_of_operations_for_a_week_Count()];
	for (int i = 0; i < a.get_List_of_operations_for_a_week_Count(); i++) {
		pp[i] = new Operation[13];
	}
	int pp_count, year, day, mounth, medicinePrice, Count, priceOperation;
	string medicineName, medicineType, TypeSaleType, Name, Surname;
	a.WriteFile(/*sInPointersArray*/"file_single_out.txt");
	//os << "Year Mounth Day medicineName           medicineType        medicinePrice   count  YearB MthB DayB   Name      Surname   priceOperation" << endl;
	ifstream fin(/*sInPointersArray*/"file_single_out.txt");
	/*if (!fin.is_open())
		cout << "Can't open file!\n";
	else {*/
		fin >> pp_count;
		for (int i = 0; i < pp_count; i++) {
			fin >> year >> mounth >> day >> medicineName >> medicineType >> medicinePrice >> Count >> year >> mounth >> day>> Name>> Surname>> priceOperation;
			pp[i]->set_CondYear(year);
			pp[i]->set_CondMonth(mounth);
			pp[i]->set_CondDay(day);
			pp[i]->set_medicineName(medicineName);
			pp[i]->set_medicineType(medicineType);
			pp[i]->set_medicinePrice(medicinePrice);
			pp[i]->set_count(Count);
			pp[i]->set_CondYear(year);
			pp[i]->set_CondMonth(mounth);
			pp[i]->set_CondDay(day);
			pp[i]->set_pharmacistName(Name);
			pp[i]->set_pharmacistSurname(Surname);
			pp[i]->set_price_operation(priceOperation);
		}
		fin.close();
	

	ofstream f_out(/*sOut_2_PointersArray*/"file_pp_out.txt");
	//f_out << pp_count;
	for (int i = 0; i < a.get_List_of_operations_for_a_week_Count(); i++) {
		f_out << "       ";
		f_out << *pp[i] << endl;
	}
	f_out.close();
}

class MyExceptionInt {
public:
	int errNum;

	MyExceptionInt() { errNum = 1; }
	MyExceptionInt(int s) {
		errNum = s;
	}
};

class MyExceptionStr : virtual public MyExceptionInt {
public:
	string errStr;

	MyExceptionStr() { errStr = "OK"; }
	MyExceptionStr(string s) { errStr = s; }
	MyExceptionStr(int s) { errNum = s; }

};

bool Predikat_INT(int x, int y) { 
	return x < y;
}
bool Predikat_String(string elem1, string elem2)
{
	bool a;
	const char *p = elem1.c_str();
	const char *p2 = elem2.c_str();
	if (_strnicmp(p, p2, 10)<0)
		a = true;
	else
		a = false;
	return a;
}
void VectorVsDynamicSort(List_of_operations_for_a_week obj)
{
	/*----------------------- vector string sort -----------------------*/
	vector<string> myVector;
	for (int i = 0; i < obj.get_List_of_operations_for_a_week_Count(); i++) {
		myVector.push_back(obj[i].Operation::Medicine::get_medicineName());
	}
	clock_t t1;
	t1 = clock();
	sort(myVector.begin(), myVector.end(), Predikat_String);
	cout << "\n\tSTRING sorted AUTOMATICAL: " << endl;
	for (int i = 0; i < obj.get_List_of_operations_for_a_week_Count(); i++) {
		cout << myVector[i] << endl;
	}
	t1 = clock() - t1;
	printf("\nTime of working %d clicks (%f seconds).\n", (int)t1, ((double)t1) / CLOCKS_PER_SEC);
	cout << endl << endl;
	/*----------------------- dynamic array string sort -----------------------*/
	clock_t t2;
	t2 = clock();
	cout << "\n\tSTRING dynamic array sorted by MY SORT FUNCTION: " << endl;
	SortDynamicArraySymbol(obj);
	t2 = clock() - t2;
	printf("\nTime of working %d clicks(%f seconds).\n", (int)t2, ((double)t2) / CLOCKS_PER_SEC);

	/*----------------------- vector int sort -----------------------*/
	vector<int> myVectorInt;
	for (int i = 0; i < obj.get_List_of_operations_for_a_week_Count(); i++) {
		myVectorInt.push_back(obj[i].get_price_operation());
	}
	clock_t t3;
	t3 = clock();
	sort(myVectorInt.begin(), myVectorInt.end(), Predikat_INT);
	cout << "\n\tINT sorted AUTOMATICAL: " << endl;
	for (int i = 0; i < obj.get_List_of_operations_for_a_week_Count(); i++) {
		cout << myVectorInt[i] << endl;
	}
	t3 = clock() - t3;
	printf("\nTime of working %d clicks (%f seconds).\n", (int)t3, ((double)t3) / CLOCKS_PER_SEC);
	cout << endl << endl;
	/*----------------------- dynamic array  int sort -----------------------*/
	clock_t t4;
	t4 = clock();
	cout << "\n\tINT dynamic array sorted by MY SORT FUNCTION: " << endl;
	SortDynamicArrayInt(obj);
	t4 = clock() - t4;
	printf("\nTime of working %d clicks (%f seconds).\n", (int)t4, ((double)t4) / CLOCKS_PER_SEC);
	/*----------------------- dynamic array  int sort -----------------------*/

}

int main()
{
	/*string sOutSingleListArray;
	string sOutBinaryListArray;
	string sOut_2_PointersArray;*/

	srand(time(NULL));
	clock_t t;
	t = clock();

	cout << "\n\n\n";
		/* ----------------------------------Exception Block--------------------------------------------------*/
		try {

			Medicine a;
			cout << a << endl;
			if (a.get_medicineName() == "Paracetamol") throw MyExceptionStr("Paracetamol");
			else if (a.get_medicinePrice() < 0) throw MyExceptionStr(404);
			else if (a.get_medicineName() == "Remancardin") throw MyExceptionStr(" Remancardin!!!");
			else if (a.get_medicineType() == "With Recept") MyExceptionStr("  With Recept !!");
			else {
				cout << a << endl;
			}
		}

		catch (MyExceptionStr obj) {
			if (obj.errStr == "") {
				cout << "ERROR : " << obj.errNum << " (Number  < 0) error!!" << endl;
			}
			else {
				cout << obj.errStr << endl;
			}
		}

		catch (MyExceptionInt obj) {
			cout << "ERROR ¹" << obj.errNum << "Number error!!" << endl;
		}
		/* ----------------------------------Exception Block--------------------------------------------------*/
		
		cout << "\n\n\n";
		List_of_operations_for_a_week obj;
		cout << obj;
		obj.WriteFile("file_pp_out.txt");
		obj.WriteFileBinary("file_binary_out.txt");

	ReadWriteFileWithArrayOfPointers(obj/*, sOutSingleListArray, sOut_2_PointersArray*/);

	cout << "\n\n\n";
	VectorVsDynamicSort(obj);

	_getch();
	return 0;
}