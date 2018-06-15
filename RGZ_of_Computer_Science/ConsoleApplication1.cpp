// ConsoleApplication1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <conio.h>
#include <math.h>

using namespace std;

union Bits{
	float u;
	unsigned int u1;
};
/*Выделение характеристика числа*/
unsigned int CHARACTERISTIC_NUMBER(unsigned int u) {
	u = u << 1;
	u = u >> 1;
	u = u >> 23;
	return u;
}
/*Мантиссы числа*/
unsigned int MANTISSA_NUMBER(unsigned int u) {
	u = u << 9;
	u = u >> 9;
	u = u | 8388608;
	return u;
}
/*Знак числа*/
unsigned int SIGN_NUMBER(unsigned int u) {
	u = u >> 31;
	return u;
}
/*Перевод характеристки числа*/
void PEREVOD_CHARACTERISTIC_NUMBER(unsigned x) {
	int i; 	
	for (i = 7; i >= 0; i--) printf("%d", (x>>i)&1);
}
/*Перевод мантиссы числа*/
void PEREVOD_MANTISSA_NUMBER(unsigned x) {
	int i;
	for (i = 23; i >= 0; i--) printf("%d", (x>>i)&1);
}
/*Выделение целой части*/
unsigned int WHOLE_PART_NUMBER(unsigned long long u, int c) {
	unsigned long long z = 23 - c;
	u >>= z;
	return u;
}
/*Дробная часть*/ 
unsigned int FRACTION_NUMBER(unsigned long long int u, int c) {
	unsigned long long int b = 41 + c;
	u = u << b;
	u = u >> b;
	return u;
}
/*Перевод в десятичную систему счисления*/
void PEREVOD_DESYAT(unsigned long long u, int p)
{
	unsigned long long b = u;

	b >>= 23 - p;
	u <<= 41 + p;
	u >>= 41 + p;
	printf("%d.", b);
	while (u != 0) {
		u = u * 10;
		unsigned long long a = u;
		a >>= 23 - p;
		printf("%d", a);
		u <<= 41 + p;
		u >>= 41 + p;

	}
}
void PEREVOD(unsigned int u) {
	int i;
	for (i = 31; i >= 0; i--) printf("%d", (u >> i) & 1);
}
void PEREVOD1(unsigned int u, int t) {
	int i;
	t > 0 ? t : t*(-1);
	for (i = 23 - t; i >= 0; i--) printf("%d", (u >> i) & 1);
}
int main()
{
	float n;
	long long int r;
	printf("Vvedite chislo: ");
	scanf("%f", &n);
	Bits a;
	a.u = n;
	unsigned int s = SIGN_NUMBER(a.u1);// знак 
	unsigned int c = CHARACTERISTIC_NUMBER(a.u1);// характеристика 
	float m = MANTISSA_NUMBER(a.u1);// мантисса 
	int p = c - 127;// двоичный порядок
	printf("%d", s);
	PEREVOD_CHARACTERISTIC_NUMBER(c);
	PEREVOD_MANTISSA_NUMBER(m);
	printf("\n");
    printf("Znak - %d\n", s);
	printf("Characteristica - ");
    PEREVOD_CHARACTERISTIC_NUMBER(c); // перевод в двоичную систему счисления характеристики числа
	printf("\n");
	printf("Mantissa - ");
	PEREVOD_MANTISSA_NUMBER(m);// перевод в двоичную систему счисления мантиссы числа
	printf("\n");
	printf("Dvoichnyi poryadok - %d\n", p);// двоичный порядок числа
	printf("Celaya chast - ");
	PEREVOD( WHOLE_PART_NUMBER(m, p));// выделение целой части
	printf("\n");
	printf("Drobranya chast - ");
	PEREVOD1(FRACTION_NUMBER(m, p),p);// выделintение дробной части 
	printf("\n");
	PEREVOD_DESYAT(m, p);// перевод в десятичную систему счисления
	printf("\n");
	return 0;
}

