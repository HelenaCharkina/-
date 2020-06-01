// diff.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include <iostream>
#include <vector>
#include <string>

using namespace std;

int b = 10, k = 0, i = 0, j = 0;
vector <int> v1;
vector <int> v2;
vector <int> w(0);
int number_system = 10;
int b;

int main()
{

	
	string s = "";
	cout << "vector 1: " << endl;
	cin >> s;
	for (int i = 0; i < s.size(); i++)
		if (isdigit(s[i]))
			v1.push_back(s[i] - '0');
		else {
			cout << "invalid number format!!" << endl;
			return 0;
		}


	s = "";
	cout << "vector 2: " << endl;
	cin >> s;
	for (int i = 0; i < s.size(); i++)
		if (isdigit(s[i]))
			v2.push_back(s[i] - '0');
		else {
			cout << "invalid number format!!" << endl;
			return 0;
		}

	reverse(v1.begin(), v1.end());
	reverse(v2.begin(), v2.end());


	while (v1.size() < v2.size())
		v1.push_back(0);
	while (v2.size() < v1.size())
		v2.push_back(0);

	while (i) {
		i++;
		if (i < m) step4();
		else w[j + m] = k;
	}

	






	int l = w.size() - 1; bool flag = true;
	while (flag && w[l] == 0 && l > 0)
	{
		w[l] = -1;
		l--;
		if (w[l] != 0)
			flag = false;
	}
	cout << "ANSWER: ";
	for (int i = w.size() - 1; i >= 0; i--)
		if (w[i] != -1)
			cout << w[i];
	cout << endl;
}

void step4() {
	int t = v1[i] * v2[j] + w[i + j] + k;
	w[i + j] = t % b;
	k = t / b;
}