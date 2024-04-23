#include <iostream>
using namespace std;

class triad
{
public:
    triad() : first(0), second(0), third(0) {}
    triad(int f, int s, int t) : first(f), second(s), third(t) {}
    triad(const triad& t) : first(t.first), second(t.second), third(t.third) {}
    ~triad(); // ВОТ ЗДЕСЬ

    int getfirst() const { return first; }
    int getsecond() const { return second; }
    int getthird() const { return third; }
    void setfirst(int f) { first = f; }
    void setsecond(int s) { second = s; }
    void setthird(int t) { third = t; }

    triad& operator=(const triad& t)
    {
        if (this != &t)
        {
            first = t.first;
            second = t.second;
            third = t.third;
        }
        return *this;
    }

    friend ostream& operator<<(ostream& os, const triad& t)
    {
        os << "\nfirst:" << t.first;
        os << "\nsecond:" << t.second;
        os << "\nthird:" << t.third;
        return os;
    }
    friend istream& operator>>(istream& is, triad& t)
    {
        is >> t.first >> t.second >> t.third;
        return is;
    }

private:
    int first;
    int second;
    int third;
};

// ВОТ ЗДЕСЬ
triad::~triad() {}

class Time : public triad
{
public:
    Time() {}
    Time(int h, int m, int s) : triad(h, m, s)
    {
        hours = h;
        minutes = m;
        seconds = s;
    }
    Time(const Time& tm)
    {
        hours = tm.hours;
        minutes = tm.minutes;
        seconds = tm.seconds;
    }

    int gethours() const { return hours; }
    int getminutes() const { return minutes; }
    int getseconds() const { return seconds; }
    void sethours(int f) { hours = f; }
    void setsecond(int s) { minutes = s; }
    void setthird(int t) { seconds = t; }
    ~Time(); // ВОТ ЗДЕСЬ
    triad& operator=(const Time& tm)
    {
        if (this != &tm)
        {
            hours = tm.hours;
            minutes = tm.minutes;
            seconds = tm.seconds;
        }
        return *this;
    }

    friend ostream& operator<<(ostream& os, const Time& tm)
    {
        os << "\nHours:" << tm.hours;
        os << "\nMinutes:" << tm.minutes;
        os << "\nSeconds:" << tm.seconds;
        return os;
    }
    friend istream& operator>>(istream& is, Time& tm)
    {
        is >> tm.hours >> tm.minutes >> tm.seconds;
        return is;
    }

    void plus1(Time& t)
    {
        t.seconds = t.seconds + 1;
        if (t.seconds == 60)
        {
            t.minutes = t.minutes + 1;
            if (t.minutes == 60)
            {
                t.hours = t.hours + 1;
            }
        }
        cout << t;
    }
    void plusn(Time& t, int n)
    {
        t.seconds = t.seconds + n;
        if (t.seconds == 60)
        {
            t.minutes = t.minutes + n;
            if (t.minutes == 60)
            {
                t.hours = t.hours + n;
            }
        }
        cout << t;
    }

private:
    int hours;
    int minutes;
    int seconds;
};

// ВОТ ЗДЕСЬ
Time::~Time() {}

void func1(triad& t)
{
    t.setfirst(1);
    t.setsecond(4);
    t.setthird(88);
    cout << "Вывод функции func1:" << t;
}

triad func2()
{
    Time tm(1, 4, 88);
    return tm;
}
int main()
{
    setlocale(0, "");
    system("chcp 1251>nul");
    triad t;
    cout << "Введите параметры для триады: ";
    cin >> t;
    cout << "Класс триады: " << t << endl;
    triad b(1, 4, 88);
    cout << "Заданные параметры триады, но другого объекта:" << b << endl;
    t = b;
    cout << "Присваивание объекта b объектом t" << t << endl;
    Time tm;
    cout << "Введите время: ";
    cin >> tm;
    cout << "Время:" << tm << endl;
    func1(t);
    t = func2();
    cout << t << endl;
}