// Лабораторная работа 11.4.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;
int n;
char key;

template <typename T>
struct Node 
{
    T data;
    Node<T>* next;
};

template <typename T>
struct Queue 
{
    int size;
    Node<T>* head;
    Node<T>* tail;
};

template <typename T>
void new_queue(Queue<T>& q, int n) 
{
    T a;
    cout << "Введите элемент: ";
    cin >> a;
    init_queue(q, a);
    for (int i = 2; i <= n; i++)
    {
        cout << "Введите элемент: ";
        cin >> a;
        push(q, a);
    }
}
template <typename T>
void init_queue(Queue<T>& q, const T& value) 
{
    Node<T>* ptr = new Node<T>();
    ptr->data = value;
    q.head = ptr;
    q.tail = ptr;
    q.size = 1;
}

template <typename T>
void push(Queue<T>& q, const T& value) 
{
    Node<T>* ptr = new Node<T>();
    q.size++;
    ptr->data = value;
    ptr->next = nullptr;
    q.tail->next = ptr;
    q.tail = ptr;
}

template <typename T>
void print_queue(Queue<T>& q) 
{
    Node<T>* tmp = q.head;
    cout << "Начало -> ";
    while (tmp != nullptr)
    {
        cout << tmp->data << " -> ";
        tmp = tmp->next;
    }
    cout << "Конец" << endl;
}

template <typename T>
void pop(Queue<T>& q) 
{
    Node<T>* tmp = q.head;
    q.head = q.head->next;
    q.size--;
    delete tmp;
}

template <typename T>
void delete_key(Queue<T>& q, T k) 
{
    int i = 1;
    while (i <=q.size)
    {
        if (q.head->data == k)
        {
            pop(q);
        }
        else
        {
            push(q, q.head->data);
            pop(q);
            i++;
        }
    }
}

template <typename T>
void insert(Queue<T>& q, int count, int number) 
{
    int i = 1;
    while (i < number)
    {
        push(q, q.head->data);
        pop(q);
        i++;
    }
    T a;
    for (int j = 0; j <+ count; j++)
    {
        cout << "ВВедите элемент для добавления: ";
        cin >> a;
        push(q, a);
    }
    for (i; i <+ q.size; i++)
    {
        push(q, q.head->data);
        pop(q);
    }
}

template <typename T>
void delete_queue(Queue<T>& q) 
{
    while (q.head->next != nullptr)
    {
        pop(q);
    }
    Node<T>* tmp = q.head;
    q.head = nullptr;
    q.size--;
    delete tmp;
}


int main()
{
    setlocale(0, "");
    Queue<char> q;
    do
    {
        cout << "Введите кол-во элементов в очереди: ";
        cin >> n;
    } while (n <= 0);

    new_queue(q, n);
    cout << endl;
    print_queue(q);

    cout << endl << "Введите ключ элемента для удаления: ";
    cin >> key;
    delete_key(q, key);
    cout << endl;
    print_queue(q);

    int num;
    do
    {
        cout << endl << "Введите номер элемента, перед которым нужно вставить элемент: ";
        cin >> num;
    } while (num <= 0 || num > q.size);

    cout << endl << "Введите кол-во элементов для добавления: ";
    int count;
    cin >> count;

    insert(q, count, num);
    cout << endl;
    print_queue(q);

    delete_queue(q);
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
