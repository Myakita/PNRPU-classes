#include <iostream>
#include <string>
using namespace std;

class Object {
public:
    Object() {}
    virtual void show() = 0;
    virtual void input() = 0;
    virtual string getname() = 0;
    virtual ~Object() {}
};

class Person : public Object {
public:
    Person() : name("noname"), age(0) {}
    Person(string n, int a) : name(n), age(a) {}
    Person(const Person& p) : name(p.name), age(p.age) {}
    ~Person() {}

    int getage() { return age; }
    string getname() override { return name; }
    void setage(int a) { age = a; }
    void setname(string n) { name = n; }

    void show() override {
        cout << "Возраст: " << age << endl;
        cout << "Имя: " << name << endl;
    }
    void input() override {
        cout << "Введите возраст: ";
        cin >> age;
        cout << endl;
        cout << "Введите имя: ";
        cin >> name;
        cout << endl;
    }

private:
    string name;
    int age;
};

class Student : public Person {
public:
    Student() : Person(), reiting(0) {}
    Student(string name,int age, float r) : Person(name, age), reiting(r) {}
    Student(const Student& s) : Person(s), reiting(s.reiting) {}
    ~Student() {}

    void setreit(float r) { reiting = r; }
    float getreit() { return reiting; }

    void show() override {
        Person::show();
        cout << "Рейтинг данного студента: " << reiting << endl;
    }
    void input() override {
        Person::input();
        cout << "Введите рейтинг студента: ";
        cin >> reiting;
        cout << endl;
    }

private:
    float reiting;
};

class Vector {
public:
    Vector(int s) : size(s), cur(0) {
        beg = new Object * [size];
    }

    ~Vector() {
        for (int i = 0; i < cur; ++i) {
            delete beg[i];
        }
        delete[] beg;
    }
    Object*& operator[](int index) {
        if (index >= 0 && index < cur) {
            return beg[index];
        }
        else {
            static Object* null_ptr = nullptr;
            return null_ptr;
        }
    }

    void add() {
        if (cur < size) {
            cout << "1. Student" << endl;
            int x;
            cin >> x;
            if (x == 1) {
                Student* s = new Student;
                s->input();
                beg[cur] = s;
                cur++;
                
            }
            else {
                cout << "Неизвестная операция" << endl;
            }
        }
        else {
            cout << "Массив переполнен" << endl;
        }
    }

    void del() {
        if (cur == 0)
        {
            cout << "Пусто"<< endl;
        }
        else
        {
            delete beg[cur-1];
            cur--;
        }
    }

    void show() {
        if (cur == 0) {
            cout << "Пусто" << endl;
        }
        else {
            for (int i = 0; i < cur; ++i) {
                beg[i]->show();
            }
        }
    }

    int operator()() { return cur; }

private:
    Object** beg;
    int size;
    int cur;
};

const int evnothing = 0;
const int evmessage = 100;
const int cmadd = 1;
const int cmdel = 2;
const int cmshow = 3;
const int cmshowelem = 4;
const int cmmake = 6;
const int cmquit = 101;

struct Tevent {
    int what;
    int command;
};

class Dialog {
public:
    Dialog() : EndState(0) {}

    void getevent(Tevent& event) {
        string OpInt = "m+-s?q";
        string s;
        char code;
        cout << '>';
        cin >> s;
        code = s[0];
        if (OpInt.find(code) != string::npos) {
            event.what = evmessage;
            switch (code) {
            case 'm': event.command = cmmake; break;
            case '+': event.command = cmadd; break;
            case '-': event.command = cmdel; break;
            case 's': event.command = cmshow; break;
            case '?': event.command = cmshowelem; break;
            case 'q': event.command = cmquit; break;
            }
        }
        else {
            event.what = evnothing;
        }
    }

    void execute() {
        Tevent event;
        do {
            EndState = 0;
            getevent(event);
            handleevent(event);
        } while (valid());
    }

    void handleevent(Tevent& event) {
        int num;
        if (event.what == evmessage) {
            switch (event.command) {
            case cmmake:
                cout << "Введите размер массива: ";
                cin >> size;
                vec = new Vector(size);
                clearevent(event);
                break;
            case cmadd:
                vec->add();
                clearevent(event);
                break;
            case cmdel:
                vec->del();
                cout << "Очищен последний студент" << endl;
                clearevent(event);
                break;
            case cmshow:
                vec->show();
                clearevent(event);
                break;
            case cmshowelem:
                cout << "Введите номер элемента: ";
                cin >> num;
                num--;
                if (num >= 0 && num < (*vec)()) {
                    ((*vec)[num])->show();
                }
                else {
                    cout << "Неверный номер элемента" << endl;
                }
                clearevent(event);
                break;
            case cmquit:
                endexec();
                break;
            default:
                cout << "Неизвестная команда" << endl;
                break;
            }
        }
    }

    void clearevent(Tevent& event) { event.what = evnothing; }

    bool valid() { return EndState == 0; }

    void endexec() { EndState = 1; }

    ~Dialog() { delete vec; }

private:
    int EndState;
    int size;
    Vector* vec;
};

int main() {
    setlocale(0, "");
    system("chcp 1251>nul");
    cout << "m: Создать группу\n+: Добавить элемент\n";
    cout << "-: Удалить элемент\ns: Информация о членах группы\n";
    cout << "?: Информация об элементе группы(? - номер)\nq: Выход\n";
    Dialog D;
    D.execute();
    return 0;
}