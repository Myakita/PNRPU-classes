#include <iostream>
using namespace std;

class Object {
public:
    Object() {};
    virtual ~Object() {};
    virtual void output() = 0;
};

class Triad : public Object {
    friend istream& operator>>(istream& in, Triad& t);
    friend ostream& operator<<(ostream& on, const Triad& t);

public:
    ~Triad() {};
    Triad() : first(0), second(0), third(0) {}
    Triad(int f, int s, int th) : first(f), second(s), third(th) {}
    Triad(const Triad& t) : first(t.first), second(t.second), third(t.third) {}

    int getfirst() const { return first; }
    int getsecond() const { return second; }
    int getthird() const { return third; }

    void setfirst(int f) { first = f; }
    void setsecond(int s) { second = s; }
    void setthird(int th) { third = th; }

    Triad& operator=(const Triad& t) {
        if (this != &t) {
            first = t.first;
            second = t.second;
            third = t.third;
        }
        return *this;
    }

    void output() override {
        cout << "\nfirst: " << first;
        cout << "\nsecond: " << second;
        cout << "\nthird: " << third;
    }

protected:
    int first;
    int second;
    int third;
};

class Time : public Triad {
    friend istream& operator>>(istream& in, Time& t);
    friend ostream& operator<<(ostream& os, const Time& t);
public:
    ~Time() {};
    Time() : hours(0), minutes(0), seconds(0) {}
    Time(const Time& t) : Triad(t), hours(t.hours), minutes(t.minutes), seconds(t.seconds) {}
    Time(int h, int m, int s) : Triad(h, m, s), hours(h), minutes(m), seconds(s) {}

    void sethours(int h) { hours = h; }
    void setminutes(int m) { minutes = m; }
    void setseconds(int s) { seconds = s; }

    int gethours() const { return hours; }
    int getminutes() const { return minutes; }
    int getseconds() const { return seconds; }

    Time operator-(const int& minus) const {
        return Time(hours, minutes, seconds - minus);
    }

    Time operator+(const int& plus) const {
        return Time(hours, minutes, seconds + plus);
    }

    void output() override {
        cout << "\nhours: " << hours;
        cout << "\nminutes: " << minutes;
        cout << "\nseconds: " << seconds;
    }
    void increment(Time& t,int n) 
    {
        t.seconds += n;
        if (seconds >= 60)
        {
            t.minutes += 1;
            t.seconds -= 60;
            if (t.minutes >= 60)
            {
                t.hours += 1;
                t.minutes -= 60;
                if (t.hours >= 24)
                {
                    t.hours -= 24;
                }
            }
        }
    }

protected:
    int hours;
    int minutes;
    int seconds;
};

class Vector {
    friend ostream& operator<<(ostream& os, const Vector& t);
public:
    ~Vector() {};
    Vector() {
        beg = 0;
        size = 0;
        cur = 0;
    };
    Vector(int lin) {
        beg = new Object * [lin];
        cur = 0;
        size = lin;
    }
    void add(Object* ptr) {
        if (cur < size) {
            beg[cur] = ptr;
            cur++;
        }
    }

private:
    Object** beg;
    int size;
    int cur;
};
istream& operator>>(istream& in, Triad& t)
{
    cout << "Введите первое: ";
    in >> t.first;
    cout << "Введите второе: ";
    in >> t.second;
    cout << "Введите третье: ";
    in >> t.third;
    return in;

}

istream& operator>>(istream& in, Time& t) {
    cout << "Введите часы: ";
    in >> t.hours;
    cout << "Введите минуты: ";
    in >> t.minutes;
    cout << "Введите секунды: ";
    in >> t.seconds;
    return in;
}

ostream& operator<<(ostream& os, const Vector& v)
{
    if (v.size == 0)
    {
        os << "\nВектор пуст";
    }
    else
    {
        Object** ptr = v.beg;
        for (int i = 0; i < v.cur; i++)
        {
            (*ptr)->output();
            ptr++;
        }
    }
    return os;
}
ostream& operator<<(ostream& os, const Triad& t)
{
    os << "\nfirst: " << t.first;
    os << "\nsecond: " << t.second;
    os << "\nthird: " << t.third;
    return os;
}

ostream& operator<<(ostream& os, const Time& t)
{
    os << "hours: " << t.gethours() << ", minutes: " << t.getminutes() << ", seconds: " << t.getseconds();
    return os;
}

int main()
{
    setlocale(0, "");
    Vector vec(4);
    Triad tr;
    Time tm;
    cout << "Базовый класс: " << endl;
    cin >> tr;
    cout << tr;
    cout << "\nЕще один класс: " << endl;
    cin >> tm;
    cout << tm;
    cout << "До инкремента: " << tm << endl;
    tm.increment(tm,2);
    cout << "После инкремента: " << tm << endl;

}