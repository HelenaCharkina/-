#include <iostream>
#include <vector>
#include <string>

using namespace std;

// Программа для вычитания больших чисел
int main()
{
	int numberSystem = 10;
	int balance = 0;
	vector <int> vector1;
	vector <int> vector2;
	vector <int> vectorAnswer;

	// Вводим первое число
	string s = "";
	cout << "write vector 1! " << endl;
	cin >> s;
	for (int i = 0; i < s.size(); i++)
		if (isdigit(s[i]))
			vector1.push_back(s[i] - '0');
		else {
			cout << "invalid format!!";
			system("pause");
			return 0;
		}
	// Вводим второе число
	s = "";
	cout << "write vector 2! " << endl;
	cin >> s;
	for (int i = 0; i < s.size(); i++)
		if (isdigit(s[i]))
			vector2.push_back(s[i] - '0');
		else {
			cout << "invalid format!!";
			system("pause");
			return 0;
		}
	reverse(vector1.begin(), vector1.end());
	reverse(vector2.begin(), vector2.end());

	// Добавляем незначащие нули
	while (vector1.size() < vector2.size())
		vector1.push_back(0);
	while (vector2.size() < vector1.size())
		vector2.push_back(0);

	// Алгоритм вычитания
	for (int j = 0; j < vector2.size(); j++)
	{
		vectorAnswer.push_back((vector1[j] - vector2[j] + balance + numberSystem) % numberSystem);
		balance = floor((vector1[j] - vector2[j] + balance) / (numberSystem + 0.0));
	}

	if (balance != 0) {
		cout << "!ERROR!" << endl;
		system("pause");
		return 0;
	}

	// Удаляем незначащие нули
	int l = vectorAnswer.size() - 1;
	bool flag = true;
	while (flag && vectorAnswer[l] == 0 && l > 0)
	{
		vectorAnswer[l] = -1;
		l--;
		if (vectorAnswer[l] != 0)
			flag = false;
	}
	// Выводим результат
	cout << "answer = ";
	for (int i = vectorAnswer.size() - 1; i >= 0; i--)
		if (vectorAnswer[i] != -1)
			cout << vectorAnswer[i];
	cout << endl;
	system("pause");

}