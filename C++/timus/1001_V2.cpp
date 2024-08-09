#include <bits/stdc++.h>

using namespace std;

void reverseAndPrintSqrt(){
    long long a;
    if(cin>>a){
        reverseAndPrintSqrt();
        printf("%.4lf\n",sqrt(a));
    }
}

int main(){
    reverseAndPrintSqrt();
    return 0;
}

