// Лабораторная работа 11.3 стеки.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;


struct Stack {
	char data;
	Stack* prev;
};

Stack* made_stack(int n) {
	char a;
	if (n == 0) {
		return NULL;
	}
	else {
		Stack* top = NULL;
		Stack* p;
		cin >> a;
		p = new Stack;
		p->data = a;
		p->prev = NULL;
		top = p;
		for (int i = 2; i <= n; i++) {
			Stack* h = new Stack;
			cin >> a;
			h->data = a;
			h->prev = top;
			top = h;
		}
		return top;
	}
}
Stack* push(Stack*& top, char val) {
    Stack* p = new Stack;
    p->data = val;
    p->prev = nullptr;

    if (top == nullptr) {
        top = p;
    }
    else {
        Stack* current = top;
        while (current->prev != nullptr) {
            current = current->prev;
        }
        current->prev = p;
    }

    return top;
}

void print_stack(Stack* top) {
    if (top == nullptr) {
        cout << "Стек пуст." << endl;
    }
    else {
        Stack* p = top;
        cout << "Стек: ";
        while (p != nullptr) {
            cout << p->data << " ";
            p = p->prev;
        }
        cout << endl;
    }
}

char pop(Stack*& top) {
    if (top == nullptr) {
        cerr << "Стек пуст, невозможно выполнить операцию pop." << endl;
        return;
    }

    Stack* p = top;
    char data = p->data;
    top = top->prev;
    delete p;
    return data;
}

int main() {
    setlocale(0, "");
    system("chcp 1251");
    system("cls");
    cout << "кол-во элементов: ";
    int n;
    char a;
    cin >> n;
    cout << "Введите элементы стека: ";
    Stack* st = made_stack(n);
    print_stack(st);
    char b;
    cout << "Введите ключ для удаления: ";
    cin >> b;
    int k = 0;
    Stack* st2 = nullptr;
    for (int i = 0; i < n; i++) {
        char t = pop(st);
        if (t != b) {
            push(st2, t);
        }
        else {
            k++;
        }
    }
    n = n - k;
    while (st2 != nullptr) {
        char t = pop(st2);
        push(st, t);
    }
    cout << "Стек после изменений: ";
    print_stack(st);
    k = 0;
    cout << "Введите кол-во элементов для добавления: ";
    cin >> k;
    int s = 0;
    cout << "Введите номер элемента, перед которым добавляют элементы: ";
    cin >> s;
    for (int i = 0; i < n - s + 1; i++) {
        char t = pop(st2);
        push(st2, t);
    }
    cout << "Введите элементы: ";
    for (int i = 0; i < k; i++) {
        cin >> a;
        push(st, a);
    }
    for (int i = 0; i < n - s + 1; i++) {
        char t = pop(st2);
        push(st, t);
    }
    print_stack(st);
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
