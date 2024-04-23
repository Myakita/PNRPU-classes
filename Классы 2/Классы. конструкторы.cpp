// Классы. конструкторы.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include<iostream>
#include<string>
using namespace std;

class automobil {
private:
	string Marka;
	string Model;
	int price;

public:
	automobil() {
		Marka = "noname";
		Model = "noname";
		price = 0;
		cout << "Вызовконструктораспараметрами: " << this->Marka << " " << this->Model << " " << this->price << endl;
	}
	automobil(string Marka, string Model, int price) {
		this->Marka = Marka;
		this->Model = Model;
		this->price = price;
		cout << "Вызовконструктораспараметрами: " << this->Marka << " " << this->Model << " "<< this->price << endl;
	}
	automobil(const automobil& d) {
		Marka = d.Marka;
		Model = d.Model;
		price = d.price;
		cout << "Вызовконструктораспараметрами: "<< this->Marka << " " << this->Model << " " << this->price << endl;
	}
	void SetMARKA(string name) {
		Marka = name;
	}
	void SetMODEL(string model) {
		Model = model;
	}
	void SetPRICE(double price) {
		price = price;
	}
	string GetMARKA() {
		return Marka;
	}
	string GetMODEL() {
		return Model;
	}
	int GetPRICE() {
		return price;
	}

	void Print() {
		cout << "Марка: " << Marka << endl << "Модель: " << Model << endl << "Стоимость: " << price << endl;
	}
	~automobil() {
		cout << "Удаление коснтруктора" << endl;
	}

};


int main() {
	system("chcp 1251>NULL");
	automobil h1;
	automobil h2("Молодых Никита Андреевич", "Бог", 77);
	automobil h3(h2);
	automobil h4;
	h4.SetMARKA("Сингур Иван Сергеевич");
	h4.SetMODEL("Чушпан");
	h4.SetPRICE(48);
	cout << endl;
	cout << "Марка: " << h4.GetMARKA() << endl;
	cout << "Модель: " << h4.GetMODEL() << endl;
	cout << "Стоимость: " << h4.GetPRICE() << endl;
	cout << endl;
	//h4.Print();
	cout << endl;
	return 0;

}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
