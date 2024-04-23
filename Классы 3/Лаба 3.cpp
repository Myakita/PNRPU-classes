#include <iostream>

using namespace std;

class Money {
private:
    long rubles;
    int kopecks;

public:
    // Конструкторы
    Money() : rubles(0), kopecks(0) {}
    Money(long r, int k) : rubles(r), kopecks(k) {}
    Money(const Money& other) : rubles(other.rubles), kopecks(other.kopecks) {}

    // Деструктор
    ~Money() {}

    // Селекторы и модификаторы
    long getRubles() const { return rubles; }
    int getKopecks() const { return kopecks; }
    void setRubles(long r) { rubles = r; }
    void setKopecks(int k) { kopecks = k; }

    // Перегрузка операции присваивания
    Money& operator=(const Money& other) {
        if (this != &other) {
            rubles = other.rubles;
            kopecks = other.kopecks;
        }
        return *this;
    }

    // Перегрузка операций ввода и вывода
    friend ostream& operator<<(ostream& os, const Money& money) {
        os << money.rubles << "," << money.kopecks;
        return os;
    }

    friend istream& operator>>(istream& is, Money& money) {
        is >> money.rubles >> money.kopecks;
        return is;
    }

    // Перегрузка операции сравнения <
    bool operator<(const Money& other) const {
        if (rubles < other.rubles)
            return true;
        else if (rubles == other.rubles && kopecks < other.kopecks)
            return true;
        return false;
    }

    // Перегрузка операции сравнения >
    bool operator>(const Money& other) const {
        if (rubles > other.rubles)
            return true;
        else if (rubles == other.rubles && kopecks > other.kopecks)
            return true;
        return false;
    }

    // Перегрузка операции постфиксного инкремента ++
    Money operator++(int) {
        Money temp(*this);
        kopecks++;
        if (kopecks >= 100) {
            rubles++;
            kopecks -= 100;
        }
        return temp;
    }

    // Перегрузка операции префиксного инкремента ++
    Money& operator++() {
        kopecks++;
        if (kopecks >= 100) {
            rubles++;
            kopecks -= 100;
        }
        return *this;
    }
};

int main() {
    setlocale(0, "");
    system("chcp 1251>nul");
    Money m1(10, 50);
    Money m2(5, 75);

    cout << "m1: " << m1 << endl;
    cout << "m2: " << m2 << endl;

    if (m1 < m2)
        cout << "m1 меньше, чем m2" << endl;
    else
        cout << "m1 не меньше, чем m2" << endl;

    if (m1 > m2)
        cout << "m1 больше, чем m2" << endl;
    else
        cout << "m1 не больше, чем m2" << endl;

    cout << "Постфиксный инкремент m1: " << (m1++) << endl;
    cout << "Теперь m1: " << m1 << endl;

    cout << "Префиксный инкремент m2: " << (++m2) << endl;
    cout << "Теперь m2: " << m2 << endl;

    return 0;
}