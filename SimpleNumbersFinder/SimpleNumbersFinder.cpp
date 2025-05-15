#include <iostream>
#include <vector>
#include <cmath>
#include <string>
#include <limits>

using namespace std;

class SimpleNumbersFinder {
private:
    int leftPoint;
    int rightPoint;
    vector<int> interval;
    vector<int> simpleNumbers;

public:
    void ExecuteSimpleNumbersFinder() {
        InputInterval();
        FillInterval(leftPoint, rightPoint, interval);
        DetermineSimpleNumbers(interval);
        cout << "Count of simple number that founded in interval: " << simpleNumbers.size() << endl;
    }

private:
    void InputInterval() {
        bool isValidated = false;
        string a, b;

        while (!isValidated) {
            cout << "Input left point of interval: ";
            getline(cin, a);

            cout << "Input right point of interval: ";
            getline(cin, b);

            isValidated = ValidateInput(a, b);
        }
    }

    bool ValidateInput(const string& a, const string& b) {
        try {
            leftPoint = stoi(a);
            rightPoint = stoi(b);
        }
        catch (...) {
            cout << "\nInput data is not correct. Try again...\n" << endl;
            return false;
        }

        if (leftPoint > rightPoint) {
            cout << "\nInput data is not correct. Try again...\n" << endl;
            return false;
        }

        return true;
    }

    void FillInterval(int a, int b, vector<int>& array) {
        cout << "\nInterval: [";
        for (int i = a; i <= b; ++i) {
            array.push_back(i);
            cout << i << ", ";
        }
        cout << "]\n";
    }

    void DetermineSimpleNumbers(const vector<int>& array) {
        cout << "\nSimple numbers: [";
        for (int num : array) {
            if (IsSimpleNumber(num)) {
                simpleNumbers.push_back(num);
                cout << num << ", ";
            }
        }
        cout << "]\n";
    }

    bool IsSimpleNumber(int number) {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        int boundary = static_cast<int>(sqrt(number));
        for (int i = 3; i <= boundary; i += 2) {
            if (number % i == 0)
                return false;
        }
        return true;
    }
};

int main() {
    SimpleNumbersFinder finder;
    finder.ExecuteSimpleNumbersFinder();
    return 0;
}
