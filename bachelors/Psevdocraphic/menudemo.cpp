/* ----  menudemo.cpp --- */
#define _win32_winnt 0x500
#include <windows.h>
#include <conio.h>
#include <iostream>
#include <clocale>
#include "drawmenu.h"
#include "menudemo.h"
#include<ctime>
#define KEY_ARROW_UP 72
#define KEY_ARROW_RIGHT 77
#define KEY_ARROW_DOWN 80
#define KEY_ARROW_LEFT 75

using namespace std;
extern HANDLE hStdOut; 
extern CONSOLE_SCREEN_BUFFER_INFO csbInfo; 
																					
extern SMALL_RECT consolRect; 
extern WORD woêkWindowAttributes; 
																	

int main()
{
	COORD coord;
	SetConsoleDisplayMode(GetStdHandle(STD_OUTPUT_HANDLE), CONSOLE_FULLSCREEN_MODE, &coord);
	srand(time(NULL));
	setlocale(LC_CTYPE, "rus"); 
															
	HWND hwnd = GetConsoleWindow();
	HDC hdc = GetDC(GetConsoleWindow());
	//system("title Console must die");
	SetConsoleTitle("Menu of program");
	hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);

	GetConsoleScreenBufferInfo(hStdOut, &csbInfo);
	consolRect = csbInfo.srWindow; 
	SetConsoleTextAttribute(hStdOut, woêkWindowAttributes);
	system("CLS"); 
	DrawMenu(); 
	ReleaseDC(NULL, hdc);
}

																	
																	
void setConsoleSize() 
{
	const int colConsole = 80;
	const int rowConsole = 30;
	HANDLE hNdl = GetStdHandle(STD_OUTPUT_HANDLE);
	SMALL_RECT windowSize = { 0,0,colConsole - 1,rowConsole - 1 };
	SetConsoleWindowInfo(hNdl, TRUE, &windowSize);
	COORD bufferSize = { colConsole, rowConsole }; 
	SetConsoleScreenBufferSize(hNdl, bufferSize);
}
void draw()
{
	HDC hdc = GetDC(GetConsoleWindow());
	char str[] = "Function: y=ln(1+x^2)";
	TextOutA(hdc, 550, 200, str, strlen(str));
	char str2[] = "And its GRAPHIC:";
	TextOutA(hdc, 560, 250, str2, strlen(str2));
	SelectObject(hdc, CreatePen(PS_SOLID, 2, RGB(125, 255, 125)));
	POINT ptRect[24] =
	{ { 650,650 } ,{ 660,645.68 },{ 670,644.8 },{ 680,643.4 },{ 690,642.9 },{ 700, 642.13 },{ 710,642 },{ 720, 641.7 },{ 730,641.2 },{ 740,640.5 },
	{ 750,640 },{ 760,639.4 },{ 770,638.8 },{ 780,638.2 },{ 790,637.6 },{ 800,636.9 },{ 810,636.3 },{ 820,635.7 },{ 830,635.2 },{ 840,634.8 },{ 850,634.5 },
	{ 900,632.6 },{ 950,630.8 },{ 1000,629.3 } };
	Polyline(hdc, ptRect, 24);

	
	char str4[] = "OX";
	TextOutA(hdc, 990, 660, str4, strlen(str4));
	SelectObject(hdc, CreatePen(PS_SOLID, 1, RGB(0, 0, 0)));
	POINT ox[2]
	{ {300,650},{1000,650} };
	Polyline(hdc, ox, 2);

	SelectObject(hdc, CreatePen(PS_SOLID, 1, RGB(0, 0, 0)));
	POINT strilka1[3]
	{ { 640,311 },{ 650,300 },{660,311} };
	Polyline(hdc, strilka1, 3);
	SelectObject(hdc, CreatePen(PS_SOLID, 1, RGB(0, 0, 0)));
	POINT strilka2[3]
	{ { 990,639 },{ 1000,650 },{ 990,661 } };
	Polyline(hdc, strilka2, 3);
	
	char str3[] = "OY";
	TextOutA(hdc, 630, 310, str3, strlen(str3));
	SelectObject(hdc, CreatePen(PS_SOLID, 1, RGB(0, 0, 0)));
	POINT oy[2]
	{ { 650,300 },{ 650,800 } };
	Polyline(hdc, oy, 2);
	
	char str5[] = "0";
	TextOutA(hdc, 640, 660, str5, strlen(str5));
	
	char cifra1[] = "1";
	TextOutA(hdc, 670, 660, cifra1, strlen(cifra1));
	char cifra2[] = "2";
	TextOutA(hdc, 700, 660, cifra2, strlen(cifra2));
	char cifra3[] = "3";
	TextOutA(hdc, 730, 660, cifra3, strlen(cifra3));
	char cifra1_1[] = "-1";
	TextOutA(hdc, 620, 660, cifra1_1, strlen(cifra1_1));
	char cifra2_2[] = "-2";
	TextOutA(hdc, 590, 660, cifra2_2, strlen(cifra2_2));
	char cifra3_3[] = "-3";
	TextOutA(hdc, 560, 660, cifra3_3, strlen(cifra3_3));
	
	
	char str6[] = "0.1";
	TextOutA(hdc, 635, 630, str6, strlen(str6));
	char str7[] = "0.2";
	TextOutA(hdc, 635, 615, str7, strlen(str7));
	SelectObject(hdc, CreatePen(PS_SOLID, 2, RGB(125, 255, 125)));
	POINT ptRect2[24] =
	{ { 650,650 } ,{ 640,645.68 },{ 630,644.8 },{ 620,643.4 },{ 610,642.9 },{ 600, 642.13 },{ 590,642 },{ 580, 641.7 },{ 570,641.2 },{ 560,640.5 },
	{ 550,640 },{ 540,639.4 },{ 530,638.8 },{ 520,638.2 },{ 510,637.6 },{ 500,636.9 },{ 490,636.3 },{ 480,635.7 },{ 470,635.2 },{ 460,634.8 },{ 450,634.5 },
	{ 400,632.6 },{ 350,630.8 },{ 300,629.3 } };
	Polyline(hdc, ptRect2, 24);
	_getch();
}
void File()
{
	HDC hdc = GetDC(GetConsoleWindow());
	setConsoleSize(); 
	Sleep(100);
	draw(); 
	int iKey = 1;
	while (iKey != 27) { 
		if (_kbhit()) {
			iKey = _getch();
			switch (iKey)
			{
			case 112: case 80: case 167: case 135:
				draw(); 
				break;
			}
		}
	}
	//system("CLS");
}
//---------------------------------------------------------------------------------------------------------------------------------------





