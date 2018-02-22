/* -------------  drawmenu.cpp --------------*/

#include <windows.h>
#include <conio.h>
#include <iostream>
#include "drawmenu.h"
#include "menudemo.h"
using namespace std;
#define KEY_ARROW_RIGHT 77
#define KEY_ARROW_LEFT 75
#define KEY_ENTER 13
typedef void(*FUN) (void); 
													
typedef struct { 
	int x, y; 
	char *str; 
	FUN f; 
} ITEM;

HANDLE hStdOut; 
CONSOLE_SCREEN_BUFFER_INFO csbInfo;
SMALL_RECT consolRect; 
COORD curspos = { 0,1 }; 
WORD woêkWindowAttributes = 158;
WORD inactiveItemAttributes = FOREGROUND_GREEN; 
																	
WORD activeItemAttributes = 71; 
																 
enum menuitems { MNUGRAPHIC, MNUIMAGES, MNUEXIT };
extern const int numMenu = 3; 
ITEM menu[numMenu] = { 
											
	{ 1, 0, " Graphic ", File },
	{ 25, 0," Picture ", Do },
	{ 50, 0, " Exit ", Exit }
};

void DrawMenu() { 
	menuitems sel = MNUGRAPHIC; 
	SetConsoleTextAttribute(hStdOut, inactiveItemAttributes);
	string s(55, ' '); cout << s.c_str(); 
	for (int i = 0; i < numMenu; i++) { 
																			//ïóíêòîâ ìåíþ
		gotoxy(menu[i].x, menu[i].y);
		cout << menu[i].str;
	}
	itemMenu(sel, true); 
	fflush(stdin); 
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
					itemMenu(sel, false); 
					sel = (menuitems)(sel + 1);
					itemMenu(sel, true); 
				}
				else {
					itemMenu(sel, false); 
					sel = MNUGRAPHIC; 
					itemMenu(sel, true); 
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
					sel = MNUEXIT; 
					itemMenu(sel, true);
				}
				showCursor(false);
				break;
			case KEY_ENTER:
				gotoxy(curspos.X, curspos.Y); 
																			// ìåíþ â ïðåæíþþ ïîçèöèþ
				SetConsoleTextAttribute(hStdOut,
					woêkWindowAttributes); 
																 
				showCursor(true);
				switch (sel)
				{
				case MNUGRAPHIC:
					Sleep(500);
					File();

						
					//------------------------------------------------------------------------------------
						indikator_vyhoda = 1;
						getCursorPosition(); 
						break;
				case MNUIMAGES:
					Do();
					indikator_vyhoda = 1;
					getCursorPosition(); 
					break;
				case MNUEXIT:
					int ret_val;
				/*	int resp, tmp;
					cout << "Âû óâåðåíû, ÷òî õîòèòå âûéòè èç ïðîãðàììû ? (y / n) ? ";
					if (indikator_vyhoda == 1)
					{
						tmp = getchar();
					}

					resp = getchar();
					if (resp == 'y' || resp == 'Y')
					{
						gotoxy(0, 0); cls(1); exit(0);
					}*/
					ret_val=MessageBox(NULL, "Âû õîòèòå âûéòè?",
						"Âûõîä",MB_YESNO | MB_ICONERROR );
					if (ret_val== 6)
						exit(0);
					getCursorPosition();
															
					break;

					}
					fflush(stdin); 
					gotoxy(menu[sel].x, menu[sel].y); 
																						// òåêóùèé ïóíêò ìåíþ
					showCursor(false);
					break;
				case 120: 
				case 88: 
				case 27: 
					gotoxy(0, 0);
					cls(1);
					exit(0); 
				}
			}
		}
	}


void gotoxy(int x, int y)
{
	COORD cursorPos = { x, y };
	SetConsoleCursorPosition(hStdOut, cursorPos);
	
}

void getCursorPosition(void)
{
	GetConsoleScreenBufferInfo(hStdOut, &csbInfo);
	curspos = csbInfo.dwCursorPosition;// ïîëîæåíèå êóðñîðà
}

void cls(int it)
{
	int i;
	string s(55, ' ');
	SetConsoleTextAttribute(hStdOut, woêkWindowAttributes);
	if (it == 0) gotoxy(0, consolRect.Top + 1);
	else gotoxy(0, consolRect.Top);
	for (i = consolRect.Top; i < curspos.Y + 1; i++) 
																						 // ïåðâîé ñòðîêè äî ñòðîêè ñ êóðñîðîì
		cout << s.c_str(); 
		gotoxy(0, 0);
	
}

void itemMenu(int sel, bool activate)
{
	WORD itemAttributes;
	if (activate) itemAttributes = rand() % 255; 
	else itemAttributes = inactiveItemAttributes;
	gotoxy(menu[sel].x, menu[sel].y);
	SetConsoleTextAttribute(hStdOut, itemAttributes);
	cout << menu[sel].str;
}

void showCursor(bool visible)
{
	CONSOLE_CURSOR_INFO ccInfo;
	ccInfo.bVisible = visible;
	ccInfo.dwSize = 20;
	SetConsoleCursorInfo(hStdOut, &ccInfo);
}
