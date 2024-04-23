#include <iostream>
using namespace std;

template <typename T>
class Container {
private:
    T* array;
    int size;
public:
    Container(int s);
    Container(const Container<T>& other);
    ~Container();
    void input();
    void output();
    Container<T>& operator=(const Container<T>& other);
};

template <typename T>
Container<T>::Container(int s) : size(s) {
    array = new T[size];
}

template <typename T>
Container<T>::Container(const Container<T>& other) : size(other.size) {
    array = new T[size];
    for (int i = 0; i < size; ++i) {
        array[i] = other.array[i];
    }
}

template <typename T>
Container<T>::~Container() {
    delete[] array;
}

template <typename T>
void Container<T>::input() {
    cout << "Enter " << size << " elements:" << endl;
    for (int i = 0; i < size; ++i) {
        cin >> array[i];
    }
}

template <typename T>
void Container<T>::output() {
    cout << "Container elements:" << endl;
    for (int i = 0; i < size; ++i) {
        cout << array[i] << " ";
    }
    cout << endl;
}

template <typename T>
Container<T>& Container<T>::operator=(const Container<T>& other) {
    if (this == &other) {
        return *this;
    }
    delete[] array;
    size = other.size;
    array = new T[size];
    for (int i = 0; i < size; ++i) {
        array[i] = other.array[i];
    }
    return *this;
}
class Money {
    friend ostream& operator<<(ostream& os, const Money& money);
    friend istream& operator>>(istream& is, Money& money);
private:
    long rubles;
    int kopecks;
public:
    Money(long r = 0, int k = 0) : rubles(r), kopecks(k) {}
    void input() {
        cout << "Enter rubles: ";
        cin >> rubles;
        cout << "Enter kopecks: ";
        cin >> kopecks;
    }
    void output() const {
        cout << rubles << "," << kopecks << endl;
    }

};
ostream& operator<<(ostream& os, const Money& money) {
    os << money.rubles << "," << money.kopecks;
    return os;
}

istream& operator>>(istream& is, Money& money) {
    cout << "Enter rubles: ";
    is >> money.rubles;
    cout << "Enter kopecks: ";
    is >> money.kopecks;
    return is;
}
Container<Money>& Container<Money>::operator=(const Container<Money>& other) {
    if (this == &other) {
        return *this;
    }
    delete[] array;
    size = other.size;
    array = new Money[size];
    for (int i = 0; i < size; ++i) {
        array[i] = other.array[i];
    }
    return *this;
}
int main() {
    Container<int> intContainer(5);
    intContainer.input();
    intContainer.output();

    Container<double> doubleContainer(3);
    doubleContainer.input();
    doubleContainer.output();
    Container<Money> moneyContainer(2);
    moneyContainer.input();
    moneyContainer.output();

    return 0;
}