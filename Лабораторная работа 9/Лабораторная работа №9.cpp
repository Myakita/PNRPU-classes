#include <iostream>
#include <fstream>
#include <string>

using namespace std;

string writefl(ofstream& file) 
{
    string str;
    int n;
    cout << "Введите кол-во строк:";
    cin >> n;
    for (int i = 0; i < n+1; i++)
    {
        getline(cin, str);
        file << str;
        file << '\n';
    }
    file.close();
    return str;
}

int main() {
    setlocale(0, "");
    system("chcp 1251");
    system("cls");
    ofstream file1("F1.txt");
    ifstream fin("F1.txt");
    ofstream fout("F2.txt");
    int n1, n2;
    int a, b, c;
    int k;

    writefl(file1);
    cout << "Введите с какой по какую строку смортеть результат:";
    cout << endl;
    cin >> n1 >> n2;
    if (!fin.is_open() || !fout.is_open()) 
    {
        cout << "Ошибка открытия файлов!" << endl;
    }

    string str;


    for (int i = 1; i < n1; i++)
    {
        getline(fin, str);
    }
    for (int i = n1; i <= n2; i++)
    {
        getline(fin, str);
        a = str.find("а");
        b = str.find_last_of("с");
        c = str.size();
        if (str.find("а") == 0 && str.find_last_of("с") == str.size()-1)
        {
            fout << str << endl;
        }
    }
    fin.close();
    fout.close();
    ifstream file2("F2.txt");
    getline(file2, str);
    for (int i = 0; i < str.length(); i++)
    {
        if (str[i] == ' ')
        {
            k++;
        }
    }
    cout << k;
    file2.close();
    return 0;
}