void drawFish(HDC hdc, HRGN rgntilo, HRGN oko_ryby, HRGN hvist, HRGN verh_plavn, HRGN nyz_plavn, HBRUSH tilo_brush,
	HBRUSH oko_brush, HBRUSH hvist_brush, HBRUSH verh_plavn_brush, HBRUSH nyz_plavn_brush, HBRUSH bkBrsh, int rght, int dwn)
{
	FillRgn(hdc, rgntilo, bkBrsh);
	FillRgn(hdc, oko_ryby, bkBrsh);
	FillRgn(hdc, hvist, bkBrsh);
	FillRgn(hdc, verh_plavn, bkBrsh);
	FillRgn(hdc, nyz_plavn, bkBrsh);

	OffsetRgn(rgntilo, rght, dwn);
	OffsetRgn(oko_ryby, rght, dwn);
	OffsetRgn(hvist, rght, dwn);
	OffsetRgn(verh_plavn, rght, dwn);
	OffsetRgn(nyz_plavn, rght, dwn);

	FillRgn(hdc, rgntilo, tilo_brush);
	FillRgn(hdc, oko_ryby, oko_brush);
	FillRgn(hdc, hvist, hvist_brush);
	FillRgn(hdc, verh_plavn, verh_plavn_brush);
	FillRgn(hdc, nyz_plavn, nyz_plavn_brush);
}

