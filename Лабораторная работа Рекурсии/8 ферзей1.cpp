// 8 ферзей1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>

using namespace std;

const int N = 8;


bool isSafe(int board[N][N], int row, int col) 
{
    int i, j; 

    for (i = 0; i < col; ++i)
        if (board[row][i])
            return false;

    for (i = row, j = col; i >= 0 && j >= 0; --i, --j)
        if (board[i][j])
            return false;

    for (i = row, j = col; j >= 0 && i < N; ++i, --j)
        if (board[i][j])
            return false;

    return true;
}


bool solveNQueensUtil(int board[N][N], int col) 
{
    if (col >= N) {
        for (int i = 0; i < N; ++i) {
            for (int j = 0; j < N; ++j)
                cout << board[i][j] << " ";
            cout << endl;
        }
        cout << endl;
        return true;
    }

    bool res = false;

    for (int i = 0; i < N; ++i)
    {
        if (isSafe(board, i, col)) 
        {
            board[i][col] = 1;
            res = solveNQueensUtil(board, col + 1) || res;
            board[i][col] = 0;
        }
    }
    return res;
}


void solveNQueens() {
    int board[N][N] = { 0 }; 
    if (!solveNQueensUtil(board, 0))
        cout << "Решение не существует";
}

int main() {
    solveNQueens();
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
