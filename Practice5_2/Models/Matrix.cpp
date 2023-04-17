#include <iostream>
#include <ctime>
using namespace std;

#ifdef _WIN32
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
#endif


class Matrix {
private:
    double* data; // указатель на массив данных
    int size; // размер матрицы

public:
    Matrix(int n) : size(n) {
        data = new double[size];
        // инициализируем матрицу нул€ми
        for (int i = 0; i < size; i++) {
            data[i] = 0;
        }
    }

    Matrix(int n, double* values) : size(n) {
        data = new double[size];
        // копируем значени€ из переданного массива
        for (int i = 0; i < size; i++) {
            data[i] = values[i];
        }
    }

    // конструктор копировани€
    Matrix(const Matrix& other) : size(other.size) {
        data = new double[size];
        // копируем значени€ из другой матрицы
        for (int i = 0; i < size; i++) {
            data[i] = other.data[i];
        }
    }

    // деструктор
    ~Matrix() {
        delete[] data;
    }

    // оператор присваивани€
    Matrix& operator=(const Matrix& other) {
        if (this != &other) {
            // освобождаем старую пам€ть
            delete[] data;
            // выдел€ем новую пам€ть
            size = other.size;
            data = new double[size];
            // копируем значени€ из другой матрицы
            for (int i = 0; i < size; i++) {
                data[i] = other.data[i];
            }
        }
        return *this;
    }

    // метод дл€ решени€ системы линейных уравнений
    EXPORT double* Solve(double* b) 
    {
        if (sizeof(b)/sizeof(double) != size) {
        throw std::invalid_argument("–азмеры матрицы и вектора-столбца не совпадают");
        }

        // ѕреобразование вектор-столбца в вектор-строку
        double* xT = b;

        // —оздание поэлементного массива из матрицы
        double* c = new double[size*size];
        for (int i = 0; i < size; i++) {
        for (int j = 0; j < size; j++) {
        c[i * size + j] = data[(i - j + size) % size];
        }
        }

        // —оздание зеркальной копии массива c
        double* r = new double[size*size];
        for (int i = 0; i < size; i++) {
        for (int j = 0; j < size; j++) {
        r[i * size + j] = c[((size - i) % size) * size + ((size - j) % size)];
        }
        }

        // ”множение матрицы T на вектор-строку xT
        double* y1 = new double[size];
        for (int k = 0; k < size; k++) {
        double sum = 0;
        for (int j = 0; j < size; j++) {
        sum += c[k * size + j] * xT[j];
        }
        y1[k] = sum;
        }

        // ”множение матрицы R на вектор-строку y1
        double* y2 = new double[size];
        for (int k = 0; k < size; k++) {
        double sum = 0;
        for (int j = 0; j < size; j++) {
        sum += r[k * size + j] * y1[j];
        }
        y2[k] = sum;
        }

        // ѕреобразование вектор-строки y2 в вектор-столбец
        double* x = y2;

        return x;
    }

    // вспомогательный метод дл€ вычислени€ скал€рного произведени€ векторов
    double dot(double* a, double* b, int n) {
        double sum = 0;
        for (int i = 0; i < n; i++) {
            sum += a[i] * b[i];
        }
        return sum;
    }


    EXPORT double measure_time(int n, int repeats) 
    {
        Matrix A(n);
        double* b = new double[n];
        double* x = new double[n];
        double start_time = (double)clock() / CLOCKS_PER_SEC;

        for (int i = 0; i < repeats; i++) {
            for (int j = 0; j < n; j++) {
                b[j] = (double)rand() / RAND_MAX;
                x[j] = 0;
            }
            solve(A, b, x);
        }

        double end_time = (double)clock() / CLOCKS_PER_SEC;

        delete[] b;
        delete[] x;

        return end_time - start_time;
    }
};