void All_My_Life()
{
	HWND hwnd = GetConsoleWindow();
	HDC hdc = GetDC(hwnd);

	
	SelectObject(hdc, CreateSolidBrush(RGB(181, 207, 213)));
	Ellipse(hdc, 15, 650, 35, 630);
	Ellipse(hdc, 15, 350, 55, 320);
	Ellipse(hdc, 15, 100, 75, 50);

	Ellipse(hdc, 75, 450, 105, 420);

	Ellipse(hdc, 1180, 670, 1200, 650);
	Ellipse(hdc, 1180, 330, 1230, 300);
	Ellipse(hdc, 1180, 70, 1250, 20);

	Ellipse(hdc, 1300, 300, 1350, 270);

	//fishes
	SelectObject(hdc, CreateSolidBrush(RGB(143, 154, 152)));
	Ellipse(hdc, 1100, 200, 970, 150);
	SelectObject(hdc, CreateSolidBrush(RGB(4, 4, 4)));
	Ellipse(hdc, 990, 175, 980, 165);

	SelectObject(hdc, CreateSolidBrush(RGB(143, 154, 152)));
	Ellipse(hdc, 650, 400, 520, 350);
	SelectObject(hdc, CreateSolidBrush(RGB(4, 4, 4)));
	Ellipse(hdc, 540, 375, 530, 365);

	SelectObject(hdc, CreateSolidBrush(RGB(143, 154, 152)));
	Ellipse(hdc, 800, 600, 930, 550);
	SelectObject(hdc, CreateSolidBrush(RGB(4, 4, 4)));
	Ellipse(hdc, 910, 575, 920, 565);

	SelectObject(hdc, CreatePen(PS_SOLID, 5, RGB(236, 16, 4)));
	POINT hvist2[5] =
	{ { 1100,170 } ,{ 1120,145 },{ 1105,175 },{ 1120,195 },{ 1100,180 } };
	Polyline(hdc, hvist2, 5);
	POINT verh_plavn2[4] =
	{ { 1040,155 } ,{ 1060,135 },{ 1070,135 },{ 1050,155 } };
	Polyline(hdc, verh_plavn2, 4);
	POINT nyz_plavn2[4] =
	{ { 1035,195 } ,{ 1045,215 },{ 1060,215 },{ 1045,195 } };
	Polyline(hdc, nyz_plavn2, 4);

	SelectObject(hdc, CreatePen(PS_SOLID, 5, RGB(236, 16, 4)));
	POINT hvist3[5] =
	{ { 645,375 } ,{ 675,355 },{ 660,370 },{ 675,385 },{ 645,380 } };
	Polyline(hdc, hvist3, 5);
	POINT verh_plavn3[4] =
	{ { 585,355 } ,{ 605,335 },{ 625,335 },{ 600,355 } };
	Polyline(hdc, verh_plavn3, 4);
	POINT nyz_plavn3[4] =
	{ { 580,395 } ,{ 600,415 },{ 610,400 },{ 590,395 } };
	Polyline(hdc, nyz_plavn3, 4);

	SelectObject(hdc, CreatePen(PS_SOLID, 5, RGB(236, 16, 4)));
	POINT hvist4[5] =
	{ { 805,570 } ,{ 765,550 },{ 785,570 },{ 765,590 },{ 805,580 } };
	Polyline(hdc, hvist4, 5);
	POINT verh_plavn4[4] =
	{ { 870,555 } ,{ 850,525 },{ 830,525 },{ 860,555 } };
	Polyline(hdc, verh_plavn4, 4);
	POINT nyz_plavn4[4] =
	{ { 860,595 } ,{ 840,615 },{ 820,615 },{ 850,595 } };
	Polyline(hdc, nyz_plavn4, 4);


	
	SelectObject(hdc, CreatePen(PS_SOLID, 10, RGB(35, 167, 20)));
	POINT ptRect[8] =
	{ { 1100,750 } ,{ 1115,700 },{ 1105,680 },{ 1110,650 },{ 1090,600 },{ 1105, 570 },{ 1110,540 },{ 1090, 500 } };
	Polyline(hdc, ptRect, 8);
	SelectObject(hdc, CreatePen(PS_SOLID, 10, RGB(35, 167, 20)));
	POINT ptRect2[10] =
	{ { 1300,750 } ,{ 1280,700 },{ 1315,680 },{ 1305,650 },{ 1300,600 },{ 1310, 570 },{ 1320,540 },{ 1315, 500 },{ 1325,400 },{ 1310,350 } };
	Polyline(hdc, ptRect2, 10);
	SelectObject(hdc, CreatePen(PS_SOLID, 6, RGB(35, 167, 20)));
	POINT ptRect3[11] =
	{ { 1230,750 } ,{ 1250,700 },{ 1245,680 },{ 1235,650 },{ 1250,600 },{ 1245, 570 },{ 1260,540 },{ 1250, 500 },{ 1235,400 },{ 1248,350 },{ 1230,250 } };
	Polyline(hdc, ptRect3, 11);
	SelectObject(hdc, CreatePen(PS_SOLID, 6, RGB(35, 167, 20)));
	POINT ptRect4[11] =
	{ { 100,750 } ,{ 120,700 },{ 111,680 },{ 105,650 },{ 117,600 },{ 134, 570 },{ 119,540 },{ 127, 500 },{ 114,400 },{ 124,350 },{ 103,250 } };
	Polyline(hdc, ptRect4, 11);
	SelectObject(hdc, CreatePen(PS_SOLID, 4, RGB(82, 252, 99)));
	POINT ptRect5[12] =
	{ { 50,750 } ,{ 57,700 },{ 45,680 },{ 55,650 },{ 64,600 },{ 54, 570 },{ 43,540 },{ 31, 500 },{ 49,400 },{ 62,350 },{ 57,250 },{ 50,150 } };
	Polyline(hdc, ptRect5, 12);
	SelectObject(hdc, CreatePen(PS_SOLID, 10, RGB(0, 234, 0)));
	POINT ptRect6[5] =
	{ { 150,747 } ,{ 144,723 },{ 160,670 },{ 154,630 },{ 163,580 } };
	Polyline(hdc, ptRect6, 5);


	
	SelectObject(hdc, CreatePen(PS_SOLID, 1, RGB(212, 212, 212)));
	POINT leska[2] =
	{ { 590,0 },{ 590,300 } };
	Polyline(hdc, leska, 2);
	SelectObject(hdc, CreatePen(PS_SOLID, 3, RGB(120, 120, 120)));
	POINT gak[6] =
	{ { 590,300 },{ 590,330 },{ 585,330 },{ 582,328 },{ 581,325 },{ 582,320 } };
	Polyline(hdc, gak, 6);
	SelectObject(hdc, CreatePen(PS_SOLID, 6, RGB(238, 81, 215)));
	POINT worm[7] =
	{ { 590,330 },{ 585,330 },{ 582,328 },{ 581,325 },{ 582,320 },{ 578,325 },{ 580,327 } };
	Polyline(hdc, worm, 7);
}

