/* ------------- модуль drawmenu.cpp --------------*/
// Код функций для управлением строчным меню
#include <windows.h>
#include <conio.h>
#include <iostream>
#include "drawmenu.h"
#include "menudemo.h"
using namespace std;
#define KEY_ARROW_RIGHT 77
#define KEY_ARROW_LEFT 75
#define KEY_ENTER 13
typedef void(*FUN) (void); //Указатель на функцию void f(void)
													 //они будут выполнять пункты меню
typedef struct { //Структура для элемента меню
	int x, y; //Столбец и строка консоли
	char *str; //Наименование пункта меню
	FUN f; //Функция, привязанная к пункту меню
} ITEM;
// Глобальные переменные, используемые в функциях меню
HANDLE hStdOut; //дескриптор консольного окна
CONSOLE_SCREEN_BUFFER_INFO csbInfo;//информация о консольном окне
SMALL_RECT consolRect; //координату углов консольного окна
COORD curspos = { 0,1 }; //координаты текстового курсора
WORD woкkWindowAttributes = 158;//атрибуты рабочей области
WORD inactiveItemAttributes = FOREGROUND_GREEN; //атрибуты цвета неактивного
																	// пункта меню
WORD activeItemAttributes = 71; // атрибуты цвета активного
																 // пункта меню
																 // Изменяемые элементы меню
enum menuitems { MNUGRAPHIC, MNUIMAGES, MNUEXIT };
extern const int numMenu = 3; //количество пунктов меню
ITEM menu[numMenu] = { //положение (x,y), заголовок,
											 // указатель на функцию
	{ 1, 0, " Graphic ", File },
	{ 25, 0," Picture ", Do },
	//{ 50, 0, " Очистить ", Exit },
	{ 50, 0, " Exit ", Exit }
};
// Длина строк заголовков " Файл ", " Действие "," Очистить ",
// " Выход " должна быть подобрана в соответствии с их
// X - координатами в массиве menu[]
void DrawMenu() { //Управление меню
	menuitems sel = MNUGRAPHIC; // Номер текущего пункта меню
	SetConsoleTextAttribute(hStdOut, inactiveItemAttributes);
	string s(55, ' '); cout << s.c_str(); //залить фон строки меню
	for (int i = 0; i < numMenu; i++) { //Напечатать заголовки
																			//пунктов меню
		gotoxy(menu[i].x, menu[i].y);
		cout << menu[i].str;
	}
	itemMenu(sel, true); // выделить пункт меню
	fflush(stdin); //очистить буфер клавиатуры
	int iKey = 67, indikator_vyhoda = 0;
	while (1)
	{
		if (_kbhit())
		{
			iKey = _getch();
			switch (iKey)
			{
			case KEY_ARROW_RIGHT:
				if (sel < numMenu - 1) {
					itemMenu(sel, false); // сделать неактивным пункт меню
					sel = (menuitems)(sel + 1);
					itemMenu(sel, true); // выделить активный пункт меню
				}
				else {
					itemMenu(sel, false); // сделать неактивным пункт меню
					sel = MNUGRAPHIC; // прокрутка влево
					itemMenu(sel, true); // выделить активный пункт меню
				}
				showCursor(false);
				break;
			case KEY_ARROW_LEFT:
				if (sel > 0) {
					itemMenu(sel, false);
					sel = (menuitems)(sel - 1);
					itemMenu(sel, true);
				}
				else {
					itemMenu(sel, false);
					sel = MNUEXIT; // прокрутка влево
					itemMenu(sel, true);
				}
				showCursor(false);
				break;
			case KEY_ENTER:
				gotoxy(curspos.X, curspos.Y); //возвращаем курсор из строки
																			// меню в прежнюю позицию
				SetConsoleTextAttribute(hStdOut,
					woкkWindowAttributes); // Установить цвет
																 // рабочих сообщений
				showCursor(true);
				switch (sel)
				{
				case MNUGRAPHIC:
					Sleep(500);
					File();
						
					//------------------------------------------------------------------------------------
						indikator_vyhoda = 1;
						getCursorPosition(); // запомнить положение курсора
						break;
				case MNUIMAGES:
					Do();
					indikator_vyhoda = 1;
					getCursorPosition(); // запомнить положение курсора
					break;
				case MNUEXIT:
					int ret_val;
				/*	int resp, tmp;
					cout << "Вы уверены, что хотите выйти из программы ? (y / n) ? ";
					if (indikator_vyhoda == 1)
					{
						tmp = getchar();
					}

					resp = getchar();
					if (resp == 'y' || resp == 'Y')
					{
						gotoxy(0, 0); cls(1); exit(0);
					}*/
					ret_val=MessageBox(NULL, "Вы хотите выйти?",
						"Выход",MB_YESNO | MB_ICONERROR );
					if (ret_val== 6)
						exit(0);
					getCursorPosition(); // запомнить положение курсора,
															 // если отменили выход
					break;

					}
					fflush(stdin); //очистить буфер клавиатуры
					gotoxy(menu[sel].x, menu[sel].y); // курсор в
																						// текущий пункт меню
					showCursor(false);
					break;
				case 120: // выход по клавише x
				case 88: // выход по клавише X
				case 27: // выход по клавише ESC
					gotoxy(0, 0);
					cls(1);
					exit(0); //завершение программы
				}
			}
		}
	}

// Текстовый курсор в точку x,y
void gotoxy(int x, int y)
{
	COORD cursorPos = { x, y };
	SetConsoleCursorPosition(hStdOut, cursorPos);
	//SetConsoleCursorPosition(hStdOut, {x,y});
}
// запись текущего положения текстового курсора в глобальную
// переменную curspos
void getCursorPosition(void)
{
	GetConsoleScreenBufferInfo(hStdOut, &csbInfo);
	curspos = csbInfo.dwCursorPosition;// положение курсора
}
// очистка тестовой области консоли. Если it==0, то очистка со
// строки следующей за строкой меню, иначе очистка с левого
// верхнего угла консоли
void cls(int it)
{
	int i;
	string s(55, ' ');
	SetConsoleTextAttribute(hStdOut, woкkWindowAttributes);
	if (it == 0) gotoxy(0, consolRect.Top + 1);
	else gotoxy(0, consolRect.Top);
	for (i = consolRect.Top; i < curspos.Y + 1; i++) // очистка от
																						 // первой строки до строки с курсором
		cout << s.c_str(); // залить фон строки меню
		gotoxy(0, 0);
	
}
// выделить пункт меню с номером sel
void itemMenu(int sel, bool activate)
{
	WORD itemAttributes;
	if (activate) itemAttributes = rand() % 255; //activeItemAttributes;
	else itemAttributes = inactiveItemAttributes;
	gotoxy(menu[sel].x, menu[sel].y);
	SetConsoleTextAttribute(hStdOut, itemAttributes);
	cout << menu[sel].str;
}
// скрыть/показать текстовый курсор в консоли
void showCursor(bool visible)
{
	CONSOLE_CURSOR_INFO ccInfo;
	ccInfo.bVisible = visible;
	ccInfo.dwSize = 20;
	SetConsoleCursorInfo(hStdOut, &ccInfo);
}