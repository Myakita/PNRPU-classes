// Лабораторная работа 11.1 Списки.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <fstream>
#include <iostream>
#include <string>

using namespace std;

struct Node
{
    char* key = new char[1];
    Node* prev_node_ptr = nullptr;
    Node* next_node_ptr = nullptr;
};

struct List
{
    Node* head_node = nullptr;
    Node* tail_node = nullptr;
    int size = 0;
};

void deletekey(List& list, char key)
{
    if (list.head_node == nullptr)
    {
        cout << "Лист пуст" << endl;
        return;
    }
    Node* remove_node = list.head_node;
    while ((remove_node != nullptr) && (*(remove_node->key) != key))
    {
        remove_node = remove_node->next_node_ptr;
    }
    if (remove_node == nullptr)
    {
        cout << "Нет такого ключа" << endl;
        return;
    }
    if (list.head_node == remove_node)
    {
        list.head_node = remove_node->next_node_ptr;
    }
    if (list.tail_node == remove_node)
    {
        list.tail_node = remove_node->prev_node_ptr;
    }
    if (remove_node->prev_node_ptr != nullptr)
    {
        remove_node->prev_node_ptr->next_node_ptr = remove_node->next_node_ptr;
    }
    if (remove_node->next_node_ptr != nullptr)
    {
        remove_node->next_node_ptr->prev_node_ptr = remove_node->prev_node_ptr;
    }
    delete remove_node;
    list.size--; // Уменьшаем размер списка после удаления элемента
}

void add_node(List& list, int index, char str)
{
    Node* new_node = new Node;
    *(new_node->key) = str;

    list.size++;

    if (list.head_node == nullptr)
    {
        list.head_node = new_node;
        list.tail_node = new_node;
        return;
    }
    if ((index == -1) || (index == 0))
    {
        new_node->next_node_ptr = list.head_node;
        list.head_node->prev_node_ptr = new_node;
        list.head_node = new_node;
        return;
    }
    if (index >= list.size - 1)
    {
        new_node->prev_node_ptr = list.tail_node;
        list.tail_node->next_node_ptr = new_node;
        list.tail_node = new_node;
        return;
    }
    int counter = 0;
    int from_tail = list.size - 2 - index;
    Node* current_node;

    if (index < from_tail)
    {
        current_node = list.head_node;
        while (counter != index)
        {
            current_node = current_node->next_node_ptr;
            ++counter;
        }
    }
    else
    {
        current_node = list.tail_node;
        while (counter != from_tail)
        {
            current_node = current_node->prev_node_ptr;
            ++counter;
        }
    }
    new_node->next_node_ptr = current_node->next_node_ptr;
    new_node->prev_node_ptr = current_node;
    current_node->next_node_ptr->prev_node_ptr = new_node;
    current_node->next_node_ptr = new_node;

}

void print_list(List& list)
{
    Node* current_node = list.head_node;

    if (current_node == nullptr)
    {
        cout << "Лист пуст" << endl;
        return;
    }
    cout << "[";
    while (current_node != nullptr)
    {
        cout << *(current_node->key) << ", ";
        current_node = current_node->next_node_ptr;
    }
    cout << "\b \b\b \b]" << endl;

    // Удаление указателя current_node не нужно здесь
}
void list_filesave(List& list)
{
    Node* current_node = list.head_node;
    ofstream f("list_filesave.dat");

    while (current_node != nullptr)
    {
        f << current_node->key << '\n';
        current_node = current_node->prev_node_ptr;
    }
    f.close();
}

void list_fileread(List& list)
{
    char buffer_char[1];
    string buffer_str;

    ifstream f("list_savestate.dat");

    while (!f.eof())
    {
        getline(f, buffer_str);
        buffer_char[0] = buffer_str[0];
        if (buffer_str != "")
        {
            add_node(list, -1, buffer_str[0]);
        }
    }
    f.close();
}

void list_del(List& list)
{
    Node* remove_node;

    while ((list).head_node != nullptr)
    {
        remove_node = (list).head_node;
        (list).head_node = (list).head_node->next_node_ptr;
        delete remove_node;
    }
}


int main()
{
    setlocale(0, "");
    system("chcp 1251");
    system("cls");
    int n, k;
    string str;
    char ch;
    List list;

    cout << "Сколько элементов: ";
    cin >> n;
    cin.ignore();

    for (int i = 1; i <= n; ++i)
    {
        cout << "Введите элемент: ";
        cin >> ch;
        add_node(list, i, ch);
    }
    print_list(list);
   
    cout << "Введите ключ для удаления: ";
    while (!(cin >> ch)) {
        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
    }
    deletekey(list, ch);
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

    cout << "Лист созранен в файл" << endl;
    list_filesave(list);
    list_del(list);
    print_list(list);

    cout << "лист выгружен из файла" << endl;
    list_fileread(list);
    print_list(list);

    list_del(list);

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