void main_psevdographic()
{
	COORD coord;
	SetConsoleDisplayMode(GetStdHandle(STD_OUTPUT_HANDLE), CONSOLE_FULLSCREEN_MODE, &coord);
	HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
	//SetConsoleTextAttribute(hStdOut, BACKGROUND_BLUE);
	//system("cls");


	int q = 0;
	SetConsoleDisplayMode(GetStdHandle(STD_OUTPUT_HANDLE), CONSOLE_FULLSCREEN_MODE, &coord);
	HWND hwnd = GetConsoleWindow();
	HDC hdc = GetDC(hwnd); 
	RECT clientRect;
	q = GetClientRect(hwnd, &clientRect); 
	Sleep(100);
	HBRUSH bkBrush = CreateSolidBrush(RGB(20, 15, 244));
	HRGN bgRgn = CreateRectRgnIndirect(&clientRect);
	FillRgn(hdc, bgRgn, bkBrush);




	Sleep(100);
	
	RECT rct = { 1500,900,0,700 };
	FillRect(hdc, &rct, CreateSolidBrush(RGB(232, 232, 23)));


	
	SelectObject(hdc, CreateSolidBrush(RGB(181, 207, 213)));
	Ellipse(hdc, 15, 650, 35, 630);
	Ellipse(hdc, 15, 350, 55, 320);
	Ellipse(hdc, 15, 100, 75, 50);

	Ellipse(hdc, 75, 450, 105, 420);

	Ellipse(hdc, 1180, 670, 1200, 650);
	Ellipse(hdc, 1180, 330, 1230, 300);
	Ellipse(hdc, 1180, 70, 1250, 20);

	Ellipse(hdc, 1300, 300, 1350, 270);
	
	SelectObject(hdc, CreateSolidBrush(RGB(121, 61, 0)));
	Ellipse(hdc, 50, 750, 20, 730);
	Ellipse(hdc, 150, 740, 130, 720);
	Ellipse(hdc, 160, 745, 130, 725);
	Ellipse(hdc, 200, 760, 180, 740);
	Ellipse(hdc, 270, 750, 240, 725);
	Ellipse(hdc, 270, 770, 240, 740);
	Ellipse(hdc, 350, 720, 320, 705);
	Ellipse(hdc, 420, 745, 400, 730);
	Ellipse(hdc, 500, 732, 520, 717);
	Ellipse(hdc, 510, 732, 530, 717);
	Ellipse(hdc, 650, 770, 630, 755);
	Ellipse(hdc, 750, 760, 770, 740);
	Ellipse(hdc, 790, 754, 775, 734);
	Ellipse(hdc, 900, 745, 920, 725);
	Ellipse(hdc, 980, 735, 960, 720);
	Ellipse(hdc, 1005, 750, 1025, 730);
	Ellipse(hdc, 1050, 755, 1070, 735);
	Ellipse(hdc, 1200, 740, 1222, 720);
	Ellipse(hdc, 1250, 760, 1270, 745);
	Ellipse(hdc, 1300, 755, 1280, 735);


	//fishes



	int x_right = 230;
	HBRUSH tilo_ryby_brush = CreateSolidBrush(RGB(143, 154, 152));
	HRGN tilo_ryby = CreateEllipticRgn(100, 150, x_right, 100);
	HBRUSH fishes_eye_brush = CreateSolidBrush(RGB(4, 4, 4));
	HRGN fishes_eye = CreateEllipticRgn(210, 125, 220, 115);
	FillRgn(hdc, tilo_ryby, tilo_ryby_brush);
	FillRgn(hdc, fishes_eye, fishes_eye_brush);

	SelectObject(hdc, CreateSolidBrush(RGB(143, 154, 152)));
	Ellipse(hdc, 1100, 200, 970, 150);
	SelectObject(hdc, CreateSolidBrush(RGB(4, 4, 4)));
	Ellipse(hdc, 990, 175, 980, 165);

	SelectObject(hdc, CreateSolidBrush(RGB(143, 154, 152)));
	Ellipse(hdc, 650, 400, 520, 350);
	SelectObject(hdc, CreateSolidBrush(RGB(4, 4, 4)));
	Ellipse(hdc, 540, 375, 530, 365);

	SelectObject(hdc, CreateSolidBrush(RGB(143, 154, 152)));
	Ellipse(hdc, 800, 600, 930, 550);
	SelectObject(hdc, CreateSolidBrush(RGB(4, 4, 4)));
	Ellipse(hdc, 910, 575, 920, 565);


	int y_verh = 85, y_nyz = 165, x_left = 70;
	HBRUSH hvish_brush = CreateSolidBrush(RGB(236, 16, 4));
	POINT hvist1[5] =
	{ { 100,120 } ,{ x_left,105 },{ 85,120 },{ x_left,135 },{ 100,130 } };
	HRGN hvist = CreatePolygonRgn(hvist1, 5, 1);
	FillRgn(hdc, hvist, hvish_brush);
	HBRUSH verh_plavn__brush = CreateSolidBrush(RGB(236, 16, 4));
	POINT verh_plavn1[4] =
	{ { 180,105 } ,{ 160,y_verh },{ 135,y_verh },{ 160,105 } };
	HRGN verh_plavn = CreatePolygonRgn(verh_plavn1, 4, 1);
	FillRgn(hdc, verh_plavn, verh_plavn__brush);
	HBRUSH nyz_plavn__brush = CreateSolidBrush(RGB(236, 16, 4));
	POINT nyz_plavn1[4] =
	{ { 170,145 } ,{ 150,y_nyz },{ 135,140 },{ 150,140 } };
	HRGN nyz_plavn = CreatePolygonRgn(nyz_plavn1, 4, 1);
	FillRgn(hdc, nyz_plavn, nyz_plavn__brush);


	SelectObject(hdc, CreatePen(PS_SOLID, 5, RGB(236, 16, 4)));
	POINT hvist2[5] =
	{ { 1100,170 } ,{ 1120,145 },{ 1105,175 },{ 1120,195 },{ 1100,180 } };
	Polyline(hdc, hvist2, 5);
	POINT verh_plavn2[4] =
	{ { 1040,155 } ,{ 1060,135 },{ 1070,135 },{ 1050,155 } };
	Polyline(hdc, verh_plavn2, 4);
	POINT nyz_plavn2[4] =
	{ { 1035,195 } ,{ 1045,215 },{ 1060,215 },{ 1045,195 } };
	Polyline(hdc, nyz_plavn2, 4);

	SelectObject(hdc, CreatePen(PS_SOLID, 5, RGB(236, 16, 4)));
	POINT hvist3[5] =
	{ { 645,375 } ,{ 675,355 },{ 660,370 },{ 675,385 },{ 645,380 } };
	Polyline(hdc, hvist3, 5);
	POINT verh_plavn3[4] =
	{ { 585,355 } ,{ 605,335 },{ 625,335 },{ 600,355 } };
	Polyline(hdc, verh_plavn3, 4);
	POINT nyz_plavn3[4] =
	{ { 580,395 } ,{ 600,415 },{ 610,400 },{ 590,395 } };
	Polyline(hdc, nyz_plavn3, 4);

	SelectObject(hdc, CreatePen(PS_SOLID, 5, RGB(236, 16, 4)));
	POINT hvist4[5] =
	{ { 805,570 } ,{ 765,550 },{ 785,570 },{ 765,590 },{ 805,580 } };
	Polyline(hdc, hvist4, 5);
	POINT verh_plavn4[4] =
	{ { 870,555 } ,{ 850,525 },{ 830,525 },{ 860,555 } };
	Polyline(hdc, verh_plavn4, 4);
	POINT nyz_plavn4[4] =
	{ { 860,595 } ,{ 840,615 },{ 820,615 },{ 850,595 } };
	Polyline(hdc, nyz_plavn4, 4);

	//âîäîðîñëè
	SelectObject(hdc, CreatePen(PS_SOLID, 10, RGB(35, 167, 20)));
	POINT ptRect[8] =
	{ { 1100,750 } ,{ 1115,700 },{ 1105,680 },{ 1110,650 },{ 1090,600 },{ 1105, 570 },{ 1110,540 },{ 1090, 500 } };
	Polyline(hdc, ptRect, 8);
	SelectObject(hdc, CreatePen(PS_SOLID, 10, RGB(35, 167, 20)));
	POINT ptRect2[10] =
	{ { 1300,750 } ,{ 1280,700 },{ 1315,680 },{ 1305,650 },{ 1300,600 },{ 1310, 570 },{ 1320,540 },{ 1315, 500 },{ 1325,400 },{ 1310,350 } };
	Polyline(hdc, ptRect2, 10);
	SelectObject(hdc, CreatePen(PS_SOLID, 6, RGB(35, 167, 20)));
	POINT ptRect3[11] =
	{ { 1230,750 } ,{ 1250,700 },{ 1245,680 },{ 1235,650 },{ 1250,600 },{ 1245, 570 },{ 1260,540 },{ 1250, 500 },{ 1235,400 },{ 1248,350 },{ 1230,250 } };
	Polyline(hdc, ptRect3, 11);
	SelectObject(hdc, CreatePen(PS_SOLID, 6, RGB(35, 167, 20)));
	POINT ptRect4[11] =
	{ { 100,750 } ,{ 120,700 },{ 111,680 },{ 105,650 },{ 117,600 },{ 134, 570 },{ 119,540 },{ 127, 500 },{ 114,400 },{ 124,350 },{ 103,250 } };
	Polyline(hdc, ptRect4, 11);
	SelectObject(hdc, CreatePen(PS_SOLID, 4, RGB(82, 252, 99)));
	POINT ptRect5[12] =
	{ { 50,750 } ,{ 57,700 },{ 45,680 },{ 55,650 },{ 64,600 },{ 54, 570 },{ 43,540 },{ 31, 500 },{ 49,400 },{ 62,350 },{ 57,250 },{ 50,150 } };
	Polyline(hdc, ptRect5, 12);
	SelectObject(hdc, CreatePen(PS_SOLID, 10, RGB(0, 234, 0)));
	POINT ptRect6[5] =
	{ { 150,747 } ,{ 144,723 },{ 160,670 },{ 154,630 },{ 163,580 } };
	Polyline(hdc, ptRect6, 5);


	//ëåñêà è êðþ÷åê
	SelectObject(hdc, CreatePen(PS_SOLID, 1, RGB(212, 212, 212)));
	POINT leska[2] =
	{ { 590,0 },{ 590,300 } };
	Polyline(hdc, leska, 2);
	SelectObject(hdc, CreatePen(PS_SOLID, 3, RGB(120, 120, 120)));
	POINT gak[6] =
	{ { 590,300 },{ 590,330 },{ 585,330 },{ 582,328 },{ 581,325 },{ 582,320 } };
	Polyline(hdc, gak, 6);
	SelectObject(hdc, CreatePen(PS_SOLID, 6, RGB(238, 81, 215)));
	POINT worm[7] =
	{ { 590,330 },{ 585,330 },{ 582,328 },{ 581,325 },{ 582,320 },{ 578,325 },{ 580,327 } };
	Polyline(hdc, worm, 7);





	//int x1 = 50, y1 = 50, r1 = 40; 
	//HBRUSH ballBrush1 = CreateSolidBrush(RGB(200, 250, 34));
	//HRGN rgnBall1 = CreateEllipticRgn(x1 - r1, y1 - r1, x1 + r1, y1 + r1);
	//FillRgn(hdc, rgnBall1, ballBrush1);
	int iKey = 67;
	while (iKey != 27) // Âûõîä ïî êëàâèøå ESC
	{
		if (_kbhit())
		{
			iKey = _getch();
			switch (iKey)
			{
			case KEY_ARROW_UP:
				if (y_verh > 0)
				{
					y_verh -= 10;
					y_nyz -= 10;
					All_My_Life();
					drawFish(hdc, tilo_ryby, fishes_eye, hvist, verh_plavn, nyz_plavn, tilo_ryby_brush, fishes_eye_brush,
						hvish_brush, verh_plavn__brush, nyz_plavn__brush, bkBrush, 0, -10);

				}
				break;
			case KEY_ARROW_RIGHT:
				if (x_right < 1349)
				{
					x_right += 10;
					x_left += 10;
					All_My_Life();
					drawFish(hdc, tilo_ryby, fishes_eye, hvist, verh_plavn, nyz_plavn, tilo_ryby_brush, fishes_eye_brush,
						hvish_brush, verh_plavn__brush, nyz_plavn__brush, bkBrush, 10, 0);

				}
				break;
			case KEY_ARROW_DOWN:
				if (y_nyz < 690)
				{
					y_nyz += 10;
					y_verh += 10;
					All_My_Life();
					drawFish(hdc, tilo_ryby, fishes_eye, hvist, verh_plavn, nyz_plavn, tilo_ryby_brush, fishes_eye_brush,
						hvish_brush, verh_plavn__brush, nyz_plavn__brush, bkBrush, 0, 10);

				}
				break;
			case KEY_ARROW_LEFT:
				if (x_left > 0)
				{
					x_left -= 10;
					x_right -= 10;
					All_My_Life();
					drawFish(hdc, tilo_ryby, fishes_eye, hvist, verh_plavn, nyz_plavn, tilo_ryby_brush, fishes_eye_brush,
						hvish_brush, verh_plavn__brush, nyz_plavn__brush, bkBrush, -10, 0);

				}
				break;
			}
		}
	}
}

void Do() {
	main_psevdographic();
}
//--------------------------------------------------------------------------------------------------------------------------------------


void Exit(void)
{
	//fflush(stdin);
	int resp;
	cout << "Âû óâåðåíû, ÷òî õîòèòå âûéòè èç ïðîãðàììû? (y/n)?";
	resp = getchar();
	if (resp == 'y' || resp == 'Y') { cls(1); exit(0); }
}

