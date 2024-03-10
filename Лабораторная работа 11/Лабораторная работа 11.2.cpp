// Лабораторная работа 11.2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <string>

using namespace std;

struct Node
{
    char* key;
    Node* next;
};

struct List
{
    Node* head;
    Node* tail;
    int size;
};

void pop_front(List& list)
{
    if (list.head == nullptr)
    {
        return;
    }

    Node* ptr = list.head;
    list.head = list.head->next;
    delete ptr;
    list.size--;
}

void pop_back(List& list)
{
    if (list.tail == nullptr)
    {
        return;
    }

    if (list.head == list.tail)
    {
        delete list.head;
        list.head = list.tail = nullptr;
        list.size = 0;
        return;
    }

    Node* ptr = list.head;
    while (ptr->next != list.tail)
        ptr = ptr->next;
    delete list.tail;
    ptr->next = nullptr;
    list.tail = ptr;
    list.size--;
}

Node* getAt(List& list, int index)
{
    if (index < 0 || index >= list.size)
    {
        return nullptr;
    }

    Node* ptr = list.head;
    int n = 0;
    while (ptr && index != n)
    {
        ptr = ptr->next;
        n++;
    }
    return ptr;
}

void add_node(List& list, int index, char data)
{
    if (index < 0 || index > list.size)
    {
        return;
    }

    Node* left = getAt(list, index - 1);
    Node* right = (left == nullptr) ? list.head : left->next;

    Node* ptr = new Node;
    ptr->key = new char[2];
    ptr->key[0] = data;
    ptr->key[1] = '\0';

    if (left == nullptr)
    {
        list.head = ptr;
    }
    else
    {
        left->next = ptr;
    }

    ptr->next = right;
    if (right == nullptr)
    {
        list.tail = ptr;
    }

    list.size++;
}

void delete_key(List& list, int index)
{
    if (index < 0 || index >= list.size)
    {
        return;
    }

    if (index == 0)
    {
        pop_front(list);
        return;
    }

    Node* left = getAt(list, index - 1);
    if (left == nullptr || left->next == nullptr)
    {
        return;
    }

    Node* ptr = left->next;
    left->next = ptr->next;
    if (ptr == list.tail)
    {
        list.tail = left;
    }
    delete ptr;
    list.size--;
}

void print_list(List& list)
{
    Node* ptr = list.head;

    if (ptr == nullptr)
    {
        cout << "Лист пуст" << endl;
        return;
    }
    cout << "[";
    while (ptr != nullptr)
    {
        cout << ptr->key[0] << ", ";
        ptr = ptr->next;
    }
    cout << "\b \b\b \b]" << endl;
}

int main()
{
    setlocale(0, "");
    system("chcp 1251");
    system("cls");
    int k;
    string str;
    List list = { nullptr, nullptr, 0 };
    int n;
    char ch;

    cout << "Сколько элементов: ";
    cin >> n;
    for (int i = 0; i < n; ++i)
    {
        cout << "Введите элемент: ";
        cin >> ch;
        add_node(list, i, ch);
    }
    print_list(list);

    cout << "Введите индекс для удаления: ";
    cin >> n;
    delete_key(list, n);
    print_list(list);

    cout << " индекс и кол-во(К) элементов для добавления: ";
    cin >> n >> k;
    cin.ignore();

    for (int i = 0; i <= k - 1; ++i)
    {
        cout << "Введите элемент: ";
        getline(cin, str);
        ch = str[0];
        add_node(list, i, ch);
    }
    print_list(list);

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
