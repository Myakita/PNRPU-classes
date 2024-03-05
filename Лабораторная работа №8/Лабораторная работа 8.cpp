// Лабораторная работа 8.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <fstream>
#include <string>

using namespace std;

struct VehicleOwner
{
    string FIO;
    string Nomer;
    string num;
};

VehicleOwner writeown()
{
    VehicleOwner e;
    cout << "ФИО: ";
    getline(cin, e.FIO);
    cout << "Гос номер транспорта: ";
    getline(cin, e.Nomer);
    cout << "Телефон: ";
    getline(cin, e.num);
    return e;
}

int main()
{
    setlocale(0, "");
    system("chcp 1251");
    system("cls");
    int n;
    cout << "Количество владельцев авто: ";
    cin >> n;
    cin.ignore();

    // Запись в файл
    ofstream file1("f.txt");
    for (int i = 0; i < n; i++)
    {
        VehicleOwner owner = writeown();
        file1 << owner.FIO << "\n" << owner.Nomer << "\n" << owner.num << "\n";
    }
    file1.close();

    // Удаление элемента с заданным номером
    ifstream infile("f.txt");
    ofstream outfile("f2.txt");
    string del;
    cout << "Какой гос.номер удалить?: ";
    getline(cin, del);
    string line;
    bool deleted = false;
    while (getline(infile, line))
    {
        if (line == del)
        {
            for (int i = 0; i < 2; ++i) // Пропустить следующие две строки, т.к. они тоже связаны с удаляемым элементом
                getline(infile, line);
            deleted = true;
        }
        else
        {
            outfile << line << "\n";
        }
    }
    infile.close();
    outfile.close();
    if (!deleted)
        cout << "Гос.номер не найден.\n";

    // Добавление двух элементов перед элементом с заданной фамилией
    ifstream infile2("f2.txt");
    ofstream outfile2("f3.txt");
    string fam;
    cout << "Введите фамилию перед которой добавить два элемента: ";
    getline(cin, fam);
    while (getline(infile2, line))
    {
        if (line.find(fam) != string::npos) // Если нашли фамилию
        {
            VehicleOwner owner1 = writeown();
            outfile2 << owner1.FIO << "\n" << owner1.Nomer << "\n" << owner1.num << "\n";

            VehicleOwner owner2 = writeown();
            outfile2 << owner2.FIO << "\n" << owner2.Nomer << "\n" << owner2.num << "\n";
        }
        outfile2 << line << "\n";
    }
    infile2.close();
    outfile2.close();

    // Переименование файла
    remove("f.txt");
    rename("f3.txt", "f.txt");

    return 0;
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
