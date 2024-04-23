#include <iostream>
#include <fstream>

using namespace std;

class Money {
private:
    long rubles;
    int kopecks;

public:
    Money() : rubles(0), kopecks(0) {}
    Money(long r, int k) : rubles(r), kopecks(k) {}
    Money(const Money& other) : rubles(other.rubles), kopecks(other.kopecks) {}
    ~Money() {}

    long getRubles() const { return rubles; }
    int getKopecks() const { return kopecks; }
    void setRubles(long r) { rubles = r; }
    void setKopecks(int k) { kopecks = k; }

    Money& operator=(const Money& other) {
        if (this != &other) {
            rubles = other.rubles;
            kopecks = other.kopecks;
        }
        return *this;
    }

    friend ostream& operator<<(ostream& os, const Money& money) {
        os << money.rubles << "," << money.kopecks;
        return os;
    }

    friend istream& operator>>(istream& is, Money& money) {
        is >> money.rubles >> money.kopecks;
        return is;
    }

    bool operator<(const Money& other) const {
        if (rubles < other.rubles)
            return true;
        else if (rubles == other.rubles && kopecks < other.kopecks)
            return true;
        return false;
    }

    bool operator>(const Money& other) const {
        if (rubles > other.rubles)
            return true;
        else if (rubles == other.rubles && kopecks > other.kopecks)
            return true;
        return false;
    }

    Money operator++(int) {
        Money temp(*this);
        kopecks++;
        if (kopecks >= 100) {
            rubles++;
            kopecks -= 100;
        }
        return temp;
    }

    Money& operator++() {
        kopecks++;
        if (kopecks >= 100) {
            rubles++;
            kopecks -= 100;
        }
        return *this;
    }

    Money operator/=(int divisor) {
        long totalKopecks = rubles * 100 + kopecks;
        totalKopecks /= divisor;
        rubles = totalKopecks / 100;
        kopecks = totalKopecks % 100;
        return *this;
    }

    Money operator*(int multiplier) const {
        Money result;
        long totalKopecks = rubles * 100 + kopecks;
        totalKopecks *= multiplier;
        result.rubles = totalKopecks / 100;
        result.kopecks = totalKopecks % 100;
        return result;
    }
};


void saveToFile(const Money* moneyList, int count, const string& filename) {
    ofstream outFile(filename, ios::out | ios::binary);
    if (!outFile) {
        cerr << "Ошибка открытия файла для записи." << endl;
        return;
    }
    outFile.write((const char*)moneyList, count * sizeof(Money));
    outFile.close();
}


Money* loadFromFile(int& count, const string& filename) {
    ifstream inFile(filename, ios::in | ios::binary);
    if (!inFile) {
        cerr << "Ошибка открытия файла для чтения." << endl;
        return nullptr;
    }
    inFile.seekg(0, ios::end);
    count = inFile.tellg() / sizeof(Money);
    inFile.seekg(0, ios::beg);
    Money* moneyList = new Money[count];
    inFile.read((char*)moneyList, count * sizeof(Money));
    inFile.close();
    return moneyList;
}


void deleteGreaterThan(Money* moneyList, int& count, const Money& value) {
    int newIndex = 0;
    for (int i = 0; i < count; ++i) {
        if (!(moneyList[i] > value)) {
            moneyList[newIndex] = moneyList[i];
            ++newIndex;
        }
    }
    count = newIndex;
}


void printRecords(const Money* moneyList, int count) {
    cout << "Записи:" << endl;
    for (int i = 0; i < count; ++i) {
        cout << moneyList[i] << endl;
    }
}

int main() {
    setlocale(0, "");
    system("chcp 1251>nul");

    Money* mArr = new Money[3];
    mArr[0] = Money(10, 50);
    mArr[1] = Money(5, 75);
    mArr[2] = Money(15, 30);

    saveToFile(mArr, 3, "money.dat");
    cout << "Файл сохранен" << endl;

    int count = 0;
    Money* loadedArr = loadFromFile(count, "money.dat");

    if (loadedArr) {
        printRecords(loadedArr, count);

        
        Money valueToDelete(10, 0);
        deleteGreaterThan(loadedArr, count, valueToDelete);

        cout << "\nПосле удаления записей больше чем 10 рублей:" << endl;
        printRecords(loadedArr, count);

        delete[] loadedArr;
    }

    delete[] mArr;
    return 0;
}